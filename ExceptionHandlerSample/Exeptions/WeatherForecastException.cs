using System;
using System.Runtime.Serialization;

namespace ExceptionHandlerSample.Exeptions
{
    public class WeatherForecastException : Exception
    {
        public WeatherForecastException()
        {
        }

        public WeatherForecastException(string message) : base(message)
        {
        }

        public WeatherForecastException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WeatherForecastException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
