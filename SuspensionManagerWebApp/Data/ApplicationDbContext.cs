using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SuspensionManagerWebApp.Models;

namespace SuspensionManagerWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<SusElement> SusElements { get; set; }
        //public DbSet<Setting> Settings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Setting>()
                .HasDiscriminator<string>("SettingType")
                .HasValue<AirShockSetting>("AirShockSetting")
                .HasValue<AirForkSetting>("AirForkSetting")
                .HasValue<CoilForkSetting>("CoilForkSetting")
                .HasValue<CoilShockSetting>("CoilShockSetting");
            base.OnModelCreating(builder);
   
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}