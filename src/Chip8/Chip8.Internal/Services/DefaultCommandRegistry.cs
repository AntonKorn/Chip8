﻿using Chip8.Core;
using Chip8.Core.Attributes;
using Chip8.Core.Contracts;
using Chip8.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Internal.Services
{
    public class DefaultCommandRegistry : ICommandRegistry
    {
        private IReadOnlyList<CpuCommandDefinition> _cpuCommandDefenitions = Enumerable.Empty<CpuCommandDefinition>().ToList();

        public void DiscoverLoadedCommands()
        {
            var loadedCommands = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes()
                    .Where(t => IsCommandModel(t))
                    .Select(t => MapCommandModelTypeToCpuCommandDefenition(t)))
                    .ToList();
            loadedCommands.Sort((x, y) => CompareCommandsSpecificity(x, y));

            _cpuCommandDefenitions = loadedCommands;
        }

        public IEnumerable<CpuCommandDefinition> GetAvailableCommands()
        {
            return _cpuCommandDefenitions;
        }

        private bool IsCommandModel(Type type)
        {
            return type.GetCustomAttributes(typeof(CommandModelAttribute), true).Any();
        }

        private bool IsCommandParameter(PropertyInfo property)
        {
            return property.GetCustomAttributes(typeof(CommandParameterAttribute), true).Any();
        }

        private CpuCommandDefinition MapCommandModelTypeToCpuCommandDefenition(Type type)
        {
            var commandDefenition =
                type.GetCustomAttribute(typeof(CommandModelAttribute), true) as CommandModelAttribute
                ?? throw new ArgumentException("Invalid command model");

            var compiledPattern = int.Parse(commandDefenition.Pattern.Replace("*", "0"), System.Globalization.NumberStyles.HexNumber);
            var compiledMask = int.Parse(
                new string(commandDefenition.Pattern.Select(c => c == '*' ? '0' : 'F').ToArray()),
                System.Globalization.NumberStyles.HexNumber);
            var cpuParameters = DiscoverCpuParameters(type);

            ValidateCpuCommandParameterDefenitions(cpuParameters, type, commandDefenition.Pattern);

            return new CpuCommandDefinition(compiledPattern, commandDefenition.OpcodeName, cpuParameters, type, compiledMask);
        }

        private IEnumerable<CpuCommandParameterDefinition> DiscoverCpuParameters(Type type)
        {
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.CanWrite && p.CanRead && IsCommandParameter(p))
                .Select(p => MapPropertyToCpuCommandParameterDefenition(p))
                .ToList();
        }

        private CpuCommandParameterDefinition MapPropertyToCpuCommandParameterDefenition(PropertyInfo property)
        {
            var commandDefenition =
                property.GetCustomAttribute(typeof(CommandParameterAttribute), true) as CommandParameterAttribute
                ?? throw new ArgumentException("Invalid parameter property");

            var compiledMask = (int)(Math.Pow(2, commandDefenition.NibblesCount * 4) - 1) << commandDefenition.NibbleIndex * 4;
            return new CpuCommandParameterDefinition(property.Name, commandDefenition.Code, compiledMask, commandDefenition.NibbleIndex);
        }

        private void ValidateCpuCommandParameterDefenitions(IEnumerable<CpuCommandParameterDefinition> parameterDefenitions, Type commandModelType, string commandPattern)
        {
            var multiplication = parameterDefenitions.Select(pd => pd.CompiledMask).Aggregate(0xFFFF, (x, y) => x & y);
            var anyMasksIntersect = multiplication != 0 && parameterDefenitions.Count() > 1;

            if (anyMasksIntersect)
            {
                throw new CommandsInitializationException("Some parameter masks intersect", commandModelType);
            }

            var parametersSectionMaskString = new string(commandPattern.Select(c => c != '*' ? '0' : 'F').ToArray());
            var parametersSectionMask = int.Parse(parametersSectionMaskString, System.Globalization.NumberStyles.HexNumber);
            var addition = parameterDefenitions.Select(pd => pd.CompiledMask).Aggregate(0x0000, (x, y) => x | y);
            var isCommandPatternMatchParametersPatterns = (addition & parametersSectionMask) == addition;

            if (!isCommandPatternMatchParametersPatterns)
            {
                throw new CommandsInitializationException("Parameters masks do not match command mask", commandModelType);
            }
        }

        private int CompareCommandsSpecificity(CpuCommandDefinition x, CpuCommandDefinition y)
        {
            if (IsOpcodeMatch(y.CompiledPattern, x))
            {
                return 1;
            }

            if (IsOpcodeMatch(x.CompiledPattern, y))
            {
                return -1;
            }

            return 0;
        }

        private bool IsOpcodeMatch(int opcode, CpuCommandDefinition cpuCommandDefenition)
        {
            return (opcode & cpuCommandDefenition.CompiledMask) == cpuCommandDefenition.CompiledPattern;
        }
    }
}
