using System.Collections.Generic;
using Inclive.Domain.ValueObjects;

namespace Inclive.Domain.Entities.ActionDataSources
{
    public class WalkingActionDataSource : ActionDataSource
    {
        public IDictionary<Mob, Probability> MobMeetingProbabilities { get; private set; }

        public WalkingActionDataSource()
        {
            MobMeetingProbabilities = new Dictionary<Mob, Probability>();
        }
    }
}