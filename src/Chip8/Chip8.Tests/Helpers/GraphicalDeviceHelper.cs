using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Tests.Helpers
{
    public static class GraphicalDeviceHelper
    {
        private static int ROW_SIZE = 64;
        private static int COLUMNS = 32;

        public static bool[][] CompleteFromLeftTop(params string[] lines)
        {
            return lines
                .Select(l => l.Select(c => c == '1').Concat(Enumerable.Repeat(false, ROW_SIZE - l.Length)).ToArray())
                .Concat(
                    Enumerable
                        .Repeat(0, COLUMNS - lines.Length)
                        .Select(_ => Enumerable.Repeat(false, ROW_SIZE).ToArray())
                        )
                .ToArray();
        }

        public static bool[][] CompleteBetweenFromTop(params (string Left, string Right)[] lines)
        {
            return lines
                .Select(l =>
                    l.Left
                        .Select(c => c == '1')
                        .Concat(Enumerable.Repeat(false, ROW_SIZE - l.Left.Length - l.Right.Length))
                        .Concat(l.Right.Select(c => c == '1'))
                        .ToArray())
                .Concat(
                    Enumerable
                        .Repeat(0, COLUMNS - lines.Length)
                        .Select(_ => Enumerable.Repeat(false, ROW_SIZE).ToArray())
                        )
                .ToArray();
        }

        public static bool[][] CompleteBetween((string Left, string Right)[] top, (string Left, string Right)[] bottom)
        {
            return top
                .Select(l =>
                    l.Left
                        .Select(c => c == '1')
                        .Concat(Enumerable.Repeat(false, ROW_SIZE - l.Left.Length - l.Right.Length))
                        .Concat(l.Right.Select(c => c == '1'))
                        .ToArray())
                .Concat(Enumerable
                        .Repeat(0, COLUMNS - top.Length - bottom.Length)
                        .Select(_ => Enumerable.Repeat(false, ROW_SIZE).ToArray())
                        )
                .Concat(
                    bottom
                        .Select(l =>
                            l.Left
                                .Select(c => c == '1')
                                .Concat(Enumerable.Repeat(false, ROW_SIZE - l.Left.Length - l.Right.Length))
                                .Concat(l.Right.Select(c => c == '1'))
                                .ToArray())
                    )
                .ToArray();
        }
    }
}
