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
    public class EmulatorManagerArithmeticTest
    {
        private EmulatorContext _emulatorContext = null!;
        private IEmulatorFactory _emulatorFactory = new DefaultEmulatorFactory();

        [SetUp]
        public void SetUp()
        {
            _emulatorContext = _emulatorFactory.CreateEmulatorInstance();
            _emulatorContext.Initialize();
        }

        [TestCase(5, 10, 15)]
        [TestCase(250, 10, 4)]
        public void InlineAddShouldUpdateCpu(byte initialRegisterValue, byte operand, int expected)
        {
            _emulatorContext.Manager.LoadRom(new byte[]
            {
                0x72,
                operand
            });
            var registerNumber = 2;
            _emulatorContext.Cpu.Registers[registerNumber] = initialRegisterValue;

            _emulatorContext.Manager.TryExecuteNext();

            Assert.AreEqual(expected, _emulatorContext.Cpu.Registers[registerNumber]);
            Assert.AreEqual(0x202, _emulatorContext.Cpu.PC);
        }

        [TestCase(65530, 10, 4)]
        [TestCase(10, 10, 20)]
        public void AddRegisterToIndexShouldUpdateCpu(int initialIndexValue, int registerValue, int expected)
        {
            _emulatorContext.Manager.LoadRom(new byte[]
            {
                0xF1,
                0x1E
            });
            var registerNumber = 1;
            _emulatorContext.Cpu.Registers[registerNumber] = registerValue;
            _emulatorContext.Cpu.I = initialIndexValue;

            _emulatorContext.Manager.TryExecuteNext();

            Assert.AreEqual(expected, _emulatorContext.Cpu.I);
            Assert.AreEqual(0x202, _emulatorContext.Cpu.PC);
        }
    }
}
