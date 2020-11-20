using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Uniform.Core.Entities;
using Uniform.Core.Repositories;
using Uniform.DataAccess.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Uniform.DataAccess.Repositories
{
    public class FormRepository : IFormRepository
    {
        private readonly UniformContext _db;

        public FormRepository(UniformContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public virtual async Task CreateAsync(Form form)
        {
            await _db.Forms.AddAsync(form);
        }

        public virtual async Task<IReadOnlyList<Form>> FindAsync(string request)
        {
            if (string.IsNullOrEmpty(request))
            {
                return new List<Form>();
            }
            return await _db
                .Forms
                .Where(f => f.Json.Contains(request))
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
