using System;

namespace Foodbrowser.Core.Modules.Trucks.Exceptions
{
    /// <summary>
    /// Represents an error related to trucks module.
    /// </summary>
    public class TruckException : Exception
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Error message.</param>
        public TruckException(string message)
            : base(message)
        {

        }
    }
}
