using System;

namespace Foodbrowser.Core.Modules.Trucks.Filtering
{
    public interface ITruckFilter
    {
        DayOfWeek? DayOfWeek { get; set; }
        string Time { get; set; }

        void Validate();
    }
}
