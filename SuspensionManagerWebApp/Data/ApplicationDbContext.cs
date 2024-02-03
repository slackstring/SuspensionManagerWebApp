using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SuspensionManagerWebApp.Models;

namespace SuspensionManagerWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<SusElement> SusElements { get; set; }
        public DbSet<AirForkSetting> AirForkSettings { get; set; }
        public DbSet<AirShockSetting> AirShockSettings { get; set; }
        public DbSet<CoilShockSetting> CoilShockSettings { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}