using AutoMapper;
using HostProduction.Data;
using HostProduction.Models;

namespace HostProduction.Contracts
{
	public interface IProductionFacilityRepository
	{
		Task<List<ProductionFacilityVM>> GetProductionFacilityIndexVMAsync();
		Task<ProductionFacilityVM> GetProductionFacilityVMAsync(int id);
	}
}
