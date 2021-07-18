using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.Exceptions
{
    public class CommandParseException : Exception
    {
        public CommandParseException(string? message) : base(message)
        {
        }

    }
}
