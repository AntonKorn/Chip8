using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CommandParameterAttribute : Attribute
    {
        public string Code { get; }

        public int NibbleIndex { get; }

        public int NibblesCount { get; }

        public CommandParameterAttribute(string code, int nibbleIndex, int nibblesCount)
        {
            Code = code;
            NibbleIndex = nibbleIndex;
            NibblesCount = nibblesCount;
        }
    }
}
