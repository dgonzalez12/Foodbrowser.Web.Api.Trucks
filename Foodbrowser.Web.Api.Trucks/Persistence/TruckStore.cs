using Foodbrowser.Core.Modules.Trucks.Exceptions;
using Foodbrowser.Core.Modules.Trucks.Filtering;
using Foodbrowser.Core.Modules.Trucks.Persistence;
using Foodbrowser.Web.Api.Trucks.Definition;
using Foodbrowser.Web.Api.Trucks.External;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Foodbrowser.Web.Api.Trucks.Persistence
{
    /// <summary>
    /// Represents a data store of a truck object.
    /// </summary>
    /// <typeparam name="T">Type of truck object.</typeparam>
    public class TruckStore : ITruckStore<Truck>
    {
        /// <summary>
        /// Instance of socrata client.
        /// </summary>
        private readonly ISocrataClient SocrataClient;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="socrataClient">Instance of socrata client.</param>
        public TruckStore(ISocrataClient socrataClient)
        {
            SocrataClient = socrataClient != null
                            ? socrataClient
                            : throw new TruckException($"Cannot find service: { nameof(socrataClient) }.");
        }

        /// <summary>
        /// Gets a list of truck objects.
        /// </summary>
        /// <typeparam name="TFilter">Type of truck filter.</typeparam>
        /// <param name="filter">Filter object.</param>
        /// <returns></returns>
        public async Task<ICollection<Truck>> FindTrucksAsync<TFilter>(TFilter filter)
            where TFilter : class, ITruckFilter
        {
            var uri = $"{ SocrataClient.Host + SocrataClient.Resource }";

            if (filter != null)
                uri += filter.ToString();

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetAsync(new Uri(uri));

            if (!response.IsSuccessStatusCode)
            {
                throw new TruckException($"Socrata service error: See log for more information.");
            }

            var stringContent = await response.Content.ReadAsStringAsync();
            ICollection<Truck> trucks = JsonConvert.DeserializeObject<ICollection<Truck>>(stringContent);

            return trucks;
        }

    }
}
