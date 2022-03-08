using Chip8.Core.CpuCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.CpuCommandExecutors
{
    public class StoreBcdCommandExecutor : BaseExecutor<StoreBcd>
    {
        private const int MaxDecimalPlace = 3;

        public override void ExecuteCommand(StoreBcd command, ExecutionContext context)
        {
            var argument = context.Cpu.Registers[command.Register];
            var rounder = 10;

            for (var i = 0; i < MaxDecimalPlace; i++)
            {
                var location = context.Cpu.I + (MaxDecimalPlace - i - 1);
                var decimalPlaceValue = argument % rounder;
                context.Ram.WriteByte(location, decimalPlaceValue);
                argument /= rounder;
            }

            Next(context);
        }
    }
}
