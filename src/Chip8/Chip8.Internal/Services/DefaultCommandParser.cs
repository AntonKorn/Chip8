using Chip8.Core;
using Chip8.Core.Contracts;
using Chip8.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Internal.Services
{
    public class DefaultCommandParser : ICommandParser
    {
        private bool _isInitialized = false;
        private readonly ICommandRegistry _commandRegistry;
        private IEnumerable<CpuCommandDefinition> _cpuCommandDefinitions = Enumerable.Empty<CpuCommandDefinition>();

        public DefaultCommandParser(ICommandRegistry commandRegistry)
        {
            _commandRegistry = commandRegistry ?? throw new ArgumentNullException(nameof(commandRegistry));
        }

        public void Initialzie()
        {
            if (!_commandRegistry.GetAvailableCommands().Any())
            {
                _commandRegistry.DiscoverLoadedCommands();
            }

            _cpuCommandDefinitions = _commandRegistry.GetAvailableCommands();
            _isInitialized = true;
        }

        public ParsedCommand ParseCommand(int command)
        {
            if (!_isInitialized)
            {
                throw new CommandParseException("Parser was not initialized");
            }

            var commandDefintion = _cpuCommandDefinitions.Where(definition => IsMatch(command, definition)).FirstOrDefault();
            if (commandDefintion == null)
            {
                throw new CommandParseException("Unable to parse command");
            }

            try
            {
                var parameters = ParseParameters(command, commandDefintion.Parameters);
                return new ParsedCommand(commandDefintion, parameters);
            }
            catch (Exception e)
            {
                throw new CommandParseException("Failed to parse command", e);
            }
            
        }

        private bool IsMatch(int command, CpuCommandDefinition commandDefinition)
        {
            return (commandDefinition.CompiledMask & command) == commandDefinition.CompiledPattern;
        }

        private List<ParsedCommandParameter> ParseParameters(int command, IEnumerable<CpuCommandParameterDefinition> parameterDefinitions)
        {
            return parameterDefinitions
                .Select(parameterDef =>
                {
                    var parsedParameterValue = (command & parameterDef.CompiledMask) >> parameterDef.NibbleIndex * 4;
                    return new ParsedCommandParameter(parameterDef, parsedParameterValue);
                })
                .ToList();
        }
    }
}
