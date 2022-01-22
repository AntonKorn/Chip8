using Chip8.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core
{
    public struct ExecutionContext
    {
        public ICpu Cpu { get; }
        public IRam Ram { get; }
        public IKeyboard Keyboard { get; }
        public ParsedCommand ParsedCommand { get; }
        public IGraphicalDeviceState GraphicalDeviceState { get; }

        public ExecutionContext(ICpu cpu, IRam ram, IKeyboard keyboard, IGraphicalDeviceState graphicalDeviceState, ParsedCommand parsedCommand)
        {
            Cpu = cpu;
            Ram = ram;
            Keyboard = keyboard;
            GraphicalDeviceState = graphicalDeviceState;
            ParsedCommand = parsedCommand;
        }
    }
}
