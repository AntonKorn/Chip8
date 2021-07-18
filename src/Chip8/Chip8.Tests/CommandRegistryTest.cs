using Chip8.Core.Contracts;
using Chip8.Internal.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Tests
{
    public class CommandRegistryTest
    {
        private ICommandRegistry _commandRegistry = new DefaultCommandRegistry();

        [SetUp]
        public void Setup()
        {
            _commandRegistry = new DefaultCommandRegistry();
            _commandRegistry.DiscoverLoadedCommands();
        }

        [Test]
        public void CommandsShouldBeCompiledCorrectly()
        {
            var sysCommand = _commandRegistry.GetAvailableCommands().Where(c => c.OpcodeName == "SYS").First();
            Assert.AreEqual(sysCommand.CompiledPattern, 0x0000);
        }

        [Test]
        public void CommandParametersShouldBeCompiledCorrectly()
        {
            var sysCommand = _commandRegistry.GetAvailableCommands().Where(c => c.OpcodeName == "SYS").First();
            var parameter = sysCommand.Parameters.First();
            Assert.AreEqual(parameter.CompiledMask, 0x0fff);
        }
    }
}
