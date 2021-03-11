using Foodbrowser.Core.Modules.Trucks.Filtering;

namespace Foodbrowser.Web.Api.Trucks.Filtering
{
    public class TruckPaging : ITruckPaging
    {
        public int PageNumber { get; set; }
        public int RowsPerPage { get; set; }
    }
}
