using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.Contracts
{
    public interface ICommandExecutorProvider : IDisposable
    {
        void Initialize();
        ICpuCommandExecutor<TCommand> GetCommandExecutor<TCommand>();
        ICpuCommandExecutor GetCommandExecutor(Type commandType);
    }
}
