using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core
{
    public class DrawSpriteCommand
    {
        public int X { get; }
        public int Y { get; }
        public int[] Sprite { get; }

        public DrawSpriteCommand(int x, int y, int[] sprite)
        {
            X = x;
            Y = y;
            Sprite = sprite;
        }
    }
}
