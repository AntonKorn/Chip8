using Chip8.Core.CpuCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.CpuCommandExecutors
{
    public class SkipNotEqualsCommandExecutor : BaseExecutor<SkipNotEquals>
    {
        public override void ExecuteCommand(SkipNotEquals command, ExecutionContext context)
        {
            var registerValue = context.Cpu.Registers[command.Register];
            if (registerValue != command.Value)
            {
                Next(context);
            }

            Next(context);
        }
    }
}
