using Chip8.Core.CpuCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.CpuCommandExecutors
{
    public class JumpCommandExecutor : BaseExecutor<Jump>
    {
        public override void ExecuteCommand(Jump command, ExecutionContext context)
        {
            context.Cpu.PC = command.Address;
        }
    }
}
