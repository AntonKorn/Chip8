using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.CpuCommandExecutors
{
    public abstract class BaseExecutor<T> : ICpuCommandExecutor<T>
    {
        public abstract void ExecuteCommand(T command, ExecutionContext context);

        public void ExecuteCommand(object command, ExecutionContext context)
        {
            ExecuteCommand((T)command, context);
        }
    }
}
