using Foodbrowser.Core.Modules.Trucks.Definition;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foodbrowser.Core.Modules.Trucks.Persistence
{
    public interface ITruckStore<T>
        where T : class, ITruck
    {
        Task<ICollection<T>> FindTrucks(DayOfWeek? dayOfWeek = null, TimeSpan? time = null);
    }
}
