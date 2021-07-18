﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core
{
    public class CpuCommandParameterDefenition
    {
        public string PropertyName { get; }
        public string Code { get; }
        public int CompiledMask { get; }
        public int NibbleIndex { get; }

        public CpuCommandParameterDefenition(string propertyName, string code, int compiledMask, int nibbleIndex)
        {
            PropertyName = propertyName;
            Code = code;
            CompiledMask = compiledMask;
            NibbleIndex = nibbleIndex;
        }
    }
}
