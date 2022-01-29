using Chip8.Core.CpuCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.CpuCommandExecutors
{
    public class LoadRegisterValueCommandExecutor : BaseExecutor<LoadRegister>
    {
        public override void ExecuteCommand(LoadRegister command, ExecutionContext context)
        {
            var register = command.Register;
            context.Cpu.Registers[register] = command.Value;
            Next(context);
        }
    }
}
