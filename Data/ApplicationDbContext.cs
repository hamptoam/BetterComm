using BetterComm.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BetterComm.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Core Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Core Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

        }

        public DbSet<Callee> Callees { get; set; }

        public DbSet<Campaign> Campaigns { get; set; }

        public DbSet<Manager> Managers { get; set; }

        public DbSet<Employee> Employees { get; set; }


        public DbSet<Funds> Fund { get; set; }

        public DbSet<Manager> Manager { get; set; }

        public DbSet<Phone> Phone { get; set; }

        public DbSet<Funds> Funds { get; set; }

        public DbSet<CalleeCampaign> CalleeCampaigns { get; set; }

        public DbSet<CampaignEmployee> CampaignEmployees { get; set; }

        public DbSet<CampaignManager> CampaignManagers { get; set; }

        public DbSet<EmployeeCallee> EmployeeCallees { get; set; }

        public DbSet<ManagerEmployee> ManagerEmployees { get; set; }

        public DbSet<CalleeFunds> CalleeFunds { get; set; }

        public DbSet<CampaignFunds> CampaignFunds { get; set; }

        public DbSet<EmployeeFunds> EmployeeFunds { get; set; }
        
        public DbSet<Phone> Phones { get; set; }

    }
}


