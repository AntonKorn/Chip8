using Chip8.Core;
using Chip8.Core.Contracts;
using Chip8.Core.CpuCommandExecutors;
using Chip8.Core.CpuCommands;
using Chip8.Internal.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Tests.UnitTests
{
    public class CpuCommadnExecutorProviderTest
    {
        private ICommandExecutorProvider _commandExecutorProvider = null!;

        [SetUp]
        public void SetUp()
        {
            _commandExecutorProvider = new DefaultCommandExecutorProvider();
            _commandExecutorProvider.Initialize();
        }

        [TestCase(typeof(Call), typeof(CallCommandExecutor))]
        public void ShouldReturnExecutorCorrectly(Type commandType, Type expectedExecutorType)
        {
            var actual = _commandExecutorProvider.GetCommandExecutor(commandType).GetType();

            Assert.AreEqual(expectedExecutorType, actual);
        }
    }
}
