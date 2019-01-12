using Inclive.Domain.Common;
using Inclive.Domain.Enums;

namespace Inclive.Domain.Entities
{
    public class Character : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SexType Sex { get; set; }
    }
}