using AutoMapper;
using Foodbrowser.Web.Api.Trucks.Definition;
using System.Collections.Generic;

namespace Foodbrowser.Web.Api.Trucks.Presentation
{
    public class TruckMapper
    {
        public static Truck ToTruck(TruckView truckView)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<TruckView, Truck>();
            });
            var mapper = config.CreateMapper();
            var truck = mapper.Map<Truck>(truckView);
            return truck;
        }

        public static ICollection<Truck> ToTrucks(ICollection<TruckView> truckViews)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<TruckView, Truck>();
            });
            var mapper = config.CreateMapper();
            var trucks = mapper.Map<ICollection<Truck>>(truckViews);
            return trucks;
        }

        public static TruckView ToView(Truck truck)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Truck, TruckView>();
            });
            var mapper = config.CreateMapper();
            var truckView = mapper.Map<TruckView>(truck);
            return truckView;
        }

        public static ICollection<TruckView> ToViews(ICollection<Truck> trucks)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Truck, TruckView>();
            });
            var mapper = config.CreateMapper();
            var truckViews = mapper.Map<ICollection<TruckView>>(trucks);
            return truckViews;
        }
    }
}
