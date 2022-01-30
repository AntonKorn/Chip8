using Chip8.Core.CpuCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.CpuCommandExecutors
{
    public class SkipPressedCommandExecutor : BaseExecutor<SkipPressed>
    {
        public override void ExecuteCommand(SkipPressed command, ExecutionContext context)
        {
            var key = context.Cpu.Registers[command.Register];
            if (context.Keyboard.IsKeyPressed(key))
            {
                Next(context);
            }

            Next(context);
        }
    }
}
