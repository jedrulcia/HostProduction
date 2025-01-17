using AutoMapper;
using HostProduction.Data;
using HostProduction.Models;

namespace HostProduction.Contracts
{
	public interface IProductionFacilityRepository
	{
		Task<List<ProductionFacilityVM>> GetProductionFacilityVMsAsync();
		Task<ProductionFacilityVM> GetProductionFacilityVMAsync(int id);
	}
}
