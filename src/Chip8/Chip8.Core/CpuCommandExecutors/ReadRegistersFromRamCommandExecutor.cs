using Chip8.Core.CpuCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.CpuCommandExecutors
{
    public class ReadRegistersFromRamCommandExecutor : BaseExecutor<ReadRegistersFromRam>
    {
        public override void ExecuteCommand(ReadRegistersFromRam command, ExecutionContext context)
        {
            var initialOffset = context.Cpu.I;
            for (var i = 0; i <= command.MaxRegister; i++)
            {
                var offset = initialOffset + i;
                var registerValue = context.Ram.ReadByte(offset);
                context.Cpu.Registers[i] = registerValue;
            }

            Next(context);
        }
    }
}
