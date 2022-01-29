using Chip8.Core.CpuCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.CpuCommandExecutors
{
    public class CallCommandExecutor : BaseExecutor<Call>
    {
        public override void ExecuteCommand(Call command, ExecutionContext context)
        {
            Push(context, context.Cpu.PC + 2);
            context.Cpu.PC = command.Address;
        }
    }
}
