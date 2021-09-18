using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.Contracts
{
    public interface IGraphicalDeviceState
    {
        int GetScreenWidth();
        int GetScreenHeight();
        bool GetPixel(int x, int y);
        DrawSpriteResult DrawSprite(DrawSpriteCommand drawSpriteCommand);
    }
}
