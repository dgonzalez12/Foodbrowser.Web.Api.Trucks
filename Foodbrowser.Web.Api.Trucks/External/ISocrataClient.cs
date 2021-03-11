namespace Foodbrowser.Web.Api.Trucks.External
{
    public interface ISocrataClient
    {
        string Host { get; }
        string Resource { get; }
    }
}
