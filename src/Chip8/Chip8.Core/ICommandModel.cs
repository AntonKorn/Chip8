using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core
{
    public interface ICommandModel
    {
        string Pattern { get; }
        string OpcodeName { get; }
    }
}
