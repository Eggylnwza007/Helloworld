namespace TemperatureCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxF_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            // นี้คือคอมเม้นท์   
            // textBoxC.Text = "H e l l o";
            // get in put form textbox      
            string input = textBoxC.Text;

            // convert to f
            // f = c x 9/5 + 32
            double c = System.Convert.ToDouble(input);
            double f = c * 9 / 5 + 32;
            // show input to textbox
            textBoxF.Text = f.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // นี้คือคอมเม้นท์   
            // textBoxC.Text = "H e l l o";
            // get in put form textbox      
            string input = textBoxF.Text;

            // convert to c
            // c = f x 5/9 - 32
            double f = System.Convert.ToDouble(input);
            double c = (f - 32)/1.8;
            // show input to textbox
            textBoxC.Text = c.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            textBoxC.Text = "";
            textBoxF.Text = "";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}