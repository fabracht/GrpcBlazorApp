using System;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace GrpcBlazorApp.Shared
{
    public class WeatherService : WeatherForecasts.WeatherForecastsBase
    {
        private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        public override Task<WeatherReply> GetWeather(WeatherForecast request, ServerCallContext context)
        {
            var reply = new WeatherReply();
            var rng = new Random();

            reply.Forecasts.Add(Enumerable.Range(1, 100).Select(index => new WeatherForecast()
            {
                DateTimeStamp = new Timestamp() { Seconds = DateTime.Now.AddDays(index).Second },
                TemperatureC = rng.Next(20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }));


            return Task.FromResult(reply);
        }
    }
}
