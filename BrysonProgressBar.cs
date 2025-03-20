using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3951_Lab6_Bryson_Polina
{
    /// <summary>
    /// Custom progress bar that extends the built-in ProgressBar.
    /// Displays different colors depending on what phase of completion and has a boolean
    /// that shows/hides the progress if you want.
    /// </summary>
    public partial class BrysonProgressBar : ProgressBar
    {
        /// <summary>
        /// Enum for the different phases of completion that will trigger
        /// the change of state.
        /// </summary>
        private enum CompletionPhase
        {
            NotStarted,
            Beginning,
            Halfway,
            NearingCompletion,
            Complete
        }

        private CompletionPhase _currentPhase = CompletionPhase.NotStarted;

        public event EventHandler ValueChanged;
        public event EventHandler StateChanged;

        private bool _showText = true;

        /// <summary>
        /// Constructor that sets the default values and sets user paint to true to enable
        /// custom drawing.
        /// </summary>
        public BrysonProgressBar()
        {
            this.SetStyle(ControlStyles.UserPaint, true);

            this.Minimum = 0;
            this.Maximum = 100;
            this.Value = 0;
            this.Size = new Size(200, 23);
        }

        /// <summary>
        /// Controls whether the progress bar should display text or not.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowText
        {
            get => _showText;
            set
            {
                _showText = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Overrides the default progress bar value to raise events and redraw the control
        /// when the value changes.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new int Value
        {
            get => base.Value;
            set
            {
                // clamp to the min/max values
                if (value < this.Minimum) value = this.Minimum;
                if (value > this.Maximum) value = this.Maximum;

                if (base.Value != value)
                {
                    base.Value = value;
                    OnValueChanged(EventArgs.Empty);
                    Invalidate();
                    UpdatePhase();
                }
            }
        }

        /// <summary>
        /// Raises the value changed event whenever the property changes.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnValueChanged(EventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the state changed event whenever the progress bar crosses
        /// a threshold defined by the CompletionPhase enum.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnStateChanged(EventArgs e)
        {
            StateChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Checks if a threshold has been passed and fires the event if it has.
        /// </summary>
        private void UpdatePhase()
        {
            CompletionPhase oldPhase = _currentPhase;
            CompletionPhase newPhase = PhaseCalculator(base.Value);

            if (newPhase != oldPhase)
            {
                _currentPhase = newPhase;
                OnStateChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Determines thresholds for different completion phases.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private CompletionPhase PhaseCalculator(int value)
        {
            if (value <= 0)
                return CompletionPhase.NotStarted;
            else if (value < 40)
                return CompletionPhase.Beginning;
            else if (value < 70)
                return CompletionPhase.Halfway;
            else if (value < 100)
                return CompletionPhase.NearingCompletion;
            else
                return CompletionPhase.Complete;
        }

        /// <summary>
        /// Overrides the OnPaint default logic. Skips the base.OnPaint(e) to avoid the 
        /// default behavior windows provides. Sets the color of the progress bar at
        /// different threshold levels with a switch.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(SystemColors.Control);

            float progress = base.Value / 100f;
            if (progress < 0f) progress = 0f;
            if (progress > 1f) progress = 1f;

            int fillWidth = (int)(this.ClientSize.Width * progress);

            Color fillColor;
            switch (_currentPhase)
            {
                case CompletionPhase.NotStarted:
                    fillColor = Color.LightGray;
                    break;
                case CompletionPhase.Beginning:
                    fillColor = Color.LightBlue;
                    break;
                case CompletionPhase.Halfway:
                    fillColor = Color.Yellow;
                    break;
                case CompletionPhase.NearingCompletion:
                    fillColor = Color.Orange;
                    break;
                case CompletionPhase.Complete:
                    fillColor = Color.Green;
                    break;
                default:
                    fillColor = Color.DarkGray;
                    break;
            }

            using (Brush b = new SolidBrush(fillColor))
            {
                Rectangle fillRect = new Rectangle(0, 0, fillWidth, this.ClientSize.Height);
                e.Graphics.FillRectangle(b, fillRect);
            }

            if (_showText)
            {
                string text = $"{base.Value}/100";
                using (Font f = new Font(Font.FontFamily, 10, FontStyle.Bold))
                {
                    SizeF textSize = e.Graphics.MeasureString(text, f);
                    float textX = (Width - textSize.Width) / 2;
                    float textY = (Height - textSize.Height) / 2;
                    e.Graphics.DrawString(text, f, Brushes.Black, textX, textY);
                }
            }
        }
    }
}

