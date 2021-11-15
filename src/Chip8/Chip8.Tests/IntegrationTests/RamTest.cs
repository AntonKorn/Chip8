using Chip8.Core.Contracts;
using Chip8.Internal.Services;
using Chip8.Tests.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Tests.IntegrationTests
{
    public class RamTest
    {
        private IRam _ram = null!;

        [SetUp]
        public void SetUp()
        {
            var image = new byte[1];
            var internalMemoryProvider = new DefaultInternalMemoryProvider();
            internalMemoryProvider.Initialize();
            _ram = new DefaultRam(internalMemoryProvider);
            _ram.Initialize(image);
        }

        [TestCase(0x0)]
        [TestCase(0x1)]
        [TestCase(0x2)]
        [TestCase(0x3)]
        [TestCase(0x4)]
        [TestCase(0x5)]
        [TestCase(0x6)]
        [TestCase(0x7)]
        [TestCase(0x8)]
        [TestCase(0x9)]
        [TestCase(0xA)]
        [TestCase(0xB)]
        [TestCase(0xC)]
        [TestCase(0xD)]
        [TestCase(0xE)]
        [TestCase(0xF)]
        public void ShouldReturnProperSprites(int characterIndex)
        {
            var expected = ServiceMemoryHelper.GetSprite(characterIndex);

            var characterSpriteOffset = _ram.GetCharacterSpriteOffset(characterIndex);
            var actual = _ram.ReadBytes(characterSpriteOffset, 5);

            Assert.AreEqual(expected, actual);
        }
    }
}
