using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.Exceptions
{
    public class CommandsInitializationException : Exception
    {
        public Type? CommandModelType { get; }

        public CommandsInitializationException(string? message) : base(message)
        {
        }

        public CommandsInitializationException(string? message, Type commandModelType) : base(message)
        {
            CommandModelType = commandModelType;
        }
    }
}
