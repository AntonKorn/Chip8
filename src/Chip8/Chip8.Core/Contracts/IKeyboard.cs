using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.Contracts
{
    public interface IKeyboard
    {
        public int? Key { get; }
        public bool IsKeyPressed(int key);
        public void SetKey(int key);
        public void UnsetKey();
    }
}
