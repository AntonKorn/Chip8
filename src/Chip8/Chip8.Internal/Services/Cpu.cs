using Chip8.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Internal.Services
{
    public class Cpu : ICpu
    {
        public int[] Registers { get; } = new int[16];

        public int SP { get; set; }
        public int PC { get; set; }
        public int I { get; set; }

        public int[] Stack { get; } = new int[16];
    }
}
