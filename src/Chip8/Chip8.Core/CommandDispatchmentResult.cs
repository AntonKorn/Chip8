using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core
{
    public class CommandDispatchmentResult
    {
        public object CommandModel { get; }

        public CommandDispatchmentResult(object commandModel)
        {
            CommandModel = commandModel;
        }
    }
}
