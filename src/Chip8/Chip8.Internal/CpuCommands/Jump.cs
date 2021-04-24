using Chip8.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Internal.CpuCommands
{
    [Command("0***", "SYS")]
    public class Jump
    {
        [CommandParameter("addr", 0, 3)]
        public int Address { get; set; }
    }
}
