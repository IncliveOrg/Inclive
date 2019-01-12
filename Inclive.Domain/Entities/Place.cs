using System.Collections.Generic;
using Inclive.Domain.Common;
using Inclive.Domain.Enums;
using Inclive.Domain.Interfaces;

namespace Inclive.Domain.Entities
{
    public class Place : IEntity, IHasActions
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentPlaceId { get; set; }
        public ICollection<Place> SubPlaces { get; private set; }
        public ICollection<Npc> Npcs { get; private set; }
        public ICollection<Action> Actions { get; private set; }

        public Place()
        {
            SubPlaces = new HashSet<Place>();
            Npcs = new HashSet<Npc>();
            Actions = new HashSet<Action>();
        }
    }
}