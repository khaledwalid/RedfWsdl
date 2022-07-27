using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace RedfWsdl.Context.Context
{
    public class DesignTimeDbContextFactory :
        IDesignTimeDbContextFactory<RedfWsdlDbContext>
    {
        public RedfWsdlDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<RedfWsdlDbContext>();
            var connectionString = configuration.GetConnectionString("RedfWsdl");
            builder.UseSqlServer(connectionString);
            return new RedfWsdlDbContext(builder.Options);
        }

    }
}