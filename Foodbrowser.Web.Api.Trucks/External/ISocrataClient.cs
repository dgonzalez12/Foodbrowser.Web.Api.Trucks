namespace Foodbrowser.Web.Api.Trucks.External
{
    /// <summary>
    /// Represents a socrata client.
    /// </summary>
    public interface ISocrataClient
    {
        /// <summary>
        /// Host.
        /// </summary>
        string Host { get; }
        /// <summary>
        /// Resource.
        /// </summary>
        string Resource { get; }
    }
}
