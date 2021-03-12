using Foodbrowser.Core.Modules.Trucks.Persistence;
using Foodbrowser.Core.Modules.Trucks.Servicing;
using Foodbrowser.Web.Api.Trucks.Definition;

namespace Foodbrowser.Web.Api.Trucks.Servicing
{
    /// <summary>
    /// Represents a business object of truck.
    /// </summary>
    /// <typeparam name="T">Type of truck object.</typeparam>
    public class TruckService : TruckService<Truck>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="truckStore">Instance of a truck data store.</param>
        public TruckService(ITruckStore<Truck> truckStore)
            : base(truckStore)
        {

        }
    }
}
