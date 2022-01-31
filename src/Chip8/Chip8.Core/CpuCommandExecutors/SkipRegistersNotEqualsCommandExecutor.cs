using Chip8.Core.CpuCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.CpuCommandExecutors
{
    public class SkipRegistersNotEqualsCommandExecutor : BaseExecutor<SkipRegistersNotEquals>
    {
        public override void ExecuteCommand(SkipRegistersNotEquals command, ExecutionContext context)
        {
            var x = context.Cpu.Registers[command.RegisterX];
            var y = context.Cpu.Registers[command.RegisterY];

            if (x != y)
            {
                Next(context);
            }

            Next(context);
        }
    }
}
