using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core
{
    public class CpuCommandDefenition
    {
        public int CompiledPattern { get; }
        public string OpcodeName { get; }
        public IEnumerable<CpuCommandParameterDefenition> Parameters { get; }
        public Type CommandModel { get; }

        public CpuCommandDefenition(int compiledPattern, string opcodeName, IEnumerable<CpuCommandParameterDefenition> parameters, Type model)
        {
            CompiledPattern = compiledPattern;
            OpcodeName = opcodeName;
            Parameters = parameters;
            CommandModel = model;
        }
    }
}
