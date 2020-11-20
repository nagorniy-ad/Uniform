using Microsoft.EntityFrameworkCore;
using Uniform.Core.Entities;

namespace Uniform.DataAccess.Context
{
    public class UniformContext : DbContext
    {
        public DbSet<Form> Forms { get; set; }

        public UniformContext(DbContextOptions<UniformContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
