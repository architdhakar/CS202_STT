using System;
using System.Drawing;
using System.Windows.Forms;

namespace EventPlayground
{
    public partial class Form1 : Form
    {
        public event EventHandler<ColorEventArgs> ColorChangedEvent;
        public event EventHandler TextChangedEvent;

        public Form1()
        {
            InitializeComponent();

            comboBox1.Items.Add("Red");
            comboBox1.Items.Add("Green");
            comboBox1.Items.Add("Blue");
            comboBox1.SelectedIndex = 0;

            // MULTIPLE SUBSCRIBERS
            ColorChangedEvent += UpdateLabelColor;
            ColorChangedEvent += ShowNotification;

            TextChangedEvent += UpdateLabelText;
        }

        // COLOR BUTTON CLICK EVENT 
        private void btnChangeColor_Click(object sender, EventArgs e)
        {
            string selected = comboBox1.SelectedItem.ToString();
            ColorChangedEvent?.Invoke(this, new ColorEventArgs(selected));
        }

        // TEXT BUTTON CLICK EVENT 
        private void btnChangeText_Click(object sender, EventArgs e)
        {
            TextChangedEvent?.Invoke(this, EventArgs.Empty);
        }

        // SUBSCRIBERS 

        private void UpdateLabelColor(object sender, ColorEventArgs e)
        {
            if (e.SelectedColor == "Red") label1.ForeColor = Color.Red;
            else if (e.SelectedColor == "Green") label1.ForeColor = Color.Green;
            else if (e.SelectedColor == "Blue") label1.ForeColor = Color.Blue;
        }

        private void ShowNotification(object sender, ColorEventArgs e)
        {
            MessageBox.Show($"Color changed to: {e.SelectedColor}");
        }

        private void UpdateLabelText(object sender, EventArgs e)
        {
            label1.Text = $"Updated at: {DateTime.Now}";
        }
    }
}
