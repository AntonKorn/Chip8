using Chip8.Core.CpuCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.CpuCommandExecutors
{
    public class AddInlineExecutor : BaseExecutor<AddInline>
    {
        public override void ExecuteCommand(AddInline command, ExecutionContext context)
        {
            var register = command.Register;
            var oldRegisterValue = context.Cpu.Registers[register];
            context.Cpu.Registers[register] = Add(command.Operand, oldRegisterValue, byte.MaxValue, out var _);
            Next(context);
        }
    }
}
