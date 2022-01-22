using System.Runtime.Serialization;

namespace CRAS.Medium.Plugins.External.Weather.Exceptions
{
    public class WeatherServiceException : Exception
    {
        public WeatherServiceException()
        {
        }

        public WeatherServiceException(string? message) : base(message)
        {
        }

        public WeatherServiceException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected WeatherServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
