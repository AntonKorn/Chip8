using Chip8.Core.CpuCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.CpuCommandExecutors
{
    public class LoadSpriteLocationIntoIndexCommandExecutor : BaseExecutor<LoadSpriteLocationIntoIndex>
    {
        public override void ExecuteCommand(LoadSpriteLocationIntoIndex command, ExecutionContext context)
        {
            var knownSpriteIdentifier = context.Cpu.Registers[command.Register];
            var spriteOffset = context.Ram.GetCharacterSpriteOffset(knownSpriteIdentifier);
            context.Cpu.I = spriteOffset;

            Next(context);
        }
    }
}
