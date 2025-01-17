using Microsoft.EntityFrameworkCore;
using HostProduction.Contracts;
using HostProduction.Data;

namespace HostProduction.Repositories
{
	public class GenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;

        public GenericRepository(ApplicationDbContext context) 
        {
            this.context = context;
        }

		// ADDS THE ENTITY TO THE DATABASE
		protected async Task<T> AddAsync(T entity)
		{
			await context.AddAsync(entity);
			await context.SaveChangesAsync();
			return entity;
		}

		// GETS THE ENTITY FROM THE DATABASE
		protected async Task<T> GetAsync(int? id)
		{
			if (id == null)
			{
				return null;
			}
			return await context.Set<T>().FindAsync(id);
		}

		// GETS ALL ENTITIES FROM THE DATABASE
		protected async Task<List<T>> GetAllAsync()
		{
			return await context.Set<T>().ToListAsync();
		}
	}
}
