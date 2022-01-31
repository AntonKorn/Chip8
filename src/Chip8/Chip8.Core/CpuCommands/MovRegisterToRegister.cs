using Chip8.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.CpuCommands
{
    [CommandModel("8**0", "LD Vx, Vy")]
    public class MovRegisterToRegister
    {
        [CommandParameter("Vx", 2, 1)]
        public int DestinationRegoster { get; set; }

        [CommandParameter("Vy", 1, 1)]
        public int SourceRegister { get; set; }
    }
}
