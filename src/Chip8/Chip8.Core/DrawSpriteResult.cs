using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core
{
    public class DrawSpriteResult
    {
        public bool Erased { get; }

        public DrawSpriteResult(bool erased)
        {
            Erased = erased;
        }
    }
}
