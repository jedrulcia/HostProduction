using HostProduction.Models;
using Microsoft.Data.SqlClient.DataClassification;

namespace HostProduction.Contracts
{
	public interface IEquipmentPlacementContractsRepository
	{
		Task<List<EquipmentPlacementContractVM>> GetEquipmentPlacementContractVMsAsync();
		Task<EquipmentPlacementContractCreateVM> GetEquipmentPlacementContractCreateVMAsync();
		Task CreateEquipmentPlacementContractAsync(EquipmentPlacementContractCreateVM equipmentPlacementContractCreateVM);
		Task<decimal> GetRemainingFacilityAreaAsync(EquipmentPlacementContractCreateVM equipmentPlacementContractCreateVM);
	}
}
