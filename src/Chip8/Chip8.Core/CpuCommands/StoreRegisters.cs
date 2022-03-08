using Chip8.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.CpuCommands
{
    [CommandModel("F*55", "LD [I], Vx")]
    public class StoreRegisters
    {
        [CommandParameter("Vx", 2, 1)]
        public int MaxRegister { get; set; }

    }
}
