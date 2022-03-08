using Chip8.Core.Attributes;

namespace Chip8.Core.CpuCommands
{
    [CommandModel("F*29", "LD I, sprite(Vx)")]
    public class LoadSpriteLocationIntoIndex
    {
        [CommandParameter("Vx", 2, 1)]
        public int Register { get; set; }
    }
}
