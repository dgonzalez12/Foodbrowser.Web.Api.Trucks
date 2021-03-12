using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foodbrowser.Core.Modules.Trucks.Filtering;
using Foodbrowser.Core.Modules.Trucks.Servicing;
using Foodbrowser.Web.Api.Trucks.Definition;
using Foodbrowser.Web.Api.Trucks.Filtering;
using Foodbrowser.Web.Api.Trucks.Presentation;
using Foodbrowser.Web.Common.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Foodbrowser.Web.Api.Trucks.Controllers
{
    [Produces("application/json")]
    [Route("api/trucks")]
    public class TrucksController : Controller
    {
        private readonly TruckService<Truck> TruckService;

        public TrucksController(TruckService<Truck> truckService)
        {
            TruckService = truckService;
        }

        [HttpGet]
        public async Task<BaseResponse<ICollection<TruckView>>> FindTrucks([FromBody]TruckFilter filter)
        {
            try
            {
                var trucks = await TruckService.FindTrucksAsync<TruckFilter>(filter);
                var views = TruckMapper.ToViews(trucks);
                return BaseResponse<ICollection<TruckView>>.Create("Done.", views);
            }
            catch (Exception e)
            {
                return BaseResponse<ICollection<TruckView>>.Create($"Server Error: { e.Message }");
            }
        }
    }
}