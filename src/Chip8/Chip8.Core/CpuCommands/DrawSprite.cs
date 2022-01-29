using Chip8.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.CpuCommands
{
    [CommandModel("D***", "DRW Vx Vy nibble")]
    public class DrawSprite
    {
        [CommandParameter("Vx", 2, 1)]
        public int RegisterX { get; set; }

        [CommandParameter("Vy", 1, 1)]
        public int RegisterY { get; set; }

        [CommandParameter("nibble", 0, 1)]
        public int Size { get; set; }
    }
}
