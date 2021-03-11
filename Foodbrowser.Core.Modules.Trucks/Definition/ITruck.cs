using System;

namespace Foodbrowser.Core.Modules.Trucks.Definition
{
    public interface ITruck
    {
        int DayOrder { get; set; }
        string DayOfWeekStr { get; set; }
        string StartTime { get; set; }
        string EndTime { get; set; }
        string Permit { get; set; }
        string Location { get; set; }
        string LocationDesc { get; set; }
        string OptionalText { get; set; }
        int LocationId { get; set; }
        string Start24 { get; set; }
        string End24 { get; set; }
        int CNN { get; set; }
        DateTime Addr_Date_Create { get; set; }
        DateTime Addr_Date_Modified { get; set; }
        string Block { get; set; }
        string Lot { get; set; }
        string ColdTruck { get; set; }
        string Applicant { get; set; }
        int X { get; set; }
        int Y { get; set; }
        int Latitude { get; set; }
        int Longitude { get; set; }        
    }
}
