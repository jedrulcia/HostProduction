using HostProduction.Contracts;
using HostProduction.Data;
using HostProduction.Models;

namespace HostProduction.Repositories
{
	public class EquipmentPlacementContractsRepository : GenericRepository<EquipmentPlacementContract>, IEquipmentPlacementContractsRepository
	{
		public EquipmentPlacementContractsRepository(ApplicationDbContext context) : base(context)
		{

		}

		public Task CreateEquipmentPlacementContractAsync(EquipmentPlacementContractVM equipmentPlacementContractVM)
		{
			throw new NotImplementedException();
		}

		public Task<List<EquipmentPlacementContractVM>> GetEquipmentPlacementContractVMsAsync()
		{
			throw new NotImplementedException();
		}
	}
}
