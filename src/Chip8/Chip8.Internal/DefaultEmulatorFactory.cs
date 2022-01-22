using Chip8.Core;
using Chip8.Internal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Internal
{
    public class DefaultEmulatorFactory : IEmulatorFactory
    {
        public EmulatorContext CreateEmulatorInstance()
        {
            var cpu = new Cpu();
            var internalMemory = new DefaultInternalMemoryProvider();
            var ram = new DefaultRam(internalMemory);
            var keyboard = new DefaultKeyboard();
            var graphicalDevice = new GraphicalDeviceState();
            var commandRegistry = new DefaultCommandRegistry();
            var commandParser = new DefaultCommandParser(commandRegistry);
            var commandModelActiator = new DefaultCommandModelActivator(commandRegistry);
            var commandExecutorProvider = new DefaultCommandExecutorProvider();

            var emulator = new DefaultEmulationManager(
                cpu,
                graphicalDevice,
                ram,
                keyboard,
                commandModelActiator,
                commandParser,
                commandExecutorProvider);

            return new EmulatorContext(
                cpu,
                ram,
                keyboard,
                graphicalDevice,
                emulator,
                internalMemory,
                commandModelActiator);
        }
    }
}
