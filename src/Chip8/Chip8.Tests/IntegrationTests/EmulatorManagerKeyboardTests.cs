using Chip8.Core;
using Chip8.Internal;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Tests.IntegrationTests
{
    public class EmulatorManagerKeyboardTests
    {
        private EmulatorContext _emulatorContext = null!;
        private IEmulatorFactory _emulatorFactory = new DefaultEmulatorFactory();

        [SetUp]
        public void SetUp()
        {
            _emulatorContext = _emulatorFactory.CreateEmulatorInstance();
            _emulatorContext.Initialize();
        }

        [Test]
        public void SkipNotPressedShouldSkipNextWhenKeyNotPresed()
        {
            var key = 0xA;
            var registerNumber = 4;
            _emulatorContext.Manager.LoadRom(new byte[]
            {
                0xE4,
                0xA1
            });
            _emulatorContext.Cpu.Registers[registerNumber] = key;

            _emulatorContext.Manager.TryExecuteNext();

            Assert.AreEqual(0x204, _emulatorContext.Cpu.PC);
        }

        [Test]
        public void SkipNotPressedShouldNotSkipNextWhenKeyPresed()
        {
            var key = 0xA;
            var registerNumber = 4;
            _emulatorContext.Manager.LoadRom(new byte[]
            {
                0xE4,
                0xA1
            });
            _emulatorContext.Cpu.Registers[registerNumber] = key;
            _emulatorContext.Keyboard.SetKey(key);

            _emulatorContext.Manager.TryExecuteNext();

            Assert.AreEqual(0x202, _emulatorContext.Cpu.PC);
        }

        [Test]
        public void SkipPressedShouldSkipNextWhenKeyPresed()
        {
            var key = 0xA;
            var registerNumber = 4;
            _emulatorContext.Manager.LoadRom(new byte[]
            {
                0xE4,
                0x9E
            });
            _emulatorContext.Cpu.Registers[registerNumber] = key;
            _emulatorContext.Keyboard.SetKey(key);

            _emulatorContext.Manager.TryExecuteNext();

            Assert.AreEqual(0x204, _emulatorContext.Cpu.PC);
        }

        [Test]
        public void SkipPressedShouldNotSkipNextWhenKeyNotPresed()
        {
            var key = 0xA;
            var registerNumber = 4;
            _emulatorContext.Manager.LoadRom(new byte[]
            {
                0xE4,
                0x9E
            });
            _emulatorContext.Cpu.Registers[registerNumber] = key;

            _emulatorContext.Manager.TryExecuteNext();

            Assert.AreEqual(0x202, _emulatorContext.Cpu.PC);
        }
    }
}
