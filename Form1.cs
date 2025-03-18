namespace _3951_Lab6_Bryson_Polina
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
        }
    }
}
