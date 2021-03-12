using Foodbrowser.Web.Api.Trucks.Controllers;
using Foodbrowser.Web.Api.Trucks.External;
using Foodbrowser.Web.Api.Trucks.Persistence;
using Foodbrowser.Web.Api.Trucks.Servicing;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Foodbrowser.Web.Api.Trucks.Test
{
    public class TrucksApiTest
    {
        /// <summary>
        /// Evaluates that filter parameters are not required.
        /// </summary>
        /// <returns>True if operation was executed succesfully. </returns>
        [Fact]
        public async Task FindTrucks_WithoutFilter_ReturnsListOfTrucks()
        {
            var dictionary = new Dictionary<string, string>
            {
                { "SocrataClient:Host", "https://data.sfgov.org/resource/" },
                { "SocrataClient:Resource", "jjew-r69b.json"}
            };
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(dictionary)
                .Build();
            var socrataClient = new SocrataClient(configuration);
            var truckStore = new TruckStore(socrataClient);
            var truckService = new TruckService(truckStore);
            var trucksController = new TrucksController(truckService);

            var response = await trucksController.FindTrucks(null, null);

            Assert.True(response.Success);
        }

        /// <summary>
        /// Evaluates that filter by day order is executed correctly..
        /// </summary>
        /// <returns>True if operation was executed succesfully. </returns>
        [Fact]
        public async Task FindTrucks_WithDayOrderFilter_ReturnsListOfTrucks()
        {
            var dictionary = new Dictionary<string, string>
            {
                { "SocrataClient:Host", "https://data.sfgov.org/resource/" },
                { "SocrataClient:Resource", "jjew-r69b.json"}
            };
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(dictionary)
                .Build();
            var socrataClient = new SocrataClient(configuration);
            var truckStore = new TruckStore(socrataClient);
            var truckService = new TruckService(truckStore);
            var trucksController = new TrucksController(truckService);

            var response = await trucksController.FindTrucks(DayOfWeek.Saturday, null);

            Assert.True(response.Success);
        }

        /// <summary>
        /// Evaluates that filter by time is executed correctly..
        /// </summary>
        /// <returns>True if operation was executed succesfully. </returns>
        [Fact]
        public async Task FindTrucks_WithTimeFilter_ReturnsListOfTrucks()
        {
            var dictionary = new Dictionary<string, string>
            {
                { "SocrataClient:Host", "https://data.sfgov.org/resource/" },
                { "SocrataClient:Resource", "jjew-r69b.json"}
            };
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(dictionary)
                .Build();
            var socrataClient = new SocrataClient(configuration);
            var truckStore = new TruckStore(socrataClient);
            var truckService = new TruckService(truckStore);
            var trucksController = new TrucksController(truckService);

            var response = await trucksController.FindTrucks(null, "16:00");

            Assert.True(response.Success);
        }

        /// <summary>
        /// Evaluates that 'time' parameter allows only values between 00:00 and 23:59.
        /// </summary>
        /// <returns>False if operation was validated succesfully. </returns>
        [Fact]
        public async Task FindTrucks_WithTimeFilter_ReturnsTimeFormatIsIncorrect()
        {
            var dictionary = new Dictionary<string, string>
            {
                { "SocrataClient:Host", "https://data.sfgov.org/resource/" },
                { "SocrataClient:Resource", "jjew-r69b.json"}
            };
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(dictionary)
                .Build();
            var socrataClient = new SocrataClient(configuration);
            var truckStore = new TruckStore(socrataClient);
            var truckService = new TruckService(truckStore);
            var trucksController = new TrucksController(truckService);

            var response = await trucksController.FindTrucks(null, "25:00");

            Assert.False(response.Success);
            Assert.Equal("Server Error: Time format is incorrect.", response.Message);
        }
    }
}
