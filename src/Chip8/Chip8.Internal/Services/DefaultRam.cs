using Chip8.Core.Contracts;
using Chip8.Core.Enums;
using Chip8.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Internal.Services
{
    public class DefaultRam : IRam
    {
        private readonly int _ramSize = 4096;
        private readonly int _programmStartOffset = 0x200;
        private readonly IInternalMemoryProvider _internalMemoryProvider;
        private byte[] _ram = null!;
        private bool _isInitialized;

        public DefaultRam(IInternalMemoryProvider internalMemoryProvider)
        {
            _internalMemoryProvider = internalMemoryProvider ?? throw new ArgumentNullException(nameof(internalMemoryProvider));
        }

        public void Initialize(byte[] image)
        {
            _ram = new byte[4096];

            FillServiceMemory(_ram);
            for (int i = 0; i < image.Length; i++)
            {
                var pointer = i + _programmStartOffset;

                if (pointer > _ram.Length)
                {
                    throw new RamException("Ram is too big");
                }

                _ram[pointer] = image[i];
            }

            _isInitialized = true;
        }

        public int Read(int offset, RamReadScale ramReadSize)
        {
            if (ramReadSize == RamReadScale.Byte)
            {
                return ReadByte(offset);
            }

            return ReadWord(offset);
        }

        public int[] Read(int offset, int count, RamReadScale ramReadSize)
        {
            if (ramReadSize == RamReadScale.Byte)
            {
                return ReadBytes(offset, count).Select(i => (int)i).ToArray();
            }

            return ReadWords(offset, count).Select(i => (int)i).ToArray();
        }

        public byte ReadByte(int offset)
        {
            ThrowIfNotInitialized();
            ValidateReadAccess(offset);
            return ReadByteInternal(offset);
        }

        public byte[] ReadBytes(int offset, int count)
        {
            ThrowIfNotInitialized();
            ValidateReadAccess(offset);
            ValidateReadAccess(offset + count);

            var result = new byte[count];
            for (var i = 0; i < count; i++)
            {
                result[i] = ReadByteInternal(offset + i);
            }

            return result;
        }

        public ushort ReadWord(int offset)
        {
            ThrowIfNotInitialized();
            ValidateReadAccess(offset);
            ValidateReadAccess(offset + 1);
            return ReadWordInternal(offset);
        }

        public ushort[] ReadWords(int offset, int count)
        {
            ThrowIfNotInitialized();
            ValidateReadAccess(offset);
            ValidateReadAccess(offset + count + 1);

            var result = new ushort[count];
            for (var i = 0; i < count; i++)
            {
                result[i] = ReadWordInternal(offset + 2 * i);
            }

            return result;
        }

        public void WriteByte(int offset, int payload)
        {
            ThrowIfNotInitialized();
            ValidateWriteAccess(offset);
            WriteByteInternal(offset, payload);
        }

        public void WriteBytes(int offset, int[] payload)
        {
            ThrowIfNotInitialized();
            ValidateWriteAccess(offset);
            ValidateWriteAccess(offset + payload.Length - 1);

            for (var i = 0; i < payload.Length; i++)
            {
                WriteByteInternal(offset + i, payload[i]);
            }
        }

        public int GetCharacterSpriteOffset(int spriteIndex)
        {
            return 5 * spriteIndex;
        }

        private void ThrowIfNotInitialized()
        {
            if (!_isInitialized)
            {
                throw new RamException("Ram not initialized");
            }
        }

        private void ValidateReadAccess(int address)
        {
            if (address >= _ramSize)
            {
                throw new RamException($"Wrong memory access on address {address}");
            }
        }

        private void ValidateWriteAccess(int address)
        {
            if (address >= _ramSize || address < _programmStartOffset)
            {
                throw new RamException($"Wrong memory access on address {address}");
            }
        }

        private ushort ReadWordInternal(int offset)
        {
            return (ushort)(_ram[offset] << 8 | _ram[offset + 1]);
        }

        private byte ReadByteInternal(int offset)
        {
            return _ram[offset];
        }

        private void WriteByteInternal(int offset, int payload)
        {
            _ram[offset] = (byte)payload;
        }

        private void FillServiceMemory(byte[] ram)
        {
            for (var characterIndex = 0; characterIndex <= 0xF; characterIndex++)
            {
                var sprite = _internalMemoryProvider.GetPredefinedSymbolSprite(characterIndex);
                var currentCharacterOffset = characterIndex * 5;

                for (var i = 0; i < 5; i++)
                {
                    ram[currentCharacterOffset + i] = sprite[i];
                }
            }
        }
    }
}
