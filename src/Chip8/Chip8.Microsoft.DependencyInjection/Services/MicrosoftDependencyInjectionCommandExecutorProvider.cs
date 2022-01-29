using Chip8.Core;
using Chip8.Core.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Microsoft.DependencyInjection.Services
{
    public class MicrosoftDependencyInjectionCommandExecutorProvider : ICommandExecutorProvider
    {
        private IServiceProvider? _serviceProvider;

        public MicrosoftDependencyInjectionCommandExecutorProvider(IServiceProvider? serviceProvider)
        {

        }

        public void Initialize()
        {
            var services = new ServiceCollection();
            var executors = AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => a.FullName!.StartsWith("Chip8"))
                .SelectMany(a => a
                    .GetTypes()
                    .Where(IsCommandExecutor));

            foreach (var executor in executors)
            {
                var commandInterface = GetExecutorInterface(executor)!;
                services.AddTransient(commandInterface, executor.GetType());
            }

            _serviceProvider = services.BuildServiceProvider();
        }

        public ICpuCommandExecutor<TCommand>? GetCommandExecutor<TCommand>()
        {
            var executorInterface = MakeExecutorType(typeof(TCommand));
            return _serviceProvider.GetService(executorInterface) as ICpuCommandExecutor<TCommand>;
        }

        public void Dispose()
        {
        }

        private bool IsCommandExecutor(Type t)
        {
            return GetExecutorInterface(t) != null;
        }

        private Type? GetExecutorInterface(Type t)
        {
            return t.GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICpuCommandExecutor<>))
                .FirstOrDefault();
        }

        private Type MakeExecutorType(Type commandType)
        {
            return typeof(ICpuCommandExecutor<>).MakeGenericType(commandType);
        }
    }
}
