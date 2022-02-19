using System.Text;

namespace Student_Mangement_Application_0._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
 
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV (*.csv) | *.csv";
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                string[] readAllLine = File.ReadAllLines(openFileDialog.FileName);

                for (int i = 0; i < readAllLine.Length; i++) {
                    string studentRAW = readAllLine[i];
                    string[] studentSplied = studentRAW.Split(',');
                    Student student = new Student(studentSplied[0], studentSplied[1], studentSplied[2]);
                    addDataToGridView1("001", "A", "CIS");

                    //addDatatoGridView(student);
                     //TODO: Add Student object to DataGridView
                }

                //TODO : calculate max, min,gpax
            }
            
        }
        private void addDataToGridView1 (string id, string name, string major ) {
            this.dataGridView1.Rows.Add(new string[] { "001", "A", "CIS" });
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string data = this.dataGridView1.Rows[0].Cells[0].Value.ToString();

            string strData = string.Empty;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV (*.csv) | *.csv";
            if(saveFileDialog.ShowDialog() == DialogResult.OK) {
                if(saveFileDialog.FileName != string.Empty) {

                    int row = this.dataGridView1.Rows.Count;
                    for (int i = 0; i < row; i++)
                    {
                        int column = this.dataGridView1.Columns.Count;
                        for (int j = 0; j < column; j++) {
                            if(this.dataGridView1.Rows[i].Cells[j].Value != null)
                            {
                                strData = this.dataGridView1.Rows[i].Cells[j].Value.ToString();
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
            string strData = string.Empty;

            SaveFileDialog button1_Click = new SaveFileDialog();
            button1_Click.Filter = "CSV (*.csv) | *.csv";
            if (button1_Click.ShowDialog() == DialogResult.OK)
            {
                if (button1_Click.FileName != string.Empty)
                {

                    int row = this.dataGridView1.Rows.Count;
                    for (int i = 0; i < row; i++)
                    {
                        int column = this.dataGridView1.Columns.Count;
                        for (int j = 0; j < column; j++)
                        {
                            if (this.dataGridView1.Rows[i].Cells[j].Value != null)
                            {
                                strData = this.dataGridView1.Rows[i].Cells[j].Value.ToString();
                                //todo: save from dataGridView1 to variable
                            }
                        }
                    }
                    //TODO add data ot data gridview
                    //TODO Calculate GPX, Max, Min
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
    }
}