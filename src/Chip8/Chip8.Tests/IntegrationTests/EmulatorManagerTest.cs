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
    public class EmulatorManagerTest
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
        public void CallCommandShouldChangeCpuAndStack()
        {
            _emulatorContext.Manager.LoadRom(new byte[]
            {
                0x21,
                0x16
            });
            _emulatorContext.Manager.TryExecuteNext();

            Assert.AreEqual(1, _emulatorContext.Cpu.SP);
            Assert.AreEqual(0x200, _emulatorContext.Cpu.Stack[0]);
            Assert.AreEqual(0x116, _emulatorContext.Cpu.PC);
        }
    }
}
