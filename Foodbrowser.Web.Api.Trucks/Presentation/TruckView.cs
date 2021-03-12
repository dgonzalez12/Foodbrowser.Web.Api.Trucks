using System;

namespace Foodbrowser.Web.Api.Trucks.Presentation
{
    /// <summary>
    /// Represents a view of truck object.
    /// </summary>
    public class TruckView
    {
        public int DayOrder { get; set; }
        public string DayOfWeekStr { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Permit { get; set; }
        public string Location { get; set; }
        public string LocationDesc { get; set; }
        public string OptionalText { get; set; }
        public int? LocationId { get; set; }
        public string Start24 { get; set; }
        public string End24 { get; set; }
        public int? CNN { get; set; }
        public DateTime? Addr_Date_Create { get; set; }
        public DateTime? Addr_Date_Modified { get; set; }
        public string Block { get; set; }
        public string Lot { get; set; }
        public string ColdTruck { get; set; }
        public string Applicant { get; set; }
        public decimal? X { get; set; }
        public decimal? Y { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
    }
}
