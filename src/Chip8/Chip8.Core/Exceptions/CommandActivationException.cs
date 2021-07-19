using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.Exceptions
{
    public class CommandActivationException : Exception
    {
        public CommandActivationException(string? message) : base(message)
        {
        }
        public CommandActivationException(string? message, Exception exception) : base(message, exception)
        {
        }
    }
}
