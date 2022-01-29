using Chip8.Core.CpuCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.CpuCommandExecutors
{
    public class LoadIndexCommandExecutor : BaseExecutor<LoadIndex>
    {
        public override void ExecuteCommand(LoadIndex command, ExecutionContext context)
        {
            context.Cpu.I = command.Address;
            Next(context);
        }
    }
}
