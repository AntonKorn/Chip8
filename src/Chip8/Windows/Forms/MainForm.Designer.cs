
namespace Windows.Forms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.emulatorDisplayControl = new Windows.Components.EmulatorDisplayControl();
            this.cpuRegistersControl = new Windows.Components.CpuRegistersControl();
            this.btnNext = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.cpuStackControl = new Windows.Components.CpuStackControl();
            this.ofdRam = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // emulatorDisplayControl
            // 
            this.emulatorDisplayControl.BackgroundColor = System.Drawing.Color.White;
            this.emulatorDisplayControl.GraphicalDeviceState = null;
            this.emulatorDisplayControl.Location = new System.Drawing.Point(12, 92);
            this.emulatorDisplayControl.Name = "emulatorDisplayControl";
            this.emulatorDisplayControl.PixelColor = System.Drawing.Color.Black;
            this.emulatorDisplayControl.Size = new System.Drawing.Size(1086, 570);
            this.emulatorDisplayControl.TabIndex = 0;
            // 
            // cpuRegistersControl
            // 
            this.cpuRegistersControl.Location = new System.Drawing.Point(1435, 92);
            this.cpuRegistersControl.Name = "cpuRegistersControl";
            this.cpuRegistersControl.Size = new System.Drawing.Size(253, 668);
            this.cpuRegistersControl.TabIndex = 1;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(12, 52);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(112, 34);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1709, 33);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpen});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // tsmiOpen
            // 
            this.tsmiOpen.Name = "tsmiOpen";
            this.tsmiOpen.Size = new System.Drawing.Size(270, 34);
            this.tsmiOpen.Text = "Open";
            this.tsmiOpen.Click += new System.EventHandler(this.tsmiOpen_Click);
            // 
            // cpuStackControl
            // 
            this.cpuStackControl.Location = new System.Drawing.Point(1141, 92);
            this.cpuStackControl.Name = "cpuStackControl";
            this.cpuStackControl.Size = new System.Drawing.Size(288, 668);
            this.cpuStackControl.TabIndex = 4;
            // 
            // ofdRam
            // 
            this.ofdRam.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1709, 803);
            this.Controls.Add(this.cpuStackControl);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.cpuRegistersControl);
            this.Controls.Add(this.emulatorDisplayControl);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Components.EmulatorDisplayControl emulatorDisplayControl;
        private Components.CpuRegistersControl cpuRegistersControl;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpen;
        private Components.CpuStackControl cpuStackControl;
        private System.Windows.Forms.OpenFileDialog ofdRam;
    }
}

