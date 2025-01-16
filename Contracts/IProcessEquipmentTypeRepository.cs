using AutoMapper;
using HostProduction.Data;
using HostProduction.Models;

namespace HostProduction.Contracts
{
	public interface IProcessEquipmentTypeRepository
	{
		Task<List<ProcessEquipmentTypeVM>> GetProcessEquipmentTypeVMsAsync();
		Task<ProcessEquipmentTypeVM> GetProcessEquipmentTypeVMAsync(int id);
	}
}
