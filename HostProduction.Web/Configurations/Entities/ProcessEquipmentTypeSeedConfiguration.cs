using HostProduction.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HostProduction.Configurations.Entities
{
	public class ProcessEquipmentTypeSeedConfiguration : IEntityTypeConfiguration<ProcessEquipmentType>
	{
		public void Configure(EntityTypeBuilder<ProcessEquipmentType> builder)
		{
			builder.HasData(
				new ProcessEquipmentType { Id = 1, Code = "EQP001", Name = "Conveyor Belt", Area = 15.0m },
				new ProcessEquipmentType { Id = 2, Code = "EQP002", Name = "Mixer", Area = 10.0m },
				new ProcessEquipmentType { Id = 3, Code = "EQP003", Name = "Furnace", Area = 30.0m },
				new ProcessEquipmentType { Id = 4, Code = "EQP004", Name = "Press Machine", Area = 25.0m },
				new ProcessEquipmentType { Id = 5, Code = "EQP005", Name = "Cutter", Area = 12.0m },
				new ProcessEquipmentType { Id = 6, Code = "EQP006", Name = "Packaging Machine", Area = 18.0m },
				new ProcessEquipmentType { Id = 7, Code = "EQP007", Name = "Drilling Machine", Area = 16.5m },
				new ProcessEquipmentType { Id = 8, Code = "EQP008", Name = "Welding Robot", Area = 22.0m },
				new ProcessEquipmentType { Id = 9, Code = "EQP009", Name = "Injection Molding Machine", Area = 27.0m },
				new ProcessEquipmentType { Id = 10, Code = "EQP010", Name = "Heat Exchanger", Area = 23.0m }
			);
		}
	}
}
