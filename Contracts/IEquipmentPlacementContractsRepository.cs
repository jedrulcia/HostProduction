using HostProduction.Models;

namespace HostProduction.Contracts
{
	public interface IEquipmentPlacementContractsRepository
	{
		Task<List<EquipmentPlacementContractVM>> GetEquipmentPlacementContractVMsAsync();
		Task CreateEquipmentPlacementContractAsync(EquipmentPlacementContractVM equipmentPlacementContractVM);
	}
}
