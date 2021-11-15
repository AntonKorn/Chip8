using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.Exceptions
{
    public class RamException : Exception
    {
        public RamException(string? message) : base(message)
        {
        }
        public RamException(string? message, Exception exception) : base(message, exception)
        {
        }
    }
}
