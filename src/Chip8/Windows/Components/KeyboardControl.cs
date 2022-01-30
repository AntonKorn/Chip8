using Chip8.Core.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows.Components
{
    public partial class KeyboardControl : UserControl
    {
        public Color ClickedColor = Color.Blue;
        public Color UnClickedColor = Color.LightGray;

        private Button _previousButton;
        private IKeyboard _keyboard;

        public KeyboardControl()
        {
            InitializeComponent();
        }

        public void Init(IKeyboard keyboard)
        {
            _keyboard = keyboard;
        }

        private void btnKey_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            button.BackColor = ClickedColor;
            if (_previousButton != null)
            {
                _previousButton.BackColor = UnClickedColor;
            }
            var currentKey = int.Parse(button.Tag.ToString(), NumberStyles.HexNumber);

            if (_previousButton == button)
            {
                _keyboard.UnsetKey();
                _previousButton = null;
            }
            else
            {
                _keyboard.SetKey(currentKey);
                _previousButton = button;
            }
        }
    }
}
