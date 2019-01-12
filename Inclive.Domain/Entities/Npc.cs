using System.Collections.Generic;
using Inclive.Domain.Common;
using Inclive.Domain.Interfaces;

namespace Inclive.Domain.Entities
{
    public class Npc : IEntity, IHasActions
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Action> Actions { get; private set; }

        public Npc()
        {
            Actions = new HashSet<Action>();
        }
    }
}