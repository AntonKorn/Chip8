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
    public class EmulatorManagerGraphicsTest
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
        public void DrawCpuCommandShouldUpdateGraphicalDeviceAndRegisters()
        {
            var x = 3;
            var y = 4;
            _emulatorContext.Manager.LoadRom(new byte[]
            {
                0xD1,
                0x22,
                0xFF,
                0xFF
            });
            _emulatorContext.Cpu.Registers[1] = x;
            _emulatorContext.Cpu.Registers[2] = y;
            _emulatorContext.Cpu.I = 0x202;

            _emulatorContext.Manager.TryExecuteNext();

            Assert.IsTrue(_emulatorContext.GraphicalDevice.GetPixel(3, 4));
            Assert.IsTrue(_emulatorContext.GraphicalDevice.GetPixel(4, 4));
            Assert.IsTrue(_emulatorContext.GraphicalDevice.GetPixel(3, 5));
            Assert.IsTrue(_emulatorContext.GraphicalDevice.GetPixel(4, 5));
        }
    }
}
