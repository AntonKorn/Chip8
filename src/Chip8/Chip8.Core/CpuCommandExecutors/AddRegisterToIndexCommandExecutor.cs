using Chip8.Core.CpuCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.CpuCommandExecutors
{
    public class AddRegisterToIndexCommandExecutor : BaseExecutor<AddRegisterToIndex>
    {
        public override void ExecuteCommand(AddRegisterToIndex command, ExecutionContext context)
        {
            var registerValue = context.Cpu.Registers[command.Register];
            context.Cpu.I = Add(context.Cpu.I, registerValue, ushort.MaxValue, out var _);
            Next(context);
        }
    }
}
