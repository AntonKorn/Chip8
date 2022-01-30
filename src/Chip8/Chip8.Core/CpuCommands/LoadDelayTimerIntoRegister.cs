using Chip8.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.CpuCommands
{
    [CommandModel("F*07", "LD Vx, DT")]
    public class LoadDelayTimerIntoRegister
    {
        [CommandParameter("Vx", 2, 1)]
        public int Register { get; set; }
    }
}
