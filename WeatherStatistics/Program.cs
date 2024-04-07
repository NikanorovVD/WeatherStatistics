using Microsoft.Extensions.Configuration;
using WeatherStatistics.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WeatherStatistics.Services;

namespace WeatherStatistics
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
        }
    }
}
