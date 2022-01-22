using Chip8.Core;
using Chip8.Core.Contracts;
using Chip8.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Internal.Services
{
    public class DefaultEmulationManager : IEmulationManager
    {
        private readonly ICpu _cpu;
        private readonly IGraphicalDeviceState _graphics;
        private readonly IRam _ram;
        private readonly IKeyboard _keyboard;
        private readonly ICommandModelActivator _commandModelActivator;
        private readonly ICommandParser _commandParser;
        private readonly ICommandExecutorProvider _commandExecutorProvider;
        private bool _isInitialized;

        public DefaultEmulationManager(
            ICpu cpu,
            IGraphicalDeviceState graphics,
            IRam ram,
            IKeyboard keyboard,
            ICommandModelActivator commandModelActivator,
            ICommandParser commandParser,
            ICommandExecutorProvider commandExecutorProvider)
        {
            _cpu = cpu;
            _graphics = graphics;
            _ram = ram;
            _keyboard = keyboard;
            _commandModelActivator = commandModelActivator;
            _commandParser = commandParser;
            _commandExecutorProvider = commandExecutorProvider;
        }

        public bool TryExecuteNext()
        {
            ThrowIfNotInitialized();

            try
            {
                var moreOperationsAvailable = _cpu.PC <= _ram.ExecutionTop;
                if (!moreOperationsAvailable)
                {
                    return false;
                }

                var operation = _ram.ReadWord(_cpu.PC);
                var currentCommand = _commandParser.ParseCommand(operation);
                var activationResult = _commandModelActivator.ActivateCommandModel(currentCommand);
                var executor = _commandExecutorProvider.GetCommandExecutor(activationResult.ActivatedModel.GetType());
                var context = CreateContext(activationResult.ParsedCommand);
                executor.ExecuteCommand(activationResult.ActivatedModel, context);
            }
            catch(Exception e)
            {
                throw new EmulatorManagerException("Unexpected exception ocurred", e);
            }

            return true;
        }

        public void Initialize()
        {
            _isInitialized = true;
            _commandParser.Initialzie();
            _commandExecutorProvider.Initialize();
            FillCpuWithDefaults();
        }

        public void LoadRom(byte[] rom)
        {
            ThrowIfNotInitialized();
            _ram.Initialize(rom);
            FillCpuWithDefaults();
        }

        private void ThrowIfNotInitialized()
        {
            if (!_isInitialized)
            {
                throw new EmulatorManagerException("Service was not initialized");
            }
        }

        private void FillCpuWithDefaults()
        {
            _cpu.PC = _ram.ExecutionOffset;
            _cpu.I = 0;
            _cpu.SP = 0;
            Array.Fill(_cpu.Resgisters, 0);
            Array.Fill(_cpu.Stack, 0);
        }

        private ExecutionContext CreateContext(ParsedCommand parsedCommand)
        {
            return new ExecutionContext(_cpu, _ram, _keyboard, _graphics, parsedCommand);
        }
    }
}
