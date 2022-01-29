using Chip8.Core.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows.Components
{
    public partial class EmulatorDisplayControl : UserControl
    {

        private Color _pixelColor = Color.Black;
        private Brush _pixelBrush = new SolidBrush(Color.Black);

        public Color BackgroundColor { get; set; } = Color.White;
        public Color PixelColor
        {
            get => _pixelColor;
            set
            {
                _pixelBrush = new SolidBrush(value);
                _pixelColor = value;
            }
        }

        public IGraphicalDeviceState GraphicalDeviceState { get; set; }

        public EmulatorDisplayControl()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        public void Redraw()
        {
            Invalidate();
        }

        private void EmulatorDisplay_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(BackgroundColor);

            if (GraphicalDeviceState != null)
            {
                var emulatorHeight = GraphicalDeviceState.GetScreenHeight();
                var emulatorWidth = GraphicalDeviceState.GetScreenWidth();

                var pixelWidth = 1F * Width / emulatorWidth;
                var pixelHeight = 1F * Height / emulatorHeight;

                for (var column = 0; column < emulatorWidth; column++)
                {
                    for (var row = 0; row < emulatorHeight; row++)
                    {
                        var x = column * pixelWidth;
                        var y = row * pixelHeight;

                        if (GraphicalDeviceState.GetPixel(column, row))
                        {
                            e.Graphics.FillRectangle(_pixelBrush, x, y, pixelWidth, pixelHeight);
                        }
                    }
                }
            }
        }
    }
}
