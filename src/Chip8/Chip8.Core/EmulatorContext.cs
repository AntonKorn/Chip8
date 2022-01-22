using Chip8.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core
{
    public class EmulatorContext
    {
        private readonly IInternalMemoryProvider _internalMemoryProvider;
        private readonly ICommandModelActivator _commandModelActivator;

        public ICpu Cpu { get; }
        public IRam Ram { get; }
        public IKeyboard Keyboard { get; }
        public IGraphicalDeviceState GraphicalDevice { get; }
        public IEmulationManager Manager { get; }

        public EmulatorContext(
            ICpu cpu,
            IRam ram,
            IKeyboard keyboard,
            IGraphicalDeviceState graphicalDeviceState,
            IEmulationManager emulationManager,
            IInternalMemoryProvider internalMemoryProvider,
            ICommandModelActivator commandModelActivator)
        {
            Cpu = cpu;
            Ram = ram;
            Keyboard = keyboard;
            GraphicalDevice = graphicalDeviceState;
            Manager = emulationManager;
            _internalMemoryProvider = internalMemoryProvider;
            _commandModelActivator = commandModelActivator;
        }

        public void Initialize()
        {
            Manager.Initialize();

            _internalMemoryProvider.Initialize();
            _commandModelActivator.Initialize();
        }
    }
}
