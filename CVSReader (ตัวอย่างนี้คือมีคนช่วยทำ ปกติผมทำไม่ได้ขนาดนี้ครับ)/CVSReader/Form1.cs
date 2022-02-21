using ExcelDataReader;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CVSReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DGV.Rows.Clear();
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "CSV(*.csv) | *.csv" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    //Excel Version xls อย่าลืมเปลี่ยน Filter นาาจ๊ะ
                    //DGV.Rows.Clear();
                    //if (ofd.FileName != "")
                    //{
                    //    try
                    //    {
                    //        FileStream stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read);
                    //        IExcelDataReader excelReader;

                    //        if (Path.GetExtension(ofd.FileName).ToUpper() == ".XLS")
                    //        {
                    //            excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                    //        }
                    //        else
                    //        {
                    //            excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    //        }
                    //        DataSet result = excelReader.AsDataSet(new ExcelDataSetConfiguration()
                    //        {
                    //            ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                    //            {
                    //                UseHeaderRow = true
                    //            }
                    //        });
                    //        DataSet ds = result;
                    //        stream.Close();
                    //        double GPA = 0.0;
                    //        if (ds.Tables[0].Rows.Count != 0)
                    //            for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                    //            {
                    //                DGV.Rows.Add(ds.Tables[0].Rows[x][0].ToString(), ds.Tables[0].Rows[x][1].ToString(), ds.Tables[0].Rows[x][2].ToString(), ds.Tables[0].Rows[x][3].ToString());
                    //            }
                    //        Cal();
                    //    }
                    //    catch
                    //    {
                    //    }
                    //}

                    //CSV Version csv
                    string[] readAllLine = File.ReadAllLines(ofd.FileName);
                    
                    for (int i = 0; i < readAllLine.Length; i++)
                    {
                        string studentRAW = readAllLine[i];
                        string[] studentSplied = studentRAW.Split(',');
                        DGV.Rows.Add(studentSplied[0], studentSplied[1], studentSplied[2], studentSplied[3]);
                    }
                    Cal();
                }
            }
        }
        void Cal()
        {
            double GPA = 0;
            double Max = 0;
            double Min = 0;
            Max = Convert.ToDouble(DGV.Rows[0].Cells[3].Value.ToString());
            Min = Convert.ToDouble(DGV.Rows[0].Cells[3].Value.ToString());
            for (int x = 0; x < DGV.Rows.Count; x++)
            {
                GPA += Convert.ToDouble(DGV.Rows[x].Cells[3].Value.ToString());
                if (Max < Convert.ToDouble(DGV.Rows[x].Cells[3].Value.ToString()))
                    Max = Convert.ToDouble(DGV.Rows[x].Cells[3].Value.ToString());

                if (Min > Convert.ToDouble(DGV.Rows[x].Cells[3].Value.ToString()))
                    Min = Convert.ToDouble(DGV.Rows[x].Cells[3].Value.ToString());
            }
            TBMax.Text = Max.ToString("N");
            TBMin.Text = Min.ToString("N");
            TBGpax.Text = (GPA / Convert.ToDouble(DGV.Rows.Count)).ToString("N");
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string data = this.dataGridView1.Rows[0].Cells[0].Value.ToString();

            string strData = null;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV (*.csv) | *.csv";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog.FileName != null)
                {
                    for (int x = 0; x < DGV.Rows.Count; x++)
                    {
                        for (int y = 0; y < DGV.Columns.Count; y++)
                        {
                            strData +=  DGV.Rows[x].Cells[y].Value.ToString() + ",";
                            if (y == DGV.Columns.Count - 1)
                                strData += "\r\n";
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
            if(TBID.Text != "" && TBName.Text != "" && CBMajor.SelectedIndex != -1 && TBGPA.Text != "")
            {
                DGV.Rows.Add(TBID.Text, TBName.Text, CBMajor.SelectedItem, Convert.ToDouble(TBGPA.Text).ToString("N"));
                Cal();
                TBID.Text = "";
                TBName.Text = "";
                CBMajor.SelectedIndex = -1;
                TBGPA.Text = "";
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
    }
}