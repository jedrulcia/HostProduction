using AutoMapper;
using HostProduction.Contracts;
using HostProduction.Data;
using HostProduction.Models;

namespace HostProduction.Repositories
{
	public class ProcessEquipmentTypeRepository : GenericRepository<ProcessEquipmentType>, IProcessEquipmentTypeRepository
	{
		private readonly IMapper mapper;

		public ProcessEquipmentTypeRepository(ApplicationDbContext context, IMapper mapper) : base(context)
		{
			this.mapper = mapper;
		}
		public async Task<List<ProcessEquipmentTypeVM>> GetProcessEquipmentTypeIndexVMAsync()
		{
			return mapper.Map<List<ProcessEquipmentTypeVM>>(await GetAllAsync());
		}

		public async Task<ProcessEquipmentTypeVM> GetProcessEquipmentTypeVMAsync(int id)
		{
			return mapper.Map<ProcessEquipmentTypeVM>(await GetAsync(id));
		}
	}
}
