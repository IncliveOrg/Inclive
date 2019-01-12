using Inclive.Domain.Common;

namespace Inclive.Domain.Entities
{
    public class Mob : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}