using AutoMapper;
using HostProduction.Data;
using HostProduction.Models;

namespace HostProduction.Configurations
{
	public class MapperConfig : Profile
	{
		public MapperConfig()
		{
			CreateMap<ProductionFacility, ProductionFacilityVM>()
			.ForMember(dest => dest.RemainingArea, opt => opt.MapFrom(src => src.StandardArea));
			CreateMap<ProductionFacilityVM, ProductionFacility>();
			CreateMap<ProcessEquipmentType, ProcessEquipmentTypeVM>().ReverseMap();
			CreateMap<EquipmentPlacementContract, EquipmentPlacementContractVM>().ReverseMap();
			CreateMap<EquipmentPlacementContract, EquipmentPlacementContractCreateVM>().ReverseMap();
		}
	}
}
