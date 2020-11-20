using System.Collections.Generic;
using System.Threading.Tasks;
using Uniform.Core.Entities.Interfaces;

namespace Uniform.Core.Repositories
{
    public interface IFindableRepository<T>
        where T : class, IEntity
    {
        Task<IReadOnlyList<T>> FindAsync(string request);
    }
}
