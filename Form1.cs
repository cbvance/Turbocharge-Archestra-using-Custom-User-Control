using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testSQLGrid
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();

       

        private void Form1_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("Test1");
            dt.Columns.Add("Test2");
            DataRow dr = dt.NewRow();
            dr[0] = "test1";
            dr[1] = "test2";
            dt.Rows.Add(dr);

            sqlGrid1.DataSource = dt;
            dataGridView1.DataSource = dt;
        }

        private void sqlGrid1_BatchIDChangedEvent(object sender, SQLGridControl.SQLGridEventArgs e)
        {
            label1.Text = sqlGrid1.BatchID.ToString();
        }
    }
}
