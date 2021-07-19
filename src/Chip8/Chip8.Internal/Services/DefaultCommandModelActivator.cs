using Chip8.Core;
using Chip8.Core.Attributes;
using Chip8.Core.Contracts;
using Chip8.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Internal.Services
{
    public class DefaultCommandModelActivator : ICommandModelActivator
    {
        private bool IsInitialized = false;
        private readonly ICommandRegistry _commandRegistry;
        private readonly IDictionary<string, Func<IDictionary<string, ParsedCommandParameter>, object>> _modelFactoriesCache
            = new Dictionary<string, Func<IDictionary<string, ParsedCommandParameter>, object>>();

        public DefaultCommandModelActivator(ICommandRegistry commandRegistry)
        {
            _commandRegistry = commandRegistry ?? throw new ArgumentNullException(nameof(commandRegistry));
        }

        public ActivationResult ActivateCommandModel(ParsedCommand parsedCommand)
        {
            if (!IsInitialized)
            {
                throw new CommandActivationException("Service was not initialzied");
            }

            try
            {
                var parametersMap = BuildParsedCommandParametersMap(parsedCommand);
                var factory = _modelFactoriesCache[parsedCommand.CommandDefinition.CommandModel.FullName!];
                var activatedModel = factory(parametersMap);
                return new ActivationResult(parsedCommand, activatedModel);
            }
            catch (Exception e)
            {
                throw new CommandActivationException("Activation failed", e);
            }
        }

        public void Initialize()
        {
            if (IsInitialized)
            {
                return;
            }

            try
            {
                var commands = _commandRegistry.GetAvailableCommands();
                if (!commands.Any())
                {
                    _commandRegistry.DiscoverLoadedCommands();
                    commands = _commandRegistry.GetAvailableCommands();
                }

                foreach (var command in commands)
                {
                    var modelType = command.CommandModel;
                    var commandFactory = CreateCommandFactoryWithLinqExpressionsAbstractSyntaxTree(modelType);
                    _modelFactoriesCache.Add(modelType.FullName!, commandFactory);
                }

                IsInitialized = true;
            }
            catch (Exception e)
            {
                throw new CommandActivationException("Failed to initialize activator", e);
            }
        }

        private IDictionary<string, ParsedCommandParameter> BuildParsedCommandParametersMap(ParsedCommand parsedCommand)
        {
            return parsedCommand.Parameters.ToDictionary(p => p.CpuCommandParameterDefenition.Code);
        }

        private Func<IDictionary<string, ParsedCommandParameter>, object> CreateCommandFactoryWithLinqExpressionsAbstractSyntaxTree(Type commandModelType)
        {
            var parameterExpression = Expression.Parameter(typeof(IDictionary<string, ParsedCommandParameter>));
            var commandVariable = Expression.Variable(commandModelType);

            var defaultConstructor = commandModelType.GetConstructor(Type.EmptyTypes);
            var assignment = Expression.Assign(commandVariable, Expression.New(defaultConstructor!));

            var dictionaryIndexProperty = typeof(IDictionary<string, ParsedCommandParameter>).GetProperty("Item");
            var commandPropertiesExpressions = commandModelType
                .GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
                .Where(p => p.GetCustomAttributes(typeof(CommandParameterAttribute), true).Any())
                .Select(p => new
                {
                    Expression = Expression.Property(commandVariable, p),
                    PropertyAttribute = p.GetCustomAttributes(typeof(CommandParameterAttribute), true).First() as CommandParameterAttribute
                })
                .Select(p =>
                    Expression.Assign(
                        p.Expression,
                        Expression.Property(
                            Expression.MakeIndex(
                                parameterExpression,
                                dictionaryIndexProperty,
                                new Expression[] { Expression.Constant(p.PropertyAttribute!.Code) }
                            ),
                            nameof(ParsedCommandParameter.Value)
                        )
                    )
                );

            var block = Expression.Block(
                           commandModelType,
                           new ParameterExpression[] {
                               commandVariable
                           },
                           new Expression[]
                           {
                               assignment,
                           }
                           .Concat(commandPropertiesExpressions)
                           .Concat(
                               new Expression[]
                               {
                                   commandVariable
                               }
                            )
                           .ToArray()
                        );

            return Expression.Lambda<Func<IDictionary<string, ParsedCommandParameter>, object>>(block, parameterExpression).Compile();
        }
    }
}
