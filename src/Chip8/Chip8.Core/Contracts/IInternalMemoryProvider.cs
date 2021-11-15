using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.Contracts
{
    public interface IInternalMemoryProvider
    {
        void Initialize();
        byte[] GetPredefinedSymbolSprite(int symbolIndex);
    }
}
