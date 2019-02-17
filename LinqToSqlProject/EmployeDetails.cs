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
    public partial class EmployeDetails : Form
    {

        CompanyBDDataContext dc;
        List<Employee> Emp = new List<Employee>();
        int rno = 0;
        public EmployeDetails()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dc = new CompanyBDDataContext();
            Emp = dc.Employees.ToList();
            ShowData();
        }

        public void ShowData()
        {
            textBox1.Text=  Emp[rno].Eno.ToString();
            textBox2.Text = Emp[rno].Ename;
            textBox3.Text = Emp[rno].Job;
            textBox4.Text = Emp[rno].Salary.ToString();
            textBox5.Text = Emp[rno].Dname;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rno > 0)
            {
                rno -= 1;
                ShowData();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (rno < Emp.Count-1)
            {
                rno += 1;
                ShowData();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
