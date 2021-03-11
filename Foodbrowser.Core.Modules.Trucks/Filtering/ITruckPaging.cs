namespace Foodbrowser.Core.Modules.Trucks.Filtering
{
    public interface ITruckPaging
    {
        int PageNumber { get; set; }
        int RowsPerPage { get; set; }
    }
}
