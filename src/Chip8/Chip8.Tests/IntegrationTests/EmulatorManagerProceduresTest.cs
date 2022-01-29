using Chip8.Core;
using Chip8.Core.Exceptions;
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
        public void CallCommandShouldChangeCpuAndStack()
        {
            _emulatorContext.Manager.LoadRom(new byte[]
            {
                0x21,
                0x16
            });
            _emulatorContext.Manager.TryExecuteNext();

            Assert.AreEqual(1, _emulatorContext.Cpu.SP);
            Assert.AreEqual(0x202, _emulatorContext.Cpu.Stack[1]);
            Assert.AreEqual(0x116, _emulatorContext.Cpu.PC);
        }

        [Test]
        public void CallCommandShouldThrowWhenStackOverflow()
        {
            _emulatorContext.Manager.LoadRom(new byte[]
            {
                0x21,
                0x16
            });
            _emulatorContext.Cpu.SP = 0xF;

            void Next()
            {
                _emulatorContext.Manager.TryExecuteNext();
            }

            Assert.Throws<ChipRuntimeException>(Next);
        }

        [Test]
        public void ReturnCommandShouldChangeCpuAndStack()
        {
            _emulatorContext.Manager.LoadRom(new byte[]
            {
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0xEE
            });
            _emulatorContext.Cpu.SP = 1;
            _emulatorContext.Cpu.Stack[1] = 0x202;
            _emulatorContext.Cpu.PC = 0x204;

            _emulatorContext.Manager.TryExecuteNext();

            Assert.AreEqual(0, _emulatorContext.Cpu.SP);
            Assert.AreEqual(0x202, _emulatorContext.Cpu.PC);
        }

        [Test]
        public void ReturnCommandShouldThrowWhenStackCorrupted()
        {
            _emulatorContext.Manager.LoadRom(new byte[]
            {
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0xEE
            });
            _emulatorContext.Cpu.SP = 0;
            _emulatorContext.Cpu.Stack[1] = 0x202;
            _emulatorContext.Cpu.PC = 0x204;

            void Next()
            {
                _emulatorContext.Manager.TryExecuteNext();
            }

            Assert.Throws<ChipRuntimeException>(Next);
        }
    }
}
