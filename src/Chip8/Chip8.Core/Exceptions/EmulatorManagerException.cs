using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.Exceptions
{
    public class EmulatorManagerException : Exception
    {
        public EmulatorManagerException(string? message) : base(message)
        {
        }

        public EmulatorManagerException(string? message, Exception e) : base(message, e)
        {
        }
    }
}
