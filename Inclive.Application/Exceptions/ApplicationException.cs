using System;

namespace Inclive.Application.Exceptions
{
    public class ApplicationException : Exception
    {
        internal ApplicationException(string message)
            : base(message)
        {
        }
    }
}