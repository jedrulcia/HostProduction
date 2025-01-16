using AutoMapper;
using HostProduction.Contracts;
using HostProduction.Data;
using HostProduction.Models;

namespace HostProduction.Repositories
{
	public class ProductionFacilityRepository : GenericRepository<ProductionFacility>, IProductionFacilityRepository
	{
		private readonly IMapper mapper;

		public ProductionFacilityRepository(ApplicationDbContext context, IMapper mapper) : base(context)
		{
			this.mapper = mapper;
		}

		public async Task<List<ProductionFacilityVM>> GetProductionFacilityIndexVMAsync()
		{
			return mapper.Map<List<ProductionFacilityVM>>(await GetAllAsync());
		}

		public async Task<ProductionFacilityVM> GetProductionFacilityVMAsync(int id)
		{
			return mapper.Map<ProductionFacilityVM>(await GetAsync(id));
		}
	}
}
