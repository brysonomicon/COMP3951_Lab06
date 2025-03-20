using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace _3951_Lab6_Bryson_Polina
{
    // Custom button with extended functionality
    [DefaultEvent("Click")]
    public class ButtonPolina : Button
    {
        // Delegate for the custom event
        public delegate void PolinaEventHandler(object sender, EventArgs e);

        // Custom event that fires in addition to the standard Click event
        [Category("Polina Custom Design")]
        [Description("Fires when the ButtonPolina is clicked, in addition to the standard Click event.")]
        public event PolinaEventHandler PolinaEvent;

        // Primary and secondary colors with transparency
        private Color primaryColor = Color.Blue;
        private Color secondaryColor = Color.Red;
        private int primaryTransparency = 128;
        private int secondaryTransparency = 128;

        // Color selected via the designer or at runtime
        private Color selectedColor = Color.Empty;
        [Category("Polina Custom Design")]
        [Description("The selected color to update the button's rectangle when clicked.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color SelectedColor
        {
            get { return selectedColor; }
            set { selectedColor = value; }
        }

        // Flag to alternate color update between primary and secondary
        private bool updatePrimary = true;

        // Property for the primary color with automatic redraw
        [Category("Polina Custom Design")]
        [Description("The primary color used in the custom button design.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color PrimaryColor
        {
            get { return primaryColor; }
            set { primaryColor = value; Invalidate(); }
        }

        // Property for the secondary color with automatic redraw
        [Category("Polina Custom Design")]
        [Description("The secondary color used in the custom button design.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color SecondaryColor
        {
            get { return secondaryColor; }
            set { secondaryColor = value; Invalidate(); }
        }

        // Property for primary transparency ensuring value is between 0 and 255
        [Category("Polina Custom Design")]
        [Description("Transparency level (0-255) for the primary color.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int PrimaryTransparency
        {
            get { return primaryTransparency; }
            set { primaryTransparency = Math.Max(0, Math.Min(255, value)); Invalidate(); }
        }

        // Property for secondary transparency ensuring value is between 0 and 255
        [Category("Polina Custom Design")]
        [Description("Transparency level (0-255) for the secondary color.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int SecondaryTransparency
        {
            get { return secondaryTransparency; }
            set { secondaryTransparency = Math.Max(0, Math.Min(255, value)); Invalidate(); }
        }

        // Override Text property
        [Category("Polina Custom Design")]
        [Description("The text displayed on the ButtonPolina control.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        // Override OnClick to update colors based on SelectedColor and fire custom event
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (selectedColor != Color.Empty)
            {
                if (updatePrimary)
                {
                    // Update primary color and transparency
                    PrimaryTransparency = selectedColor.A;
                    PrimaryColor = Color.FromArgb(255, selectedColor.R, selectedColor.G, selectedColor.B);
                }
                else
                {
                    // Update secondary color and transparency
                    SecondaryTransparency = selectedColor.A;
                    SecondaryColor = Color.FromArgb(255, selectedColor.R, selectedColor.G, selectedColor.B);
                }
                // Alternate between primary and secondary updates
                updatePrimary = !updatePrimary;
            }
            // Fire custom event if subscribed
            PolinaEvent?.Invoke(this, e);
        }

        // Custom painting for the button to display two colored rectangles
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            using (SolidBrush primaryBrush = new SolidBrush(Color.FromArgb(primaryTransparency, primaryColor)))
            using (SolidBrush secondaryBrush = new SolidBrush(Color.FromArgb(secondaryTransparency, secondaryColor)))
            {
                Rectangle rect = ClientRectangle;
                int halfWidth = rect.Width / 2;
                int halfHeight = rect.Height / 2;

                // Draw top-left rectangle with primary color
                Rectangle topLeft = new Rectangle(0, 0, halfWidth, halfHeight);
                pevent.Graphics.FillRectangle(primaryBrush, topLeft);

                // Draw bottom-right rectangle with secondary color
                Rectangle bottomRight = new Rectangle(halfWidth, halfHeight, rect.Width - halfWidth, rect.Height - halfHeight);
                pevent.Graphics.FillRectangle(secondaryBrush, bottomRight);
            }
        }
    }
}
