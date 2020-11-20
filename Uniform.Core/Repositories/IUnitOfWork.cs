using System;
using System.Threading.Tasks;

namespace Uniform.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IFormRepository Forms { get; }
        Task SaveChangesAsync();
    }
}
