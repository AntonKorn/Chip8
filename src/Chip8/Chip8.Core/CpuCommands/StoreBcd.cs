using Chip8.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.CpuCommands
{
    [CommandModel("F*33", "LD_BCD [I], Vx")]
    public class StoreBcd
    {
        [CommandParameter("Vx", 2, 1)]
        public int Register { get; set; }
    }
}
