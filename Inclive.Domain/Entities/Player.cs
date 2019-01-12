using System.Collections.Generic;
using Inclive.Domain.Common;

namespace Inclive.Domain.Entities
{
    public class Player : IEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Character> Characters { get; private set; }

        public Player()
        {
            Characters = new HashSet<Character>();
        }
    }
}