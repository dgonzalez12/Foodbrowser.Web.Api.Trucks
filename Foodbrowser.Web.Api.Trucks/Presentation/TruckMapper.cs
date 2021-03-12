using AutoMapper;
using Foodbrowser.Web.Api.Trucks.Definition;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foodbrowser.Web.Api.Trucks.Presentation
{
    /// <summary>
    /// Transforms a truck object in a view and viceversa.
    /// </summary>
    public class TruckMapper
    {
        /// <summary>
        /// Gets a view of truck object.
        /// </summary>
        /// <param name="trucks">Truck object to convert.</param>
        /// <returns></returns>
        public static async Task<ICollection<TruckView>> ToViews(ICollection<Truck> trucks)
        {
            return await Task.Run(() =>
            {
                var config = new MapperConfiguration(c =>
                {
                    c.CreateMap<Truck, TruckView>();
                });
                var mapper = config.CreateMapper();
                var truckViews = mapper.Map<ICollection<TruckView>>(trucks);
                return truckViews;
            });
        }
    }
}
