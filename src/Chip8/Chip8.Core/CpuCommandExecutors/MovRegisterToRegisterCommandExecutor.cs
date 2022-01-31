using Chip8.Core.CpuCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.CpuCommandExecutors
{
    public class MovRegisterToRegisterCommandExecutor : BaseExecutor<MovRegisterToRegister>
    {
        public override void ExecuteCommand(MovRegisterToRegister command, ExecutionContext context)
        {
            var value = context.Cpu.Registers[command.SourceRegister];
            context.Cpu.Registers[command.DestinationRegoster] = value;
            Next(context);
        }
    }
}
