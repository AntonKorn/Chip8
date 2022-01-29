using Chip8.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.CpuCommands
{
    [CommandModel("4***", "SNE Vx kk")]
    public class SkipNotEquals
    {

        [CommandParameter("Vx", 2, 1)]
        public int Register { get; set; }

        [CommandParameter("kk", 0, 2)]
        public int Value { get; set; }
    }
}
