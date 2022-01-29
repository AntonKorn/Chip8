
namespace Windows.Components
{
    partial class CpuStackControl
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
            this.dgvStack = new System.Windows.Forms.DataGridView();
            this.clmAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStack)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStack
            // 
            this.dgvStack.AllowUserToAddRows = false;
            this.dgvStack.AllowUserToDeleteRows = false;
            this.dgvStack.AllowUserToResizeColumns = false;
            this.dgvStack.AllowUserToResizeRows = false;
            this.dgvStack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStack.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmAddress,
            this.clmValue});
            this.dgvStack.Location = new System.Drawing.Point(3, 3);
            this.dgvStack.Name = "dgvStack";
            this.dgvStack.RowHeadersWidth = 62;
            this.dgvStack.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvStack.RowTemplate.Height = 33;
            this.dgvStack.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvStack.Size = new System.Drawing.Size(335, 476);
            this.dgvStack.TabIndex = 0;
            this.dgvStack.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStack_CellEndEdit);
            // 
            // clmAddress
            // 
            this.clmAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.clmAddress.HeaderText = "Address";
            this.clmAddress.MinimumWidth = 8;
            this.clmAddress.Name = "clmAddress";
            this.clmAddress.ReadOnly = true;
            this.clmAddress.Width = 113;
            // 
            // clmValue
            // 
            this.clmValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.clmValue.HeaderText = "Value";
            this.clmValue.MinimumWidth = 8;
            this.clmValue.Name = "clmValue";
            this.clmValue.Width = 90;
            // 
            // CpuStackControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvStack);
            this.Name = "CpuStackControl";
            this.Size = new System.Drawing.Size(354, 490);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStack;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmValue;
    }
}
