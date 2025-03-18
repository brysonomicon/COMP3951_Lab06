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
            trackBarRed.Value = 0;
            trackBarGreen.Value = 0;
            trackBarBlue.Value = 0;
            UpdateColorPreview();
        }

        [Category("Polina Custom Design")]
        [Description("The color selected by the RGB selector.")]
        public Color SelectedColor
        {
            get { return Color.FromArgb(trackBarRed.Value, trackBarGreen.Value, trackBarBlue.Value); }
        }

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            UpdateColorPreview();
        }

        private void UpdateColorPreview()
        {
            panelColorPreview.BackColor = SelectedColor;
            labelRGB.Text = $"RGB({trackBarRed.Value}, {trackBarGreen.Value}, {trackBarBlue.Value})";
        }
    }
}
