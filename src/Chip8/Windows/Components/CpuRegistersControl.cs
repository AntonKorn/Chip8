﻿using Chip8.Core.Contracts;
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
        private const int IndexRegisterNumber = 0xF + 1;
        private const int StackPointerRegisterNumber = 0xF + 2;
        private const int ProgramCounterRegisterNumber = 0xF + 3;
        private const int DelayTimerRegisterNumber = 0xF + 4;
        private const int SoundTimerRegisterNumber = 0xF + 5;


        private ICpu _cpu;

        public CpuRegistersControl()
        {
            InitializeComponent();

            InitCpuRegisterRows();
        }

        public void Init(ICpu cpu)
        {
            _cpu = cpu;
        }

        public void UpdateGrid()
        {
            for (var i = 0; i < _cpu.Registers.Length; i++)
            {
                dgvRegisters.Rows[i].Cells[1].Value = _cpu.Registers[i].ToString("X");
            }

            dgvRegisters.Rows[StackPointerRegisterNumber].Cells[1].Value = _cpu.SP.ToString("X");
            dgvRegisters.Rows[IndexRegisterNumber].Cells[1].Value = _cpu.I.ToString("X");
            dgvRegisters.Rows[ProgramCounterRegisterNumber].Cells[1].Value = _cpu.PC.ToString("X");
            dgvRegisters.Rows[DelayTimerRegisterNumber].Cells[1].Value = _cpu.DT.ToString("X");
            dgvRegisters.Rows[SoundTimerRegisterNumber].Cells[1].Value = _cpu.ST.ToString("X");
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
            dgvRegisters.Rows.Add(CreateGridRow("DT"));
            dgvRegisters.Rows.Add(CreateGridRow("ST"));
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
