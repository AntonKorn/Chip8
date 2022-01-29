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
            _emulatorContext.Cpu.Resgisters[registerNumber] = initialRegisterValue;

            _emulatorContext.Manager.TryExecuteNext();

            Assert.AreEqual(expected, _emulatorContext.Cpu.Resgisters[registerNumber]);
            Assert.AreEqual(0x202, _emulatorContext.Cpu.PC);
        }
    }
}
