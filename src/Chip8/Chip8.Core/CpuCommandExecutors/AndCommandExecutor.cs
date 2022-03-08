using Chip8.Core.CpuCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.CpuCommandExecutors
{
    public class AndCommandExecutor : BaseExecutor<And>
    {
        public override void ExecuteCommand(And command, ExecutionContext context)
        {
            var x = context.Cpu.Registers[command.RegisterX];
            var y = context.Cpu.Registers[command.RegisterY];
            context.Cpu.Registers[command.RegisterX] = x & y;

            Next(context);
        }
    }
}
