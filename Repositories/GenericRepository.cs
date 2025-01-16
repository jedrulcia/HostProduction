using Microsoft.EntityFrameworkCore;
using HostProduction.Contracts;
using HostProduction.Data;

namespace HostProduction.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;

        public GenericRepository(ApplicationDbContext context) 
        {
            this.context = context;
        }

		// ADDS THE ENTITY TO THE DATABASE
		public async Task<T> AddAsync(T entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
		}

		// CHECKS IF THE ENTITY EXISTS IN THE DATABASE
		public async Task<bool> Exists(int id)
		{
			var entity = await GetAsync(id);
			return entity != null;
		}

		// GETS THE ENTITY FROM THE DATABASE
		public async Task<T> GetAsync(int? id)
		{
			if (id == null)
			{
				return null;
			}
			return await context.Set<T>().FindAsync(id);
		}

		// GETS ALL ENTITIES FROM THE DATABASE
		public async Task<List<T>> GetAllAsync()
		{
			return await context.Set<T>().ToListAsync();
		}

		// UPDATES THE ENTITY IN THE DATABASE
		public async Task UpdateAsync(T entity)
		{
			context.Update(entity);
			await context.SaveChangesAsync();
		}

		// DELETES THE ENTITY FROM THE DATABASE
		public async Task DeleteAsync(int id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
