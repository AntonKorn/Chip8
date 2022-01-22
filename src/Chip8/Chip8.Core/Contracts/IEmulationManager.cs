using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.Contracts
{
    public interface IEmulationManager
    {
        void Initialize();
        void LoadRom(byte[] rom);
        bool TryExecuteNext();
    }
}
