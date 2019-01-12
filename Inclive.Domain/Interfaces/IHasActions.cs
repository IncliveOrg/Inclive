using System.Collections.Generic;
using Inclive.Domain.Entities;

namespace Inclive.Domain.Interfaces
{
    public interface IHasActions
    {
        ICollection<Action> Actions { get; }
    }
}