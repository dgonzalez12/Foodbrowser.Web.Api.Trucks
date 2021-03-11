using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foodbrowser.Core.Modules.Trucks.Filtering;
using Foodbrowser.Web.Api.Trucks.Filtering;
using Foodbrowser.Web.Common.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Foodbrowser.Web.Api.Trucks.Controllers
{
    [Produces("application/json")]
    [Route("api/trucks")]
    public class TrucksController : Controller
    {
        [HttpGet]
        public async Task<BaseResponse<int>> FindTrucks([FromBody]TruckFilter filter)
        {
            try
            {

            }
            catch (Exception e)
            {
                return BaseResponse<int>.Create($"Server Error: { e.Message }");
            }
        }
    }
}