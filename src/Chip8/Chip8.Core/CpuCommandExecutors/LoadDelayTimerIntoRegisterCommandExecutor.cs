using Chip8.Core.CpuCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.CpuCommandExecutors
{
    public class LoadDelayTimerIntoRegisterCommandExecutor : BaseExecutor<LoadDelayTimerIntoRegister>
    {
        public override void ExecuteCommand(LoadDelayTimerIntoRegister command, ExecutionContext context)
        {
            context.Cpu.Registers[command.Register] = context.Cpu.DT;
            Next(context);
        }
    }
}
