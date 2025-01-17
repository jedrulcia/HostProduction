using HostProduction.Contracts;
using HostProduction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostProduction.Test
{
	public class EquipmentPlacementContractsRepositoryStub : IEquipmentPlacementContractsRepository
	{
		public List<EquipmentPlacementContractVM> EquipmentPlacementContracts { get; set; } = new List<EquipmentPlacementContractVM>();

		public EquipmentPlacementContractCreateVM EquipmentPlacementContractCreateVM { get; set; } = new EquipmentPlacementContractCreateVM();

		public Task<List<EquipmentPlacementContractVM>> GetEquipmentPlacementContractVMsAsync()
		{
			return Task.FromResult(EquipmentPlacementContracts);
		}

		public Task<EquipmentPlacementContractCreateVM> GetEquipmentPlacementContractCreateVMAsync()
		{
			return Task.FromResult(EquipmentPlacementContractCreateVM);
		}

		public Task CreateEquipmentPlacementContractAsync(EquipmentPlacementContractCreateVM vm)
		{
			return Task.CompletedTask;
		}
	}
}
