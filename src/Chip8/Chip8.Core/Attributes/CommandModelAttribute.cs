using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class CommandModelAttribute : Attribute, ICommandModel
    {
        public string Pattern { get; }
        public string OpcodeName { get; }

        public CommandModelAttribute(string pattern, string opcodeName)
        {
            Pattern = pattern;
            OpcodeName = opcodeName;
        }
    }
}
