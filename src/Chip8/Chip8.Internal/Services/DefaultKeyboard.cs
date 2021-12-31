using Chip8.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Internal.Services
{
    public class DefaultKeyboard : IKeyboard
    {

        private int? _currentKey;

        public int? Key => _currentKey;

        public bool IsKeyPressed(int key)
        {
            return _currentKey.HasValue && _currentKey.Value == key;
        }

        public void SetKey(int key)
        {
            _currentKey = key;
        }

        public void UnsetKey()
        {
            _currentKey = null;
        }
    }
}
