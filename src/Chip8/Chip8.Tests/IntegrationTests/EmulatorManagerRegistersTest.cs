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
    public class EmulatorManagerRegistersTest
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
        public void LoadIndexCommandShouldChangeCpu()
        {
            _emulatorContext.Manager.LoadRom(new byte[]
            {
                0xA2,
                0xB4
            });
            _emulatorContext.Manager.TryExecuteNext();

            Assert.AreEqual(0x2B4, _emulatorContext.Cpu.I);
            Assert.AreEqual(0x202, _emulatorContext.Cpu.PC);
        }

        [Test]
        public void LoadValueIntoRegisterCommandShouldChangeCpu()
        {
            _emulatorContext.Manager.LoadRom(new byte[]
            {
                0x6A,
                0x19
            });
            _emulatorContext.Manager.TryExecuteNext();

            Assert.AreEqual(0x19, _emulatorContext.Cpu.Registers[0xA]);
            Assert.AreEqual(0x202, _emulatorContext.Cpu.PC);
        }

        [TestCase(0x10)]
        [TestCase(0x70)]
        [TestCase(0xFF)]
        public void LoadRandomValueIntoRegisterCommandShouldRespectMask(byte mask)
        {
            var registerNumber = 1;
            _emulatorContext.Manager.LoadRom(new byte[]
            {
                0xC1,
                mask
            });
            _emulatorContext.Manager.TryExecuteNext();

            Assert.AreEqual(_emulatorContext.Cpu.Registers[registerNumber], _emulatorContext.Cpu.Registers[registerNumber] & mask);
            Assert.AreEqual(0x202, _emulatorContext.Cpu.PC);
        }

        [Test]
        public void SetDelayTimerShouldChangeCpu()
        {
            var registerNumber = 1;
            var registerValue = 2;
            _emulatorContext.Manager.LoadRom(new byte[]
            {
                0xF1,
                0x15
            });
            _emulatorContext.Cpu.Registers[registerNumber] = registerValue;

            _emulatorContext.Manager.TryExecuteNext();

            Assert.AreEqual(0x202, _emulatorContext.Cpu.PC);
            Assert.AreEqual(registerValue, _emulatorContext.Cpu.DT);
        }

        [Test]
        public void LoadDelayTimerIntoRegisterShouldChangeCpu()
        {
            var delayTimerValue = 10;
            var registerNumber = 2;
            _emulatorContext.Manager.LoadRom(new byte[]
            {
                0xF2,
                0x07
            });
            _emulatorContext.Cpu.DT = delayTimerValue;

            _emulatorContext.Manager.TryExecuteNext();

            Assert.AreEqual(0x202, _emulatorContext.Cpu.PC);
            Assert.AreEqual(delayTimerValue, _emulatorContext.Cpu.Registers[registerNumber]);
        }

        [Test]
        public void MoveRegisterIntoRegisterShouldChangeCpu()
        {
            var sourceRegister = 1;
            var destinationRegister = 2;
            var sourceValue = 10;
            _emulatorContext.Manager.LoadRom(new byte[]
            {
                0x82,
                0x10
            });
            _emulatorContext.Cpu.Registers[sourceRegister] = sourceValue;

            _emulatorContext.Manager.TryExecuteNext();

            Assert.AreEqual(0x202, _emulatorContext.Cpu.PC);
            Assert.AreEqual(sourceValue, _emulatorContext.Cpu.Registers[destinationRegister]);
        }
    }
}
