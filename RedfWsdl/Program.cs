using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.AspNetCore;

namespace RedfWsdl
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetValue<string>("Url");

            CreateWebHostBuilder(args, connectionString).Build().SeedData().Result.Run();
        }


        public static IWebHostBuilder CreateWebHostBuilder(string[] args, string connectionString) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls(connectionString)
                .UseStartup<Startup>();

    }
}
