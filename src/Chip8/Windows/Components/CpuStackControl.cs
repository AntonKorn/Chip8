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
    public partial class CpuStackControl : UserControl
    {
        private ICpu _cpu;
        private const int StackSize = 0xF + 1;

        public CpuStackControl()
        {
            InitializeComponent();
            InitTable();
        }

        public void Init(ICpu cpu)
        {
            _cpu = cpu;
        }

        public void UpdateGrid()
        {
            for (var i = 0; i < _cpu.Stack.Length; i++)
            {
                dgvStack.Rows[i].Cells[1].Value = _cpu.Stack[i].ToString();
            }
        }

        private void dgvStack_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //var stackIndex = e.RowIndex;
            //var editedCell = dgvStack.Rows[e.RowIndex].Cells[e.ColumnIndex];
            //var newValue = editedCell.Value;

            //var isValid = int.TryParse(newValue) && 
        }

        private void InitTable()
        {
            dgvStack.Rows.Clear();

            for (var i = 0; i < StackSize; i++)
            {
                var row = CreateStackRow(i);
                dgvStack.Rows.Add(row);
            }
        }

        private DataGridViewRow CreateStackRow(int address)
        {
            var row = new DataGridViewRow();
            var addressColumn = new DataGridViewTextBoxCell();
            addressColumn.Value = address.ToString("X");
            var valueColumn = new DataGridViewTextBoxCell();

            row.Cells.Add(addressColumn);
            row.Cells.Add(valueColumn);

            return row;
        }
    }
}
