using Foodbrowser.Core.Modules.Trucks.Exceptions;
using Foodbrowser.Core.Modules.Trucks.Filtering;
using System;
using System.Text.RegularExpressions;

namespace Foodbrowser.Web.Api.Trucks.Filtering
{
    public class TruckFilter : ITruckFilter<TruckPaging>
    {
        public DayOfWeek? DayOfWeek { get; set; }
        public string Time { get; set; }
        public TruckPaging Paging { get; set; }

        public void Validate()
        {
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
