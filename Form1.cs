namespace _3951_Lab6_Bryson_Polina
{
    /// <summary>
    /// Lab 6 - Bryson Lindy & Polina Omelyantseva 
    /// </summary>
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer loadSimulator;
        private BrysonProgressBar bpb;
        private ImageCarousel imc;

        public Form1()
        {
            InitializeComponent();

            this.ClientSize = new Size(800, 450);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            UserControlRGBSelectorPolina rgbSelector = new UserControlRGBSelectorPolina
            {
                Location = new Point(20, 20)
            };
            Controls.Add(rgbSelector);

            ButtonPolina buttonPolina = new ButtonPolina
            {
                Location = new Point(20, 250),
                Size = new Size(150, 50),
                Text = "Colour updater",
            };
            Controls.Add(buttonPolina);

            buttonPolina.Click += (s, e) =>
            {
                buttonPolina.SelectedColor = rgbSelector.SelectedColor;
            };

            bpb = new BrysonProgressBar
            {
                Location = new Point(300, 20),
                Size     = new Size(200, 37),
                ShowText = true,
                Minimum  = 0,
                Maximum  = 100,
                Value    = 0
            };
            Controls.Add(bpb);

            bpb.ValueChanged += (s, e) =>
            {
                this.Text = $"Progress: {bpb.Value}";
            };

            Button buttonSimLoad = new Button
            {
                Location = new Point(400, 60),
                Size     = new Size(100, 30),
                Text     = "Load"
            };
            Controls.Add(buttonSimLoad);

            buttonSimLoad.Click += ButtonSimLoad_Click;

            loadSimulator = new();
            loadSimulator.Interval = 100;
            loadSimulator.Tick += LoadSimulator_Tick;

            imc = new ImageCarousel
            {
                Location = new Point(400, 100),
                Size     = new Size(400, 350)
            };
            Controls.Add(imc);

        }

        private void ButtonSimLoad_Click(object sender, EventArgs e)
        {
            bpb.Value = 0;
            loadSimulator.Start();
        }

        private void LoadSimulator_Tick(object sender, EventArgs e)
        {
            if (bpb.Value < 100)
            {
                bpb.Value += 1;
            }
            else
            {
                loadSimulator.Stop();
                MessageBox.Show("Simulated Load Complete!");
            }
        }

    }
}
