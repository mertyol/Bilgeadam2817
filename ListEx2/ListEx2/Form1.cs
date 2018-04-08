using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListEx2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Student> students = new List<Student>();
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsEmpty())
                MessageBox.Show("Lütfen tüm kutuları doldurun.");
            else
            {

                Student ogn = new Student(tbName.Text, tbLastname.Text, tbClass.Text, int.Parse(tbAge.Text));
                students.Add(ogn);
            }
        }

        bool IsEmpty()
        {
            foreach (Control item in this.Controls)
            {
                if(item is TextBox)
                {
                    if (item.Text == "")
                        return true;
                }
            }
            return false;
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            string studentlist = "";
            foreach (var item in students)
            {
                studentlist += item + "\n"; 
            }
            lbStudents.Text = studentlist;
        }
    }
}
