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
    public partial class CpuRegistersControl : UserControl
    {
        private const int MaxCommonRegisterNumber = 0xF;

        public CpuRegistersControl()
        {
            InitializeComponent();

            InitCpuRegisterRows();
        }

        private void InitCpuRegisterRows()
        {
            dgvRegisters.Rows.Clear();

            for (var i = 0; i <= MaxCommonRegisterNumber; i++)
            {
                var row = CreateGridRow(i.ToString());
                dgvRegisters.Rows.Add(row);
            }

            dgvRegisters.Rows.Add(CreateGridRow("I"));
            dgvRegisters.Rows.Add(CreateGridRow("SP"));
            dgvRegisters.Rows.Add(CreateGridRow("PC"));
        }

        private DataGridViewRow CreateGridRow(string registerName)
        {
            var row = new DataGridViewRow();
            var registerNameCell = new DataGridViewTextBoxCell();
            registerNameCell.Value = registerName;
            var registerValueCell = new DataGridViewTextBoxCell();

            row.Cells.Add(registerNameCell);
            row.Cells.Add(registerValueCell);

            return row;
        }
    }
}
