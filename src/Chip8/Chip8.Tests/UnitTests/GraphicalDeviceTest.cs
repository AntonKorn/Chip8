using Chip8.Core;
using Chip8.Core.Contracts;
using Chip8.Internal.Services;
using Chip8.Tests.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Tests.UnitTests
{
    public class GraphicalDeviceTest
    {
        private GraphicalDeviceState _graphicalDevice = null!;

        [SetUp]
        public void Setup()
        {
            _graphicalDevice = new GraphicalDeviceState();
        }

        [Test]
        public void ShouldDrawSimpleSprite()
        {
            var command = new DrawSpriteCommand(3, 5,
                new int[]
                {
                    0b00011111,
                    0b00000010,
                    0b00001111,
                    0b00000000,
                    0b00011100,
                });

            var expectedScreen = GraphicalDeviceHelper.CompleteFromLeftTop(
                "",
                "",
                "",
                "",
                "",
                "00000011111",
                "00000000010",
                "00000001111",
                "00000000000",
                "00000011100"
                );

            var result = _graphicalDevice.DrawSprite(command);

            Assert.AreEqual(expectedScreen, _graphicalDevice.GetFullScreen());
            Assert.IsFalse(result.Erased);
        }

        [Test]
        public void ShouldDrawOverlappingSpritesWithoutErase()
        {
            var firstCommand = new DrawSpriteCommand(3, 5,
                new int[]
                {
                    0b00011111,
                    0b00000010,
                    0b00001111,
                    0b00000000,
                    0b00011100,
                });

            var seconCommand = new DrawSpriteCommand(3, 5,
                new int[]
                {
                    0b11000000,
                    0b11110000,
                    0b11110000,
                    0b01111111,
                    0b01100011,
                });

            var expectedScreen = GraphicalDeviceHelper.CompleteFromLeftTop(
                "",
                "",
                "",
                "",
                "",
                "00011011111",
                "00011110010",
                "00011111111",
                "00001111111",
                "00001111111"
                );

            _graphicalDevice.DrawSprite(firstCommand);
            var result = _graphicalDevice.DrawSprite(seconCommand);

            Assert.AreEqual(expectedScreen, _graphicalDevice.GetFullScreen());
            Assert.IsFalse(result.Erased);
        }

        [Test]
        public void ShouldDrawOverlappingSpritesWithErase()
        {
            var firstCommand = new DrawSpriteCommand(3, 5,
                new int[]
                {
                    0b00011111,
                    0b00000010,
                    0b00001111,
                    0b00000000,
                    0b00011100,
                });

            var seconCommand = new DrawSpriteCommand(3, 5,
                new int[]
                {
                    0b00011000,
                    0b11110000,
                    0b11110011,
                    0b01111111,
                    0b01100011,
                });

            var expectedScreen = GraphicalDeviceHelper.CompleteFromLeftTop(
                "",
                "",
                "",
                "",
                "",
                "00000000111",
                "00011110010",
                "00011111100",
                "00001111111",
                "00001111111"
                );

            _graphicalDevice.DrawSprite(firstCommand);
            var result = _graphicalDevice.DrawSprite(seconCommand);

            Assert.AreEqual(expectedScreen, _graphicalDevice.GetFullScreen());
            Assert.IsTrue(result.Erased);
        }

        [Test]
        public void ShouldOverflowSpriteToTheBeginningOfRow()
        {
            var command = new DrawSpriteCommand(60, 5,
                new int[]
                {
                    0b00011111,
                    0b00000010,
                    0b00001111,
                    0b00000000,
                    0b00011100,
                });

            var expectedScreen = GraphicalDeviceHelper.CompleteBetweenFromTop(
                ("", ""),
                ("", ""),
                ("", ""),
                ("", ""),
                ("", ""),
                ("1111", "1"),
                ("001", ""),
                ("1111", ""),
                ("", ""),
                ("1100", "0001")
                );

            var result = _graphicalDevice.DrawSprite(command);

            Assert.AreEqual(expectedScreen, _graphicalDevice.GetFullScreen());
            Assert.IsFalse(result.Erased);
        }

        [Test]
        public void ShouldWrapOverflowedCharacterToStartOfDimention()
        {
            var command = new DrawSpriteCommand(60, 30,
                new int[]
                {
                    0b00011111,
                    0b00000010,
                    0b00001111,
                    0b00000000,
                    0b00011100,
                });

            var expectedScreen = GraphicalDeviceHelper.CompleteBetween(
                    new (string Left, string Right)[]
                    {
                        ("1111", ""),
                        ("", ""),
                        ("1100", "0001")
                    },
                    new (string Left, string Right)[]
                    {
                        ("1111", "1"),
                        ("001", ""),
                    }
                );

            var result = _graphicalDevice.DrawSprite(command);

            Assert.AreEqual(expectedScreen, _graphicalDevice.GetFullScreen());
            Assert.IsFalse(result.Erased);
        }
    }
}
