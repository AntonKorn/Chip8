using Chip8.Core;
using Chip8.Core.Contracts;
using Chip8.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Internal.Services
{
    public class DefaultCommandExecutorProvider : ICommandExecutorProvider
    {
        private IDictionary<Type, object?>? _executors;

        public void Initialize()
        {
            _executors = new Dictionary<Type, object?>();
            var executorTypes = AppDomain.CurrentDomain.GetAssemblies()
                   .Where(a => a.FullName!.StartsWith("Chip8"))
                   .SelectMany(a => a
                       .GetTypes()
                       .Where(IsCommandExecutor));

            foreach (var executorType in executorTypes)
            {
                var executorInterface = GetExecutorInterface(executorType)!;
                var executor = Activator.CreateInstance(executorType);

                var commandType = executorInterface.GetGenericArguments()[0];

                _executors[commandType] = executor;
            }
        }

        public ICpuCommandExecutor<TCommand> GetCommandExecutor<TCommand>()
        {
            return (ICpuCommandExecutor<TCommand>)GetCommandExecutor(typeof(TCommand));
        }

        public ICpuCommandExecutor GetCommandExecutor(Type commandType)
        {
            EnsureInitialised();
            _executors.TryGetValue(commandType, out var executor);

            if (executor == null)
            {
                throw new ExecutorProviderException("Command not found");
            }

            return (ICpuCommandExecutor)executor;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        private bool IsCommandExecutor(Type t)
        {
            return !t.IsAbstract && GetExecutorInterface(t) != null;
        }

        private Type? GetExecutorInterface(Type t)
        {
            return t.GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICpuCommandExecutor<>))
                .FirstOrDefault();
        }

        [MemberNotNull(nameof(_executors))]
        private void EnsureInitialised()
        {
            if (_executors == null)
            {
                throw new ExecutorProviderException("Executor provider was not initialised");
            }
        }
    }
}
