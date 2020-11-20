using Uniform.Core.Entities.Interfaces;

namespace Uniform.Core.Entities
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
