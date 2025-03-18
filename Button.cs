using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Program
{
    [DefaultEvent("Click")]
    public class ButtonPolina : Button
    {
        public delegate void PolinaEventHandler(object sender, EventArgs e);

        [Category("Polina Custom Design")]
        [Description("Fires when the ButtonPolina is clicked, in addition to the standard Click event.")]
        public event PolinaEventHandler PolinaEvent;

        private Color primaryColor = Color.Blue;
        private Color secondaryColor = Color.Red;
        private int primaryTransparency = 128;
        private int secondaryTransparency = 128;

        [Category("Polina Custom Design")]
        [Description("The primary color used in the custom button design.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color PrimaryColor
        {
            get { return primaryColor; }
            set { primaryColor = value; Invalidate(); }
        }

        [Category("Polina Custom Design")]
        [Description("The secondary color used in the custom button design.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color SecondaryColor
        {
            get { return secondaryColor; }
            set { secondaryColor = value; Invalidate(); }
        }

        [Category("Polina Custom Design")]
        [Description("Transparency level (0-255) for the primary color.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int PrimaryTransparency
        {
            get { return primaryTransparency; }
            set { primaryTransparency = Math.Max(0, Math.Min(255, value)); Invalidate(); }
        }

        [Category("Polina Custom Design")]
        [Description("Transparency level (0-255) for the secondary color.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]

        public int SecondaryTransparency
        {
            get { return secondaryTransparency; }
            set { secondaryTransparency = Math.Max(0, Math.Min(255, value)); Invalidate(); }
        }

        [Category("Polina Custom Design")]
        [Description("The text displayed on the ButtonPolina control.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            PolinaEvent?.Invoke(this, e);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            using (SolidBrush primaryBrush = new SolidBrush(Color.FromArgb(primaryTransparency, primaryColor)))
            using (SolidBrush secondaryBrush = new SolidBrush(Color.FromArgb(secondaryTransparency, secondaryColor)))
            {
                Rectangle rect = ClientRectangle;
                int halfWidth = rect.Width / 2;
                int halfHeight = rect.Height / 2;

                Rectangle topLeft = new Rectangle(0, 0, halfWidth, halfHeight);
                pevent.Graphics.FillRectangle(primaryBrush, topLeft);

                Rectangle bottomRight = new Rectangle(halfWidth, halfHeight, rect.Width - halfWidth, rect.Height - halfHeight);
                pevent.Graphics.FillRectangle(secondaryBrush, bottomRight);
            }
        }
    }
}
