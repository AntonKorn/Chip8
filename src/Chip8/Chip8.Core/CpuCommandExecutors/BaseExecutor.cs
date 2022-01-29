using Chip8.Core.CpuCommandExecutors.Helpers;
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

        protected void Push(ExecutionContext context, int value)
        {
            var sp = ++context.Cpu.SP;
            ValidateStackPointer(context);
            context.Cpu.Stack[sp] = value;
        }

        protected int Pop(ExecutionContext context)
        {
            var sp = context.Cpu.SP--;
            ValidateStackPointer(context);
            return context.Cpu.Stack[sp];
        }

        protected void Next(ExecutionContext context)
        {
            context.Cpu.PC += 2;
        }

        protected void ValidateStackPointer(ExecutionContext context)
        {
            if (context.Cpu.SP > 0xF)
            {
                RuntimeExceptionsHelper.ThrowStackOverflow();
            }

            if (context.Cpu.SP < 0)
            {
                RuntimeExceptionsHelper.ThrowStackCorrupted();
            }
        }
    }
}
