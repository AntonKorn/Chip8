using Chip8.Core.CpuCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.CpuCommandExecutors
{
    public class ReturnCommandExecutor : BaseExecutor<Return>
    {
        public override void ExecuteCommand(Return command, ExecutionContext context)
        {
            var retProgramm = Pop(context);
            context.Cpu.PC = retProgramm;
        }
    }
}
