using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core
{
    public class ParsedCommand
    {
        public CpuCommandDefinition CommandDefinition { get; set; }
        public IReadOnlyList<ParsedCommandParameter> Parameters { get; }

        public ParsedCommand(CpuCommandDefinition commandDefinition, IReadOnlyList<ParsedCommandParameter> parameters)
        {
            CommandDefinition = commandDefinition;
            Parameters = parameters;
        }
    }

    public class ParsedCommandParameter
    {
        public ParsedCommandParameter(CpuCommandParameterDefinition cpuCommandParameterDefinition, int value)
        {
            CpuCommandParameterDefenition = cpuCommandParameterDefinition;
            Value = value;
        }

        public CpuCommandParameterDefinition CpuCommandParameterDefenition { get; }
        public int Value { get; }
    }
}
