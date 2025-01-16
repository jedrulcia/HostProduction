using AutoMapper;
using HostProduction.Data;
using HostProduction.Models;

namespace HostProduction.Contracts
{
	public interface IProcessEquipmentTypeRepository
	{
		Task<List<ProcessEquipmentTypeVM>> GetProcessEquipmentTypeIndexVMAsync();

		Task<ProcessEquipmentTypeVM> GetProcessEquipmentTypeVMAsync(int id);
	}
}
