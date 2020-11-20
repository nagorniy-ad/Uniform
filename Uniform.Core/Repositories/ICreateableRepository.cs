using System.Threading.Tasks;
using Uniform.Core.Entities.Interfaces;

namespace Uniform.Core.Repositories
{
    public interface ICreateableRepository<T>
        where T : class, IEntity
    {
        Task CreateAsync(T entity);
    }
}
