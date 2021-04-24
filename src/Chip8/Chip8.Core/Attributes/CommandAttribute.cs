using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class CommandAttribute : Attribute
    {
        public string Pattern { get; }
        public string OpcodeName { get; }

        public CommandAttribute(string pattern, string opcodeName)
        {
            Pattern = pattern;
            OpcodeName = opcodeName;
        }
    }
}
