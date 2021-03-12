using Foodbrowser.Web.Api.Trucks.Controllers;
using Foodbrowser.Web.Api.Trucks.External;
using Foodbrowser.Web.Api.Trucks.Persistence;
using Foodbrowser.Web.Api.Trucks.Presentation;
using Foodbrowser.Web.Api.Trucks.Servicing;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace Foodbrowser.Web.Api.Trucks.Test
{
    public class TrucksApiTest
    {
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

            var response = await trucksController.FindTrucks(null);

            Assert.True(response.Success);
        }

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

            var response = await trucksController.FindTrucks(new TruckFilterView { DayOfWeek = DayOfWeek.Saturday });

            Assert.True(response.Success);
        }

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

            var response = await trucksController.FindTrucks(new TruckFilterView { Time = "16:00" });

            Assert.True(response.Success);
        }

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

            var response = await trucksController.FindTrucks(new TruckFilterView { Time = "25:00" });

            Assert.False(response.Success);
            Assert.Equal("Server Error: Time format is incorrect.", response.Message);
        }

        [Fact]
        public async Task FindTrucks_WithPagination_ReturnsListOfTrucks()
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

            var response = await trucksController.FindTrucks(new TruckFilterView
            {
                Paging = new TruckPagingView
                {
                    PageNumber = 1,
                    RowsPerPage = 10
                }
            });

            Assert.True(response.Success);
            Assert.InRange(response.Obj.Count, 0, 10);
        }
    }
}
