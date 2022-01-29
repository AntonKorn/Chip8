using Chip8.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.CpuCommands
{

    [CommandModel("6***", "LD Vx k")]
    public class LoadRegister
    {
        [CommandParameter("Vx", 2, 1)]
        public int Register { get; set; }

        [CommandParameter("k", 0, 2)]
        public int Value { get; set; }
    }
}
