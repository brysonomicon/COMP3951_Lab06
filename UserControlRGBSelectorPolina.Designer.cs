namespace _3951_Lab6_Bryson_Polina
{
    partial class UserControlRGBSelectorPolina
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TrackBar trackBarRed;
        private System.Windows.Forms.TrackBar trackBarGreen;
        private System.Windows.Forms.TrackBar trackBarBlue;
        private System.Windows.Forms.Panel panelColorPreview;
        private System.Windows.Forms.Label labelRGB;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            trackBarRed = new TrackBar();
            trackBarGreen = new TrackBar();
            trackBarBlue = new TrackBar();
            panelColorPreview = new Panel();
            labelRGB = new Label();
            ((System.ComponentModel.ISupportInitialize)trackBarRed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarGreen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarBlue).BeginInit();
            SuspendLayout();
            // 
            // trackBarRed
            // 
            trackBarRed.Location = new Point(10, 10);
            trackBarRed.Maximum = 255;
            trackBarRed.Name = "trackBarRed";
            trackBarRed.Size = new Size(150, 45);
            trackBarRed.TabIndex = 0;
            trackBarRed.TickFrequency = 5;
            trackBarRed.ValueChanged += trackBar_ValueChanged;
            // 
            // trackBarGreen
            // 
            trackBarGreen.Location = new Point(10, 60);
            trackBarGreen.Maximum = 255;
            trackBarGreen.Name = "trackBarGreen";
            trackBarGreen.Size = new Size(150, 45);
            trackBarGreen.TabIndex = 1;
            trackBarGreen.TickFrequency = 5;
            trackBarGreen.ValueChanged += trackBar_ValueChanged;
            // 
            // trackBarBlue
            // 
            trackBarBlue.Location = new Point(10, 110);
            trackBarBlue.Maximum = 255;
            trackBarBlue.Name = "trackBarBlue";
            trackBarBlue.Size = new Size(150, 45);
            trackBarBlue.TabIndex = 2;
            trackBarBlue.TickFrequency = 5;
            trackBarBlue.ValueChanged += trackBar_ValueChanged;
            // 
            // panelColorPreview
            // 
            panelColorPreview.BorderStyle = BorderStyle.FixedSingle;
            panelColorPreview.Location = new Point(170, 10);
            panelColorPreview.Name = "panelColorPreview";
            panelColorPreview.Size = new Size(100, 100);
            panelColorPreview.TabIndex = 3;
            // 
            // labelRGB
            // 
            labelRGB.AutoSize = true;
            labelRGB.Location = new Point(170, 115);
            labelRGB.Name = "labelRGB";
            labelRGB.Size = new Size(61, 15);
            labelRGB.TabIndex = 4;
            labelRGB.Text = "RGB(0,0,0)";
            // 
            // UserControlRGBSelectorPolina
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(labelRGB);
            Controls.Add(panelColorPreview);
            Controls.Add(trackBarBlue);
            Controls.Add(trackBarGreen);
            Controls.Add(trackBarRed);
            Name = "UserControlRGBSelectorPolina";
            Size = new Size(300, 170);
            ((System.ComponentModel.ISupportInitialize)trackBarRed).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarGreen).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarBlue).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}

