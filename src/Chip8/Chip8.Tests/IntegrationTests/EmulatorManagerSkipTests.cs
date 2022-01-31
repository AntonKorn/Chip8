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
    public class EmulatorManagerSkipTests
    {
        private EmulatorContext _emulatorContext = null!;
        private IEmulatorFactory _emulatorFactory = new DefaultEmulatorFactory();

        [SetUp]
        public void SetUp()
        {
            _emulatorContext = _emulatorFactory.CreateEmulatorInstance();
            _emulatorContext.Initialize();
        }

        [TestCase(10, 10, 0x204)]
        [TestCase(10, 11, 0x202)]
        public void SkipEqualsShouldUpdateCpu(int registerValue, byte value, int programCounter)
        {
            var registerIndex = 1;
            _emulatorContext.Manager.LoadRom(new byte[]
            {
                0x31,
                value
            });
            _emulatorContext.Cpu.Registers[registerIndex] = registerValue;

            _emulatorContext.Manager.TryExecuteNext();

            Assert.AreEqual(programCounter, _emulatorContext.Cpu.PC);
        }

        [TestCase(10, 10, 0x202)]
        [TestCase(10, 11, 0x204)]
        public void SkipNotEqualsShouldUpdateCpu(int registerValue, byte value, int programCounter)
        {
            var registerIndex = 1;
            _emulatorContext.Manager.LoadRom(new byte[]
            {
                0x41,
                value
            });
            _emulatorContext.Cpu.Registers[registerIndex] = registerValue;

            _emulatorContext.Manager.TryExecuteNext();

            Assert.AreEqual(programCounter, _emulatorContext.Cpu.PC);
        }

        [TestCase(10, 10, 0x202)]
        [TestCase(10, 11, 0x204)]
        public void SkipRegistersNotEqualShouldUpdateCpu(int firstRegisterValue, int secondRegisterValue, int expectedProgramCounter)
        {
            var firstRegister = 1;
            var secondRegister = 2;
            _emulatorContext.Manager.LoadRom(new byte[]
            {
                0x91,
                0x20
            });
            _emulatorContext.Cpu.Registers[firstRegister] = firstRegisterValue;
            _emulatorContext.Cpu.Registers[secondRegister] = secondRegisterValue;

            _emulatorContext.Manager.TryExecuteNext();

            Assert.AreEqual(_emulatorContext.Cpu.PC, expectedProgramCounter);
        }
    }
}
