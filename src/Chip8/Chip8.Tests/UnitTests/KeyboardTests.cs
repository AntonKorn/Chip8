using Chip8.Core.Contracts;
using Chip8.Internal.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8.Tests.UnitTests
{
    public class KeyboardTests
    {
        private IKeyboard _keyboard = null!;

        [SetUp]
        public void SetUp()
        {
            _keyboard = new DefaultKeyboard();
        }

        [Test]
        public void WhenNoKeyIsSetNoKeyIsAvailable()
        {
            Assert.IsNull(_keyboard.Key);
        }

        [Test]
        public void WhenKeyIsSelectedItIsAvailable()
        {
            var currentKey = 9;
            _keyboard.SetKey(currentKey);

            Assert.AreEqual(_keyboard.Key, currentKey);
            Assert.IsTrue(_keyboard.IsKeyPressed(currentKey));
        }

        [Test]
        public void WhenKeyIsUnsetNoKeysAreAvailable()
        {
            var currentKey = 9;
            _keyboard.SetKey(currentKey);

            Assert.AreEqual(_keyboard.Key, currentKey);

            _keyboard.UnsetKey();

            Assert.IsNull(_keyboard.Key);
            Assert.IsFalse(_keyboard.IsKeyPressed(currentKey));
        }
    }
}
