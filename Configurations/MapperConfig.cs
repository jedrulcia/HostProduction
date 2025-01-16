using AutoMapper;
using HostProduction.Data;
using HostProduction.Models;

namespace HostProduction.Configurations
{
	public class MapperConfig : Profile
	{
		public MapperConfig()
		{
			CreateMap<ProductionFacility, ProductionFacilityVM>().ReverseMap();
			CreateMap<ProcessEquipmentType, ProcessEquipmentTypeVM>().ReverseMap();
			CreateMap<EquipmentPlacementContract, EquipmentPlacementContractVM>().ReverseMap();
		}
	}
}
