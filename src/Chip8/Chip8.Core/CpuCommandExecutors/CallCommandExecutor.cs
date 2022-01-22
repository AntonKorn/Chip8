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
            var sp = context.Cpu.SP++;
            context.Cpu.Stack[sp] = context.Cpu.PC;
            context.Cpu.PC = command.Address;
        }
    }
}
