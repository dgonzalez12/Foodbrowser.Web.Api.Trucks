using Foodbrowser.Core.Modules.Trucks.Definition;
using Foodbrowser.Core.Modules.Trucks.Exceptions;
using Foodbrowser.Core.Modules.Trucks.Filtering;
using Foodbrowser.Core.Modules.Trucks.Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foodbrowser.Core.Modules.Trucks.Servicing
{
    public class TruckService<T>
        where T : class, ITruck
    {
        protected internal ITruckStore<T> TruckStore { get; set; }

        public TruckService(ITruckStore<T> truckStore)
        {
            TruckStore = truckStore != null ? truckStore : throw new TruckException($"Cannot find service: { nameof(TruckStore) }");
        }

        public async Task<ICollection<T>> FindTrucksAsync<TFilter>(TFilter filter)
            where TFilter : class, ITruckFilter
        {
            if (filter != null)
            {
                filter.Validate();
            }

            return await TruckStore.FindTrucksAsync(filter);
        }
    }
}
