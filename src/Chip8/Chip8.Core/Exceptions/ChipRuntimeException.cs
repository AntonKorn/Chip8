using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.Exceptions
{
    public class ChipRuntimeException : Exception
    {
        public ChipRuntimeException(string? message) : base(message)
        {
        }

        public ChipRuntimeException(string? message, Exception e) : base(message, e)
        {
        }
    }
}
