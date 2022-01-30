using Chip8.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.CpuCommands
{
    [CommandModel("F*15", "LD DT, Vx")]
    public class SetDelayTimer
    {
        [CommandParameter("Vx", 2, 1)]
        public int Register { get; set; }
    }
}
