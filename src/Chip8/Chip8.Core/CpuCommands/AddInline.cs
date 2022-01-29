using Chip8.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.CpuCommands
{
    [CommandModel("7***", "ADD Vx, kk")]
    public class AddInline
    {
        [CommandParameter("Vx", 2, 1)]
        public int Register { get; set; }

        [CommandParameter("kk", 0, 2)]
        public int Operand { get; set; }
    }
}
