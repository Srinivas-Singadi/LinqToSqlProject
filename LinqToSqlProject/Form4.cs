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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CompanyBDDataContext dc = new CompanyBDDataContext();
            if (textBox1.ReadOnly == false)
            {
                //foreach (Control control in this.Controls)
                //{
                //    if (control is TextBox)
                //    {
                //        TextBox tb = control as TextBox;

                //        if (tb == null)
                //        {
                //            MessageBox.Show("please Enter the details to insert");
                //        }
                //    }
                //}
                try
                {

                    Employee Emp = new Employee();
                    Emp.Eno = int.Parse(textBox1.Text);
                    Emp.Ename = textBox2.Text;
                    Emp.Job = textBox3.Text;
                    Emp.Salary = decimal.Parse(textBox4.Text); 
                    Emp.Dname = textBox5.Text;
                    dc.Employees.InsertOnSubmit(Emp);
                    dc.SubmitChanges();

                    MessageBox.Show("Record inserted sucessfully!");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("plese enter the correct details");
                }
            }
            else
            {
                Employee obj = dc.Employees.SingleOrDefault(E => E.Eno == int.Parse(textBox1.Text));
                obj.Ename = textBox2.Text;
                obj.Job = textBox3.Text;
                obj.Salary = decimal.Parse(textBox4.Text);
                obj.Dname = textBox5.Text;

                dc.SubmitChanges();
                MessageBox.Show("Data updated successfully");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl  in this.Controls)
            {
                if(ctrl is TextBox)
                {
                    TextBox tb = ctrl as TextBox;
                    tb.Clear();
                }
            }
        }
    }
}
