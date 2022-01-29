using Chip8.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Core.CpuCommandExecutors.Helpers
{
    internal static class RuntimeExceptionsHelper
    {
        [DoesNotReturn]
        public static void ThrowStackOverflow()
        {
            throw new ChipRuntimeException("Stack Overflow");
        }

        [DoesNotReturn]
        public static void ThrowStackCorrupted()
        {
            throw new ChipRuntimeException("Stack Corrupted");
        }
    }
}
