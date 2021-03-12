using Foodbrowser.Core.Modules.Trucks.Definition;
using Foodbrowser.Core.Modules.Trucks.Filtering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foodbrowser.Core.Modules.Trucks.Persistence
{
    /// <summary>
    /// Represents a data store of a truck object.
    /// </summary>
    /// <typeparam name="T">Type of truck object.</typeparam>
    public interface ITruckStore<T>
        where T : class, ITruck
    {
        /// <summary>
        /// Gets a list of truck objects.
        /// </summary>
        /// <typeparam name="TFilter">Type of truck filter.</typeparam>
        /// <param name="filter">Filter object.</param>
        /// <returns></returns>
        Task<ICollection<T>> FindTrucksAsync<TFilter>(TFilter filter) where TFilter : class, ITruckFilter;
    }
}
