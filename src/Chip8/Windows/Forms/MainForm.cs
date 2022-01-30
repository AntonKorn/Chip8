using Chip8.Core;
using Chip8.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows.Forms
{
    public partial class MainForm : Form
    {
        private EmulatorContext _emulatorContext;
        private Thread _thread;
        private int _until;

        public MainForm()
        {
            InitializeComponent();

            _emulatorContext = new DefaultEmulatorFactory().CreateEmulatorInstance();
            _emulatorContext.Initialize();
            emulatorDisplayControl.GraphicalDeviceState = _emulatorContext.GraphicalDevice;
            cpuStackControl.Init(_emulatorContext.Cpu);
            cpuRegistersControl.Init(_emulatorContext.Cpu);

            cpuRegistersControl.UpdateGrid();
            cpuStackControl.UpdateGrid();

            //var letter = new byte[]
            //{
            //    0xF0, 0x80, 0xF0, 0x80, 0xF0
            //};
            //_emulatorContext.GraphicalDevice.DrawSprite(new DrawSpriteCommand(10, 20, letter.Select(i => (int)i).ToArray()));
            //emulatorDisplayControl.Redraw();
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            if (ofdRam.ShowDialog() == DialogResult.OK)
            {
                var ramFile = ofdRam.FileName;
                var cotents = File.ReadAllBytes(ramFile);
                _emulatorContext.Manager.LoadRom(cotents);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _emulatorContext.Manager.TryExecuteNext();
            emulatorDisplayControl.Redraw();
            cpuRegistersControl.UpdateGrid();
            cpuStackControl.UpdateGrid();
        }

        private void btnSkipUntil_Click(object sender, EventArgs e)
        {
            _until = int.Parse(tbUntil.Text, NumberStyles.HexNumber);
            _thread = new Thread(Run);
            _thread.Start();
        }

        private void Run()
        {
            var i = 0;
            while(_emulatorContext.Cpu.PC != _until)
            {
                _emulatorContext.Manager.TryExecuteNext();
                Invoke((Action)(() => emulatorDisplayControl.Redraw()));
                Thread.Sleep(1);
            }
        }
    }
}
