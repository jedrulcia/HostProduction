namespace HostProduction.Contracts
{
	public interface IGenericRepository<T> where T : class
	{
		// ADDS THE ENTITY TO THE DATABASE
		Task<T> AddAsync(T entity);

		// CHECKS IF THE ENTITY EXISTS IN THE DATABASE
		Task<bool> Exists(int id);

		// GETS THE ENTITY FROM THE DATABASE
		Task<T> GetAsync(int? id);

		// GETS ALL ENTITIES FROM THE DATABASE
		Task<List<T>> GetAllAsync();

		// UPDATES THE ENTITY IN THE DATABASE
		Task UpdateAsync(T entity);

		// DELETES THE ENTITY FROM THE DATABASE
		Task DeleteAsync(int id);
	}
}
