using Foodbrowser.Core.Modules.Trucks.Exceptions;
using Foodbrowser.Core.Modules.Trucks.Filtering;
using Foodbrowser.Core.Modules.Trucks.Persistence;
using Foodbrowser.Web.Api.Trucks.Definition;
using Foodbrowser.Web.Api.Trucks.External;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Foodbrowser.Web.Api.Trucks.Persistence
{
    public class TruckStore : ITruckStore<Truck>
    {
        private readonly ISocrataClient SocrataClient;

        public TruckStore(ISocrataClient socrataClient)
        {
            SocrataClient = socrataClient != null
                            ? socrataClient
                            : throw new TruckException($"Cannot find service: { nameof(socrataClient) }.");
        }

        public async Task<ICollection<Truck>> FindTrucksAsync<TFilter>(TFilter filter)
            where TFilter : class, ITruckFilter
        {
            var uri = $"{ SocrataClient.Host + SocrataClient.Resource }";

            if (filter != null)
            {
                uri += filter.ToString();
            }

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetAsync(new Uri(uri));

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new TruckException($"Socrata service error: { error }.");
            }

            var stringContent = await response.Content.ReadAsStringAsync();
            ICollection<Truck> trucks = JsonConvert.DeserializeObject<ICollection<Truck>>(stringContent);

            return trucks;
        }

    }
}
