using System.Collections.Generic;
using Inclive.Domain.Common;

namespace Inclive.Domain.ValueObjects
{
    public class Probability : ValueObject
    {
        public int Value { get; }

        public Probability(int value)
        {
            if (value < 0)
                value = 0;
            if (value > 100)
                value = 100;
            Value = value;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}