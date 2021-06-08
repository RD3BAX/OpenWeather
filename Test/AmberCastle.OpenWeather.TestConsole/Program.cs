using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
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
                client.BaseAddress = new Uri(host.Configuration["OpenWeather:Http"]))
                .SetHandlerLifetime(TimeSpan.FromMinutes(5))
                .AddPolicyHandler(GetRetryPolicy())
                ;
            //Services.GetRequiredService<OpenWeatherClient>().ApiKey = host.Configuration["OpenWeather:ApiKey"];
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

            var location = await weather.GetDirectGeocoding("Moscow",10);


            var key = "ru";
            string name;
            if (location[0].LocalNames.ContainsKey(key))
            {
                name = location[0].LocalNames[key];
            }

            var reverse = await weather.GetReverseGeocoding(location[0].Latitude, location[0].Longitude);

            var zipLocal = await weather.GetCoordinatesByZip("26651");

            Console.WriteLine("Завершено!");
            Console.ReadLine();
            await host.StopAsync();
        }
    }
}
