using Chip8.Core.CpuCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.CpuCommandExecutors
{
    public class SkipNotPressedCommandExecutor : BaseExecutor<SkipNotPressed>
    {
        public override void ExecuteCommand(SkipNotPressed command, ExecutionContext context)
        {
            var key = context.Cpu.Registers[command.Register];
            if (!context.Keyboard.IsKeyPressed(key))
            {
                Next(context);
            }

            Next(context);
        }
    }
}
