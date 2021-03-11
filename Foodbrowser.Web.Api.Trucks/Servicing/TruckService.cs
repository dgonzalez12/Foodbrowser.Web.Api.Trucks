using Foodbrowser.Core.Modules.Trucks.Persistence;
using Foodbrowser.Core.Modules.Trucks.Servicing;
using Foodbrowser.Web.Api.Trucks.Definition;

namespace Foodbrowser.Web.Api.Trucks.Servicing
{
    public class TruckService : TruckService<Truck>
    {
        public TruckService(ITruckStore<Truck> truckStore)
            : base(truckStore)
        {

        }
    }
}
