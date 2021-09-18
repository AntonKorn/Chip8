using Chip8.Core;
using Chip8.Core.Contracts;
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
    public class CommandActivatorTest
    {
        private ICommandRegistry _commandRegistry = new DefaultCommandRegistry();
        private ICommandModelActivator _commandActivator;

        public CommandActivatorTest()
        {
            _commandActivator = new DefaultCommandModelActivator(_commandRegistry);
        }

        [SetUp]
        public void Setup()
        {
            _commandRegistry = new DefaultCommandRegistry();
            _commandRegistry.DiscoverLoadedCommands();
            _commandActivator.Initialize();
        }

        [Test]
        public void MultiParamCommandShouldBeActivatedCorrectly()
        {
            var skipNextEqualsDefinition = _commandRegistry.GetAvailableCommands().Where(c => c.OpcodeName == "SE").First();
            var registerParam = skipNextEqualsDefinition.Parameters.Where(p => p.Code == "Vx").Single();
            var byteParam = skipNextEqualsDefinition.Parameters.Where(p => p.Code == "byte").Single();

            var parsedCommand = new ParsedCommand(
                skipNextEqualsDefinition,
                new List<ParsedCommandParameter>()
                {
                    new ParsedCommandParameter(byteParam, 0x14),
                    new ParsedCommandParameter(registerParam, 0x2)
                }
            );
            var activationResult = _commandActivator.ActivateCommandModel(parsedCommand);
            var command = (activationResult.ActivatedModel as SkipEquals)!;

            Assert.AreEqual(typeof(SkipEquals), activationResult.ActivatedModel.GetType());
            Assert.AreEqual(0x2, command.Register);
            Assert.AreEqual(0x14, command.Value);
        }

        [Test]
        public void SingleParamCommandShouldBeActivatedCorrecly()
        {
            var jumpDefinition = _commandRegistry.GetAvailableCommands().Where(c => c.OpcodeName == "JP").First();
            var addressParam = jumpDefinition.Parameters.Single();

            var parsedCommand = new ParsedCommand(
                jumpDefinition,
                new List<ParsedCommandParameter>()
                {
                    new ParsedCommandParameter(addressParam, 0x123)
                }
            );

            var activationResult = _commandActivator.ActivateCommandModel(parsedCommand);
            var command = (activationResult.ActivatedModel as Jump)!;

            Assert.AreEqual(typeof(Jump), activationResult.ActivatedModel.GetType());
            Assert.AreEqual(command.Address, 0x123);
        }

        [Test]
        public void NoParamCommandShouldBeActivatedCorrectly()
        {
            var clearScreenDefenition = _commandRegistry.GetAvailableCommands().Where(c => c.OpcodeName == "CLS").First();
            var parsedCommand = new ParsedCommand(clearScreenDefenition, new List<ParsedCommandParameter>());

            var activationResult = _commandActivator.ActivateCommandModel(parsedCommand);
            Assert.AreEqual(typeof(ClearScreen), activationResult.ActivatedModel.GetType());
        }
    }
}
