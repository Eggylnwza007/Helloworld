using System.Text;

namespace record
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV (*.csv) | *.csv";
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                string[] readAllLine = File.ReadAllLines(openFileDialog.FileName);

                for (int i = 0; i < readAllLine.Length; i++) {
                    string RAW = readAllLine[i];
                    string[] Splied = RAW.Split(',');
                    dataGridView1.Rows.Add(Splied[0], Splied[1], Splied[2]);

                    //addDatatoGridView(student);
                     //TODO: Add Student object to DataGridView
                }

                //TODO : calculate max, min,gpax
            }
            
        
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string data = this.dataGridView1.Rows[0].Cells[0].Value.ToString();

            string strData = null;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV (*.csv) | *.csv";
            if(saveFileDialog.ShowDialog() == DialogResult.OK) {
                if(saveFileDialog.FileName != null) {

                    for (int Rows = 0; Rows < dataGridView1.Rows.Count; Rows++)
                    {
                        for (int column = 0; column < dataGridView1.Columns.Count; column++) {
                            if(dataGridView1.Rows[Rows].Cells[column].Value != null)
                            {
                                strData += dataGridView1.Rows[Rows].Cells[column].Value.ToString() + ",";
                                if (column == dataGridView1.Columns.Count - 1)
                                    strData += "\r\n";
                                //todo: save from dataGridView1 to variable
                            }
                        }
                    }

                    //save File
                    File.WriteAllText(saveFileDialog.FileName, strData, Encoding.UTF8);


                }

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" && comboBox1.SelectedIndex != -1)
            {

                if (Double.TryParse(textBox3.Text, out double x))
                {
                        infomation info = new infomation(textBox2.Text, Convert.ToDouble(textBox3.Text), comboBox1.Items[comboBox1.SelectedIndex].ToString());
                    dataGridView1.Rows.Add(info.Namelist, info.Amount.ToString("N"),info.Type);
                    textBox2.Text = "";
                    textBox3.Text = "";
                    comboBox1.SelectedIndex = -1;
                
                }
                else
                {
                    MessageBox.Show("กรูณาระบุข้อมูลจำนวนเป็นตัวเลข", "นาจ๊ะ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}