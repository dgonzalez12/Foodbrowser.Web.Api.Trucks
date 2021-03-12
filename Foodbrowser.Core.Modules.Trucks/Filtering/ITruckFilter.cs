using System;

namespace Foodbrowser.Core.Modules.Trucks.Filtering
{
    /// <summary>
    /// Represents a filter object used by truck modules.
    /// </summary>
    public interface ITruckFilter
    {
        /// <summary>
        /// Day of the week. Starts as Sunday=0.
        /// </summary>
        DayOfWeek? DayOfWeek { get; set; }
        /// <summary>
        /// Hour of the day. Starts on 00:00 and end on 23:59.
        /// </summary>
        string Time { get; set; }

        /// <summary>
        /// Validates filter values.
        /// </summary>
        void Validate();
    }
}
