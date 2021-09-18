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
        private static int ROWS = 32;

        public static bool[][] CompleteFromLeftTop(params string[] lines)
        {
            return lines
                .Select(l => l.Select(IsActiveScreenPixel).Concat(EnumerateMissingPixels(l.Length)).ToArray())
                .Concat(EnumerateMissingScreenRows(lines.Length))
                .ToArray();
        }

        public static bool[][] CompleteBetweenFromTop(params (string Left, string Right)[] lines)
        {
            return lines
                .Select(l => CompleteScreenRow(l.Left, l.Right))
                .Concat(EnumerateMissingScreenRows(lines.Length))
                .ToArray();
        }

        public static bool[][] CompleteBetween((string Left, string Right)[] top, (string Left, string Right)[] bottom)
        {
            return top
                .Select(l => CompleteScreenRow(l.Left, l.Right))
                .Concat(EnumerateMissingScreenRows(top.Length + bottom.Length))
                .Concat(bottom.Select(l => CompleteScreenRow(l.Left, l.Right)))
                .ToArray();
        }

        private static bool[] CompleteScreenRow(string left, string right)
        {
            return left
                .Select(IsActiveScreenPixel)
                .Concat(EnumerateMissingPixels(left.Length + right.Length))
                .Concat(right.Select(c => c == '1'))
                .ToArray();
        }

        private static IEnumerable<bool> EnumerateMissingPixels(int alreadyAddedCount)
        {
            return Enumerable.Repeat(false, ROW_SIZE - alreadyAddedCount);
        }

        private static IEnumerable<bool[]> EnumerateMissingScreenRows(int alreadyAddedCount)
        {
            return Enumerable
                .Repeat(0, ROWS - alreadyAddedCount)
                .Select(_ => Enumerable.Repeat(false, ROW_SIZE).ToArray());
        }

        private static bool IsActiveScreenPixel(char c) => c == '1';
    }
}
