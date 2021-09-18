using Chip8.Core;
using Chip8.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Internal.Services
{
    public class GraphicalDeviceState : IGraphicalDeviceState
    {
        private readonly int _spriteWidth = 8;
        private readonly int _screenWidth = 64;
        private readonly int _screenHeight = 32;
        private bool[][] _screenState;

        public GraphicalDeviceState()
        {
            _screenState = Enumerable.Repeat(0, _screenHeight).Select(_ => new bool[_screenWidth]).ToArray();
        }

        public DrawSpriteResult DrawSprite(DrawSpriteCommand drawSpriteCommand)
        {
            var isCollision = false;

            for (int i = 0; i < drawSpriteCommand.Sprite.Length; i++)
            {
                var y = (drawSpriteCommand.Y + i) % _screenHeight;

                isCollision |= DrawSpriteLine(drawSpriteCommand.Sprite[i], drawSpriteCommand.X, y);
            }

            return new DrawSpriteResult(isCollision);
        }

        public bool GetPixel(int x, int y)
        {
            return _screenState[y][x];
        }

        public bool[][] GetFullScreen()
        {
            return _screenState;
        }

        public int GetScreenHeight()
        {
            return _screenHeight;
        }

        public int GetScreenWidth()
        {
            return _screenWidth;
        }

        private bool DrawSpriteLine(int line, int left, int top)
        {
            var screenRow = _screenState[top];
            var erased = false;
            for (var i = 0; i < _spriteWidth; i++)
            {
                var bitOffset = _spriteWidth - i - 1;
                var isPixelActive = ((1 << bitOffset) & line) != 0;
                var x = (left + i) % _screenWidth;
                erased = erased || IsPixelErased(screenRow[x], isPixelActive);
                screenRow[x] ^= isPixelActive;
            }

            return erased;
        }

        private bool IsPixelErased(bool screenPixel, bool spritePixel)
        {
            return screenPixel && !(screenPixel ^ spritePixel);
        }
    }
}
