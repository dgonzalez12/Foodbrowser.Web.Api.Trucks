using Foodbrowser.Core.Modules.Trucks.Exceptions;
using Foodbrowser.Core.Modules.Trucks.Filtering;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;

namespace Foodbrowser.Web.Api.Trucks.Filtering
{
    public class TruckFilter : ITruckFilter<TruckPaging>
    {
        public DayOfWeek? DayOfWeek { get; set; }
        public string Time { get; set; }
        public TruckPaging Paging { get; set; }

        public override string ToString()
        {
            var filters = new List<string>();
            string parameters = string.Empty;

            if (DayOfWeek != null || !string.IsNullOrEmpty(Time))
            {
                string condition = "1=1";

                if (DayOfWeek != null)
                {
                    condition += $" AND dayorder={ (int)DayOfWeek }";
                }
                if (!string.IsNullOrEmpty(Time))
                {
                    condition += $" AND start24 < '{ Time }' AND end24 > '{ Time }'";
                }
                filters.Add($"$where={Uri.EscapeUriString(condition)}");
            }

            if (filters.Count > 0)
            {
                //parameters = new FormUrlEncodedContent(filters).ReadAsStringAsync().Result;
                parameters = string.Join("&", filters);
                parameters = $"?{parameters}";
            }

            return parameters;
        }

        public void Validate()
        {
            if (!Enum.IsDefined(typeof(DayOfWeek), (int)DayOfWeek))
            {
                throw new TruckException("Day of week is out of range.");
            }
            if (!string.IsNullOrEmpty(Time))
            {
                if (!Regex.IsMatch(Time, "^(0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$"))
                {
                    throw new TruckException("Time format is incorrect.");
                }
            }
            if (Paging != null)
            {
                if (!(Paging.PageNumber > 0))
                {
                    throw new TruckException("Page number in paging must be greater than zero.");
                }
                if (!(Paging.RowsPerPage > 0))
                {
                    throw new TruckException("Rows per page number in paging must be greater than zero.");
                }
            }
        }
    }
}
