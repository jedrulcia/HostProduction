using HostProduction.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HostProduction.Configurations.Entities
{
	public class ProductionFacilitySeedConfiguration : IEntityTypeConfiguration<ProductionFacility>
	{
		public void Configure(EntityTypeBuilder<ProductionFacility> builder)
		{
			builder.HasData(
				new ProductionFacility { Id = 1, Code = "FAC001", Name = "Factory A", StandardArea = 1000.0m },
				new ProductionFacility { Id = 2, Code = "FAC002", Name = "Factory B", StandardArea = 1500.0m },
				new ProductionFacility { Id = 3, Code = "FAC003", Name = "Factory C", StandardArea = 1200.0m },
				new ProductionFacility { Id = 4, Code = "FAC004", Name = "Factory D", StandardArea = 2000.0m },
				new ProductionFacility { Id = 5, Code = "FAC005", Name = "Factory E", StandardArea = 1800.0m },
				new ProductionFacility { Id = 6, Code = "FAC006", Name = "Factory F", StandardArea = 2500.0m },
				new ProductionFacility { Id = 7, Code = "FAC007", Name = "Factory G", StandardArea = 3000.0m },
				new ProductionFacility { Id = 8, Code = "FAC008", Name = "Factory H", StandardArea = 3200.0m },
				new ProductionFacility { Id = 9, Code = "FAC009", Name = "Factory I", StandardArea = 2800.0m },
				new ProductionFacility { Id = 10, Code = "FAC010", Name = "Factory J", StandardArea = 3500.0m }
			);
		}
	}
}
