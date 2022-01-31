using Chip8.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.CpuCommands
{
    [CommandModel("9**0", "SNE Vx, Vy")]
    public class SkipRegistersNotEquals
    {
        [CommandParameter("Vx", 2, 1)]
        public int RegisterX { get; set; }

        [CommandParameter("Vy", 1, 1)]
        public int RegisterY { get; set; }
    }
}
