using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RedfWsdl.Context.Context;
using RedfWsdl.Context.Seeders;

namespace RedfWsdl
{
    public static class WebHostExtensions
    {
        public static async Task<IWebHost> SeedData(this IWebHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetService<RedfWsdlDbContext>();
            if (context == null) return host;
            // now we have the DbContext. Run migrations
            await context.Database.MigrateAsync();

            // now that the database is up to date. Let's seed
            await new Seeder(context).SeedData();


            return host;
        }
    }
}