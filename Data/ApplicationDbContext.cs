using HostProduction.Configurations.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HostProduction.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

		protected override void OnModelCreating(ModelBuilder builder)
		{
            builder.Entity<ProductionFacility>()
                .HasIndex(p => p.Code)
                .IsUnique();

            builder.Entity<ProcessEquipmentType>()
                .HasIndex(p => p.Code)
                .IsUnique();

            builder.ApplyConfiguration(new ProductionFacilitySeedConfiguration());
            builder.ApplyConfiguration(new ProcessEquipmentTypeSeedConfiguration());


			base.OnModelCreating(builder);
		}

		public DbSet<ProductionFacility> ProductionFacilities { get; set; }
        public DbSet<ProcessEquipmentType> ProcessEquipmentTypes { get; set; }
        public EquipmentPlacementContract EquipmentPlacementContracts { get; set; }
    }
}
