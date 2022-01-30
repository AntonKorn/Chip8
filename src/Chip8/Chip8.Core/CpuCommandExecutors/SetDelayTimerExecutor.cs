using Chip8.Core.CpuCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.CpuCommandExecutors
{
    public class SetDelayTimerExecutor : BaseExecutor<SetDelayTimer>
    {
        public override void ExecuteCommand(SetDelayTimer command, ExecutionContext context)
        {
            var registerValue = context.Cpu.Registers[command.Register];
            context.Cpu.DT = registerValue;
            Next(context);
        }
    }
}
