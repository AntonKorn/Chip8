using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core
{
    public interface ICommandParameterModel
    {
        string Code { get; }

        int NibbleIndex { get; }

        int NibblesCount { get; }
    }
}
