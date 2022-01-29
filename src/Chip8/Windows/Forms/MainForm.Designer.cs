
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
            this.SuspendLayout();
            // 
            // emulatorDisplayControl
            // 
            this.emulatorDisplayControl.BackgroundColor = System.Drawing.Color.White;
            this.emulatorDisplayControl.GraphicalDeviceState = null;
            this.emulatorDisplayControl.Location = new System.Drawing.Point(12, 12);
            this.emulatorDisplayControl.Name = "emulatorDisplayControl";
            this.emulatorDisplayControl.PixelColor = System.Drawing.Color.Black;
            this.emulatorDisplayControl.Size = new System.Drawing.Size(1086, 570);
            this.emulatorDisplayControl.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 772);
            this.Controls.Add(this.emulatorDisplayControl);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Components.EmulatorDisplayControl emulatorDisplayControl;
    }
}

