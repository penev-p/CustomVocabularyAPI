using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomVocabulary.Core.Repo
{
    /// <summary>
    /// Base repository interface with general database operations
    /// </summary>
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task AddAsync(TEntity entity);
        void Remove(TEntity entity);
    }
}
