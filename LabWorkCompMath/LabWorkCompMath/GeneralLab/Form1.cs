using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabWorkCompMath
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) {
            FormLab newForm = new FormLab();
            newForm.Show();
        }

        private void button2_Click(object sender, EventArgs e) {
            FormLab2 newForm = new FormLab2();
            newForm.Show();
        }

        private void button3_Click(object sender, EventArgs e){
            FormLab3 newForm = new FormLab3();
            newForm.Show();
        }

        private void button4_Click(object sender, EventArgs e) {
            FormLab4 newForm = new FormLab4();
            newForm.Show();
        }

        private void button5_Click(object sender, EventArgs e) {
            FormLab5 newForm = new FormLab5();
            newForm.Show();
        }

        private void button6_Click(object sender, EventArgs e) {
            FormLab6 newForm = new FormLab6();
            newForm.Show();
            //MessageBox.Show("Вариант еще в разработке!", "Удручающее сообщение");
        }
    }
}
