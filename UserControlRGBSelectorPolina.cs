using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace _3951_Lab6_Bryson_Polina
{
    public partial class UserControlRGBSelectorPolina : UserControl
    {
        // Constructor initializes the control and sets default trackbar values
        public UserControlRGBSelectorPolina()
        {
            InitializeComponent();
            trackBarAlpha.Value = 255; // Default transparency to fully opaque
            trackBarRed.Value = 0;     // Default red component
            trackBarGreen.Value = 0;   // Default green component
            trackBarBlue.Value = 0;    // Default blue component
            UpdateColorPreview();      // Refresh the color preview
        }

        // Exposes the current selected color based on trackbar values
        [Category("Polina Custom Design")]
        [Description("The color selected by the RGBA selector.")]
        public Color SelectedColor
        {
            get { return Color.FromArgb(trackBarAlpha.Value, trackBarRed.Value, trackBarGreen.Value, trackBarBlue.Value); }
        }

        // Event handler for trackbar value changes
        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            UpdateColorPreview(); // Update preview when any trackbar value changes
        }

        // Updates the color preview panel and the RGBA label text
        private void UpdateColorPreview()
        {
            panelColorPreview.BackColor = SelectedColor;
            labelRGB.Text = $"RGBA({trackBarRed.Value}, {trackBarGreen.Value}, {trackBarBlue.Value}, {trackBarAlpha.Value})";
        }
    }
}
