using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace _3951_Lab6_Bryson_Polina
{
    public partial class UserControlRGBSelectorPolina : UserControl
    {
        public UserControlRGBSelectorPolina()
        {
            InitializeComponent();
            trackBarAlpha.Value = 255;
            trackBarRed.Value = 0;
            trackBarGreen.Value = 0;
            trackBarBlue.Value = 0;
            UpdateColorPreview();
        }

        [Category("Polina Custom Design")]
        [Description("The color selected by the RGBA selector.")]
        public Color SelectedColor
        {
            get { return Color.FromArgb(trackBarAlpha.Value, trackBarRed.Value, trackBarGreen.Value, trackBarBlue.Value); }
        }

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            UpdateColorPreview();
        }

        private void UpdateColorPreview()
        {
            panelColorPreview.BackColor = SelectedColor;
            labelRGB.Text = $"RGBA({trackBarRed.Value}, {trackBarGreen.Value}, {trackBarBlue.Value}, {trackBarAlpha.Value})";
        }
    }
}
