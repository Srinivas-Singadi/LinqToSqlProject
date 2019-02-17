using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqToSqlProject
{
    public partial class Form3 : Form
    {
        CompanyBDDataContext dc; 
        public Form3()
        {
            InitializeComponent();
        }
        private void Load_Data()
        {
            dc = new CompanyBDDataContext();
            dataGridView1.DataSource = dc.Employees;
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            Load_Data();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.ShowDialog();
            Load_Data();

            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //CompanyBDDataContext dc = new CompanyBDDataContext();
            Form4 f = new Form4();
            f.button2.Enabled = false;
            f.button1.Text = "Update";
            f.textBox1.ReadOnly = true;
            if (dataGridView1.SelectedRows.Count> 0)
            {
                f.textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                f.textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                f.textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                f.textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                f.textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                f.ShowDialog();
                Load_Data();
            }
        }
    }
}
