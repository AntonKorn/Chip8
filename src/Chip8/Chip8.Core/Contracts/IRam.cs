using Chip8.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.Contracts
{
    public interface IRam
    {
        int ExecutionOffset { get; }
        int ExecutionTop { get; }

        void Initialize(byte[] image);
        int Read(int offset, RamReadScale ramReadSize);
        int[] Read(int offset, int count, RamReadScale ramReadSize);
        ushort ReadWord(int offset);
        ushort[] ReadWords(int offset, int count);
        byte ReadByte(int offset);
        byte[] ReadBytes(int offset, int count);
        void WriteByte(int offset, int payload);
        void WriteBytes(int offset, int[] payload);
        int GetCharacterSpriteOffset(int spriteIndex);
    }
}
