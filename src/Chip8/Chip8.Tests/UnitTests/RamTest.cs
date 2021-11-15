using Chip8.Core.Contracts;
using Chip8.Core.Exceptions;
using Chip8.Internal.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Tests.UnitTests
{
    public class RamTest
    {
        private IRam _ram = null!;
        private byte[] _image = new byte[]
        {
            0x01,
            0x02,
            0x03,
            0x05,
            0x06
        };

        [SetUp]
        public void SetUp()
        {
            var memoryProvider = Mock.Of<IInternalMemoryProvider>(
                provider => provider.GetPredefinedSymbolSprite(It.Is<int>(i => i >= 0 && i <= 0xF)) == new byte[5]);
            _ram = new DefaultRam(memoryProvider);
        }

        [Test]
        public void ShouldNotAllowReadByteAccessFromOutsideOfMemoryLimits()
        {
            InitializeRam();

            void AccessMemoryFromOutside()
            {
                _ram.Read(4096, Core.Enums.RamReadScale.Byte);
            }

            Assert.Throws<RamException>(AccessMemoryFromOutside);
        }

        [Test]
        public void ShouldNotAllowReadAccessWordOnTheEdgeOfMemoryLimits()
        {
            InitializeRam();

            void AccessMemoryFromTheEdge()
            {
                _ram.Read(4095, Core.Enums.RamReadScale.Word);
            }

            Assert.Throws<RamException>(AccessMemoryFromTheEdge);
        }

        [Test]
        public void ShouldNotAllowReadWordAccessOnTheEdgeOfMemoryLimits()
        {
            InitializeRam();

            void AccessMemoryFromTheEdge()
            {
                _ram.Read(4095, Core.Enums.RamReadScale.Word);
            }

            Assert.Throws<RamException>(AccessMemoryFromTheEdge);
        }

        [Test]
        public void ShouldReadSingleByteProperly()
        {
            InitializeRam();

            var @byte = _ram.Read(0x200, Core.Enums.RamReadScale.Byte);

            Assert.AreEqual(0x01, @byte);
        }

        [Test]
        public void ShouldReadSingleByteFromTheBorderProperly()
        {
            InitializeRam();

            var @byte = _ram.Read(4095, Core.Enums.RamReadScale.Byte);

            Assert.AreEqual(0x00, @byte);
        }

        [Test]
        public void ShouldReadWordProperly()
        {
            InitializeRam();

            var word = _ram.Read(0x201, Core.Enums.RamReadScale.Word);

            Assert.AreEqual(0x0203, word);
        }

        [Test]
        public void ShouldNotAllowToReadByteArrayFromBorder()
        {
            InitializeRam();

            void AccessMemoryFromTheEdge()
            {
                _ram.Read(4095, 4, Core.Enums.RamReadScale.Byte);
            }

            Assert.Throws<RamException>(AccessMemoryFromTheEdge);
        }

        [Test]
        public void ShouldNotAllowToReadWordArrayFromBorder()
        {
            InitializeRam();

            void AccessMemoryFromTheEdge()
            {
                _ram.Read(4095, 4, Core.Enums.RamReadScale.Word);
            }

            Assert.Throws<RamException>(AccessMemoryFromTheEdge);
        }

        [Test]
        public void ShouldReadByteArrayProperly()
        {
            var expected = new byte[]
            {
                0x02,
                0x03,
                0x05
            };
            InitializeRam();

            var array = _ram.Read(0x201, 3, Core.Enums.RamReadScale.Byte);

            Assert.AreEqual(expected, array);
        }

        [Test]
        public void ShouldReadWordArrayProperly()
        {
            var expected = new ushort[]
            {
                0x0203,
                0x0506,
                0x0000
            };
            InitializeRam();

            var array = _ram.Read(0x201, 3, Core.Enums.RamReadScale.Word);

            Assert.AreEqual(expected, array);
        }

        [Test]
        public void ShouldWriteBytesProperly()
        {
            InitializeRam();
            var bytes = new byte[]
            {
                0x01,
                0x03,
                0x05
            };

            _ram.WriteBytes(0x240, bytes.Select(i => (int)i).ToArray());
            var result = _ram.ReadBytes(0x240, bytes.Length);

            Assert.AreEqual(bytes, result);
        }

        [Test]
        public void ShouldWriteByteProperly()
        {
            InitializeRam();
            var expected = 0x03;

            _ram.WriteByte(0x240, expected);
            var result = _ram.ReadByte(0x240);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ShouldNotWriteByteInServiceMemory()
        {
            InitializeRam();

            void WriteByteInServiceMemory()
            {
                _ram.WriteByte(0x190, 0x0);
            }

            Assert.Throws<RamException>(WriteByteInServiceMemory);
        }

        [Test]
        public void ShouldNotWriteBytesInServiceMemory()
        {
            InitializeRam();

            void WriteBytesInServiceMemory()
            {
                _ram.WriteBytes(0x190, new int[10]);
            }

            Assert.Throws<RamException>(WriteBytesInServiceMemory);
        }

        [Test]
        public void ShouldThrowWhenAccessNotInitialized()
        {
            void AccessNotInitializedRam()
            {
                _ram.ReadByte(0);
            }

            Assert.Throws<RamException>(AccessNotInitializedRam);
        }

        private void InitializeRam()
        {
            _ram.Initialize(_image);
        }
    }
}
