
namespace Windows.Components
{
    partial class CpuRegistersControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvRegisters = new System.Windows.Forms.DataGridView();
            this.clmRegisterNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRegisterValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegisters)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRegisters
            // 
            this.dgvRegisters.AllowUserToAddRows = false;
            this.dgvRegisters.AllowUserToDeleteRows = false;
            this.dgvRegisters.AllowUserToResizeColumns = false;
            this.dgvRegisters.AllowUserToResizeRows = false;
            this.dgvRegisters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRegisters.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvRegisters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegisters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmRegisterNumber,
            this.clmRegisterValue});
            this.dgvRegisters.Location = new System.Drawing.Point(0, 0);
            this.dgvRegisters.Name = "dgvRegisters";
            this.dgvRegisters.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvRegisters.RowTemplate.Height = 33;
            this.dgvRegisters.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvRegisters.Size = new System.Drawing.Size(239, 611);
            this.dgvRegisters.TabIndex = 0;
            // 
            // clmRegisterNumber
            // 
            this.clmRegisterNumber.HeaderText = "Register";
            this.clmRegisterNumber.MinimumWidth = 8;
            this.clmRegisterNumber.Name = "clmRegisterNumber";
            this.clmRegisterNumber.ReadOnly = true;
            this.clmRegisterNumber.Width = 111;
            // 
            // clmRegisterValue
            // 
            this.clmRegisterValue.HeaderText = "Value";
            this.clmRegisterValue.MinimumWidth = 8;
            this.clmRegisterValue.Name = "clmRegisterValue";
            this.clmRegisterValue.Width = 90;
            // 
            // CpuRegistersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvRegisters);
            this.Name = "CpuRegistersControl";
            this.Size = new System.Drawing.Size(242, 614);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegisters)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRegisters;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRegisterNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRegisterValue;
    }
}
