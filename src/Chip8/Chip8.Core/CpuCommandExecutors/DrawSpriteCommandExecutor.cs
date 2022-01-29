using Chip8.Core.CpuCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.CpuCommandExecutors
{
    public class DrawSpriteCommandExecutor : BaseExecutor<DrawSprite>
    {
        public override void ExecuteCommand(DrawSprite command, ExecutionContext context)
        {
            var x = context.Cpu.Registers[command.RegisterX];
            var y = context.Cpu.Registers[command.RegisterY];
            var spriteAddress = context.Cpu.I;
            var sprite = context.Ram.ReadBytes(spriteAddress, command.Size);

            var drawCommand = new DrawSpriteCommand(x, y, sprite.Select(i => (int)i).ToArray());
            context.GraphicalDeviceState.DrawSprite(drawCommand);
            Next(context);
        }
    }
}
