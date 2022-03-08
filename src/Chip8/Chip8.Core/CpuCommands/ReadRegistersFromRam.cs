using Chip8.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.CpuCommands
{
    [CommandModel("F*65", "LD Vx, [I]")]
    public class ReadRegistersFromRam
    {
        [CommandParameter("Vx", 2, 1)]
        public int MaxRegister { get; set; }
    }
}
