namespace Foodbrowser.Core.Modules.Trucks.Filtering
{
    public interface ITruckFilter<TPaging> : ITruckFilter
        where TPaging : class, ITruckPaging
    {
        TPaging Paging { get; set; }
    }
}
