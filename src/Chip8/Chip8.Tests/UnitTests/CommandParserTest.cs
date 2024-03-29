﻿using Chip8.Core.Contracts;
using Chip8.Internal.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Tests.UnitTests
{
    public class CommandParserTest
    {
        private ICommandRegistry _commandRegistry = new DefaultCommandRegistry();
        private ICommandParser _commandParser;

        public CommandParserTest()
        {
            _commandParser = new DefaultCommandParser(_commandRegistry);
        }

        [SetUp]
        public void Setup()
        {
            _commandRegistry = new DefaultCommandRegistry();
            _commandRegistry.DiscoverLoadedCommands();
            _commandParser.Initialzie();
        }

        [Test]
        public void CommandsWithMultipleParametersShouldBeParsedCorrectly()
        {
            var parsedCommand = _commandParser.ParseCommand(0x3212);
            var register = parsedCommand.Parameters.Where(p => p.CpuCommandParameterDefenition.Code == "Vx").First();
            var @byte = parsedCommand.Parameters.Where(p => p.CpuCommandParameterDefenition.Code == "byte").First();

            Assert.AreEqual("SE", parsedCommand.CommandDefinition.OpcodeName);
            Assert.AreEqual(2, parsedCommand.Parameters.Count);
            Assert.AreEqual(0x2, register.Value);
            Assert.AreEqual(0x12, @byte.Value);
        }

        [Test]
        public void NotSpecificCommandsWithSingleParameterShouldBeParsedCorrectly()
        {
            var parsedCommand = _commandParser.ParseCommand(0x0212);
            var address = parsedCommand.Parameters.Single();

            Assert.AreEqual("SYS", parsedCommand.CommandDefinition.OpcodeName);
            Assert.AreEqual(0x212, address.Value);
        }

        [Test]
        public void MostSpecificCommandsWithoutParametersShouldBeParsedCorrectly()
        {
            var parsedClsCommand = _commandParser.ParseCommand(0x00E0);
            var parsedRetCommand = _commandParser.ParseCommand(0x00EE);

            Assert.AreEqual("CLS", parsedClsCommand.CommandDefinition.OpcodeName);
            Assert.AreEqual("RET", parsedRetCommand.CommandDefinition.OpcodeName);
        }
    }
}
