using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.Exceptions
{
    public class InternalMemoryProviderException : Exception
    {
        public InternalMemoryProviderException(string? message) : base(message)
        {
        }
        public InternalMemoryProviderException(string? message, Exception exception) : base(message, exception)
        {
        }
    }
}
