using Chip8.Core.CpuCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.CpuCommandExecutors
{
    public class StoreRegistersCommandExecutor : BaseExecutor<StoreRegisters>
    {
        public override void ExecuteCommand(StoreRegisters command, ExecutionContext context)
        {
            var initialOffset = context.Cpu.I;
            for (var i = 0; i <= command.MaxRegister; i++)
            {
                var offset = initialOffset + i;
                context.Ram.WriteByte(offset, context.Cpu.Registers[i]);
            }

            Next(context);
        }
    }
}
