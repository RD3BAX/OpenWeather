using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
using Polly.Extensions.Http;

namespace AmberCastle.OpenWeather.TestConsole
{
    class Program
    {
        private static IHost __Hosting;

        public static IHost Hosting => __Hosting ??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        public static IServiceProvider Services => Hosting.Services;

        public static IHostBuilder CreateHostBuilder(string[] args) => Host
            .CreateDefaultBuilder(args)
            .ConfigureServices(ConfigureServices);

        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddHttpClient<OpenWeatherClient>(client =>
                {
                    var config = host.Configuration.GetSection("OpenWeatherAPI");
                    client.BaseAddress = new Uri(
                        $"{config["Schema"]}" +
                        $"{config["Address"]}" +
                        $"/");
                })
                .SetHandlerLifetime(TimeSpan.FromMinutes(5))
                .AddPolicyHandler(GetRetryPolicy())
                ;
        }

        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            var jitter = new Random();
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(6, retry_attempt =>
                    TimeSpan.FromSeconds(Math.Pow(2, retry_attempt)) +
                    TimeSpan.FromMilliseconds(jitter.Next(0, 1000)));
        }

        static async Task Main(string[] args)
        {
            using var host = Hosting;
            await host.StartAsync();

            var weather = Services.GetRequiredService<OpenWeatherClient>();

            var location = await weather.GetDirectGeocoding("Москва",10);


            var key = "ru";
            string name;
            if (location[0].LocalNames.ContainsKey(key))
            {
                name = location[0].LocalNames[key];
            }

            var reverse = await weather.GetReverseGeocoding(location[0].Latitude, location[0].Longitude);

            var zipLocal = await weather.GetCoordinatesByZip("26651");

            var weatherOneCall = await weather.GetWeatherOneCall(location[0].Latitude, location[0].Longitude);

            var timeCurrent = weatherOneCall.Current.Time.LocalDateTime;

            var timemachine =
                await weather.GetWeatherTimeMachine(location[0].Latitude, location[0].Longitude, DateTimeOffset.Now);

            Console.WriteLine("Завершено!");
            Console.ReadLine();
            await host.StopAsync();
        }
    }
}
