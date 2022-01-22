using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.Exceptions
{
    public class ExecutorProviderException : Exception
    {
        public ExecutorProviderException(string? message) : base(message)
        {
        }

        public ExecutorProviderException(string? message, Exception e) : base(message, e)
        {
        }
    }
}
