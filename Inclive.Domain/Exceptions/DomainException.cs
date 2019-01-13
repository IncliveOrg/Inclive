using System;

namespace Inclive.Domain.Exceptions
{
    public class DomainException : Exception
    {
        internal DomainException(string message)
            : base(message)
        {
        }
    }
}