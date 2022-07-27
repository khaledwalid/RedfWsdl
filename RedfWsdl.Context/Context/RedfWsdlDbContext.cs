using Microsoft.EntityFrameworkCore;
using RedfWsdl.Shared.Entities;

namespace RedfWsdl.Context.Context
{
    public class RedfWsdlDbContext : DbContext
    {
        public RedfWsdlDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Bank> Banks { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<CitizenProfile> CitizenProfiles { get; set; }
        public DbSet<Crm> Crm { get; set; }
        public DbSet<Determination> Determinations { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<User> Users { get; set; }


        protected override async void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}