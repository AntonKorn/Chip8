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
    public class EmulatorManagerJumpTest
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
        public void JumpShouldChangeCpu()
        {
            _emulatorContext.Manager.LoadRom(new byte[]
            {
                0x12,
                0x35
            });

            _emulatorContext.Manager.TryExecuteNext();

            Assert.AreEqual(0x235, _emulatorContext.Cpu.PC);
        }
    }
}
