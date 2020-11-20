using System;
using System.Threading.Tasks;
using Uniform.Core.Repositories;
using Uniform.DataAccess.Context;

namespace Uniform.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UniformContext _db;

        public IFormRepository Forms { get; }

        public UnitOfWork(UniformContext db, IFormRepository forms)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            Forms = forms ?? throw new ArgumentNullException(nameof(forms));
        }

        public Task SaveChangesAsync()
        {
            return _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
        }
    }
}
