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
    public class EmulatorManagerProceduresTest
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

            Assert.AreEqual(0x19, _emulatorContext.Cpu.Resgisters[0xA]);
            Assert.AreEqual(0x202, _emulatorContext.Cpu.PC);
        }
    }
}
