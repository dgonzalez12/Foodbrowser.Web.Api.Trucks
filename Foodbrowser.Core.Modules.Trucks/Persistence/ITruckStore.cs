using Foodbrowser.Core.Modules.Trucks.Definition;
using Foodbrowser.Core.Modules.Trucks.Filtering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foodbrowser.Core.Modules.Trucks.Persistence
{
    public interface ITruckStore<T>
        where T : class, ITruck
    {
        Task<ICollection<T>> FindTrucksAsync<TFilter>(TFilter filter) where TFilter : class, ITruckFilter;
    }
}
