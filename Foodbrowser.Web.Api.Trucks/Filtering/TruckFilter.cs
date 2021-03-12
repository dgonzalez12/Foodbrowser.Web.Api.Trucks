using Foodbrowser.Core.Modules.Trucks.Exceptions;
using Foodbrowser.Core.Modules.Trucks.Filtering;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Foodbrowser.Web.Api.Trucks.Filtering
{
    /// <summary>
    /// Represents a filter object used by truck modules.
    /// </summary>
    public class TruckFilter : ITruckFilter
    {
        /// <summary>
        /// Day of the week. Starts as Sunday=0.
        /// </summary>
        public DayOfWeek? DayOfWeek { get; set; }
        /// <summary>
        /// Hour of the day. Starts on 00:00 and end on 23:59.
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// Returns filters as a url encode string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var filters = new List<string>();
            string parameters = string.Empty;

            if (DayOfWeek != null || !string.IsNullOrEmpty(Time))
            {
                string condition = "1=1";

                if (DayOfWeek != null)
                    condition += $" AND dayorder={ (int)DayOfWeek }";

                if (!string.IsNullOrEmpty(Time))
                    condition += $" AND start24 < '{ Time }' AND end24 > '{ Time }'";

                filters.Add($"$where={Uri.EscapeUriString(condition)}");
            }

            filters.Add(Uri.EscapeUriString("$order=applicant ASC"));

            if (filters.Count > 0)
                parameters = $"?{ string.Join("&", filters) }";

            return parameters;
        }

        /// <summary>
        /// Validates filter values.
        /// </summary>
        public void Validate()
        {
            if (DayOfWeek != null)
            {
                if (!Enum.IsDefined(typeof(DayOfWeek), (int)DayOfWeek))
                    throw new TruckException("Day of week is out of range.");
            }
            if (!string.IsNullOrEmpty(Time))
            {
                if (!Regex.IsMatch(Time, "^(0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$"))
                    throw new TruckException("Time format is incorrect.");
            }
        }
    }
}
