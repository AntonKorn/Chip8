using Chip8.Core;
using Chip8.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows.Forms
{
    public partial class MainForm : Form
    {
        private EmulatorContext _emulatorContext;

        public MainForm()
        {
            InitializeComponent();

            _emulatorContext = new DefaultEmulatorFactory().CreateEmulatorInstance();
            _emulatorContext.Initialize();
            emulatorDisplayControl.GraphicalDeviceState = _emulatorContext.GraphicalDevice;

            var letter = new byte[]
            {
                0xF0, 0x80, 0xF0, 0x80, 0xF0
            };
            _emulatorContext.GraphicalDevice.DrawSprite(new DrawSpriteCommand(10, 20, letter.Select(i => (int)i).ToArray()));
            emulatorDisplayControl.Redraw();
        }
    }
}
