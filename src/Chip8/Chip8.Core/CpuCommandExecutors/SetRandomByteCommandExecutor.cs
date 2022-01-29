using Chip8.Core.CpuCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.CpuCommandExecutors
{
    public class SetRandomByteCommandExecutor : BaseExecutor<SetRandomByte>
    {
        private readonly Random _random = new();

        public override void ExecuteCommand(SetRandomByte command, ExecutionContext context)
        {
            var random = _random.Next(0, byte.MaxValue);
            var masked = random & command.Mask;
            context.Cpu.Registers[command.Register] = masked;
            Next(context);
        }
    }
}
