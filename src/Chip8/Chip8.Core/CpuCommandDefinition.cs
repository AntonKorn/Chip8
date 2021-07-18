using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core
{
    public class CpuCommandDefinition
    {
        public int CompiledMask { get; }
        public int CompiledPattern { get; }
        public string OpcodeName { get; }
        public IEnumerable<CpuCommandParameterDefinition> Parameters { get; }
        public Type CommandModel { get; }

        public CpuCommandDefinition(int compiledPattern, string opcodeName, IEnumerable<CpuCommandParameterDefinition> parameters, Type model, int compiledMask)
        {
            CompiledPattern = compiledPattern;
            OpcodeName = opcodeName;
            Parameters = parameters;
            CommandModel = model;
            CompiledMask = compiledMask;
        }
    }
}
