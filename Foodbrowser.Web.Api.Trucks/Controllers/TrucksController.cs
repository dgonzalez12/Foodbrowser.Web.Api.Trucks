using Foodbrowser.Core.Modules.Trucks.Servicing;
using Foodbrowser.Web.Api.Trucks.Definition;
using Foodbrowser.Web.Api.Trucks.Filtering;
using Foodbrowser.Web.Api.Trucks.Presentation;
using Foodbrowser.Web.Common.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foodbrowser.Web.Api.Trucks.Controllers
{
    /// <summary>
    /// Represents an endpoint for truck operations.
    /// </summary>
    [Route("api/trucks")]
    public class TrucksController : Controller
    {
        /// <summary>
        /// Instance of a truck business object.
        /// </summary>
        private readonly TruckService<Truck> TruckService;

        /// <summary>
        /// Contructor.
        /// </summary>
        /// <param name="truckService">Instance of a truck business object.</param>
        public TrucksController(TruckService<Truck> truckService)
        {
            TruckService = truckService;
        }

        /// <summary>
        /// Gets a list of truck objects.
        /// </summary>
        /// <param name="dayOfWeek">Day of week. Starts on Sunday=0.</param>
        /// <param name="time">Hour of day. Starts on 00:00 and ends on 23:59.</param>
        /// <returns></returns>
        [HttpGet]
        [Consumes("application/json"), Produces("application/json")]
        public async Task<BaseResponse<ICollection<TruckView>>> FindTrucks([FromQuery]DayOfWeek? dayOfWeek, [FromQuery]string time)
        {
            try
            {
                var filter = new TruckFilter { DayOfWeek = dayOfWeek, Time = time };
                var trucks = await TruckService.FindTrucksAsync<TruckFilter>(filter);
                //var trucks = new List<Truck>();
                var views = await TruckMapper.ToViews(trucks);
                return BaseResponse<ICollection<TruckView>>.Create("Done.", views);
            }
            catch (Exception e)
            {
                return BaseResponse<ICollection<TruckView>>.Create($"Server Error: { e.Message }");
            }
        }
    }
}