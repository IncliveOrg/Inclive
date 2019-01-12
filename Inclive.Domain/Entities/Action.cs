using Inclive.Domain.Common;
using Inclive.Domain.Enums;

namespace Inclive.Domain.Entities
{
    public abstract class Action : IEntity
    {
        public int Id { get; set; }
        public ActionType Type { get; set; }
        public int ActionDataSourceId { get; set; }
    }
}