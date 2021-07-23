using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.Contracts
{
    public interface ICpu
    {
        int[] Resgisters { get; }
        int SP { get; set; }
        int PC { get; set; }
        int I { get; set; }
        bool VF { get; set; }
        int[] Stack { get; }
    }
}
