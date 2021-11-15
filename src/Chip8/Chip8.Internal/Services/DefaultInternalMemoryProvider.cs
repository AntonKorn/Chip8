using Chip8.Core.Contracts;
using Chip8.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Internal.Services
{
    public class DefaultInternalMemoryProvider : IInternalMemoryProvider
    {
        private bool _initialized;
        private byte[][] _sprites = new byte[][]
        {
            new byte[] { 0xF0, 0x90, 0x90, 0x90, 0xF0 },
            new byte[] { 0x20, 0x60, 0x20, 0x20, 0x70 },
            new byte[] { 0xF0, 0x10, 0xF0, 0x80, 0xF0 },
            new byte[] { 0xF0, 0x10, 0xF0, 0x10, 0xF0 },
            new byte[] { 0x90, 0x90, 0xF0, 0x10, 0x10 },
            new byte[] { 0xF0, 0x80, 0xF0, 0x10, 0xF0 },
            new byte[] { 0xF0, 0x80, 0xF0, 0x90, 0xF0 },
            new byte[] { 0xF0, 0x10, 0x20, 0x40, 0x40 },
            new byte[] { 0xF0, 0x90, 0xF0, 0x90, 0xF0 },
            new byte[] { 0xF0, 0x90, 0xF0, 0x10, 0xF0 },
            new byte[] { 0xF0, 0x90, 0xF0, 0x90, 0x90 },
            new byte[] { 0xE0, 0x90, 0xE0, 0x90, 0xE0 },
            new byte[] { 0xF0, 0x80, 0x80, 0x80, 0xF0 },
            new byte[] { 0xE0, 0x90, 0x90, 0x90, 0xE0 },
            new byte[] { 0xF0, 0x80, 0xF0, 0x80, 0xF0 },
            new byte[] { 0xF0, 0x80, 0xF0, 0x80, 0x80 }
        };

        public void Initialize()
        {
            _initialized = true;
        }

        public byte[] GetPredefinedSymbolSprite(int symbolIndex)
        {
            ThrowIfNoInitialized();
            ValidateIndex(symbolIndex);
            return _sprites[symbolIndex];
        }

        private void ThrowIfNoInitialized()
        {
            if (!_initialized)
            {
                throw new InternalMemoryProviderException("Internal memory not initialized");
            }
        }

        private void ValidateIndex(int symbolIndex)
        {
            if (symbolIndex < 0 || symbolIndex > 0xF)
            {
                throw new InternalMemoryProviderException("Invalid Index");
            }
        }
    }
}
