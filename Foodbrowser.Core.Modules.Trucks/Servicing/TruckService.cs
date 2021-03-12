using Foodbrowser.Core.Modules.Trucks.Definition;
using Foodbrowser.Core.Modules.Trucks.Exceptions;
using Foodbrowser.Core.Modules.Trucks.Filtering;
using Foodbrowser.Core.Modules.Trucks.Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foodbrowser.Core.Modules.Trucks.Servicing
{
    /// <summary>
    /// Represents a business object of truck.
    /// </summary>
    /// <typeparam name="T">Type of truck object.</typeparam>
    public class TruckService<T>
        where T : class, ITruck
    {
        /// <summary>
        /// Instance of a truck data store.
        /// </summary>
        protected internal ITruckStore<T> TruckStore { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="truckStore">Instance of a truck data store.</param>
        public TruckService(ITruckStore<T> truckStore)
        {
            TruckStore = truckStore != null ? truckStore : throw new TruckException($"Cannot find service: { nameof(TruckStore) }");
        }

        /// <summary>
        /// Gets a list of truck objects.
        /// </summary>
        /// <typeparam name="TFilter">Type of truck filter.</typeparam>
        /// <param name="filter">Filter object.</param>
        /// <returns></returns>
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
