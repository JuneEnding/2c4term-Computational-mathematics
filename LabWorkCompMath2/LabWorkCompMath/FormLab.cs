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
    public partial class FormLab : Form
    {
        Lab lab = null;
        //Lab1_1 lab2_1 = new Lab2_1();
        //Lab1_2 lab2_2 = new Lab2_2();
        //Lab1_3 lab2_3 = new Lab2_3();
        //Lab1_4 lab2_4 = new Lab2_4();
        //Lab1_5 lab2_5 = new Lab2_5();

        void UpdateLab() {
            this.labelName.Text = lab.labelName;
            if (lab.numData > 1) {this.textData2.Visible = true; } else { this.textData2.Visible = false; }
            if (lab.numData > 2) {this.textData3.Visible = true; } else { this.textData3.Visible = false; }
            this.labelDataName1.Text = lab.labelDataName1;
            if (lab.numData > 1) {
                this.labelDataName2.Visible = true;
                this.labelDataName2.Text = lab.labelDataName2;
            } else { this.labelDataName2.Visible = false; }
            if (lab.numData > 2) {
                this.labelDataName3.Visible = true;
                this.labelDataName3.Text = lab.labelDataName3;
            } else { this.labelDataName3.Visible = false; }
            if (lab.numTests > 1) {this.buttonTest2.Visible = true; } else { this.buttonTest2.Visible = false; }
            if (lab.numTests > 2) {this.buttonTest3.Visible = true; } else { this.buttonTest3.Visible = false; }
            if (lab.numTests > 3) {this.buttonTest4.Visible = true; } else { this.buttonTest4.Visible = false; }
            if (lab.numTests > 4) {this.buttonTest5.Visible = true; } else { this.buttonTest5.Visible = false; }
        }
        public FormLab()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e){
        }

        private void button2_Click(object sender, EventArgs e) {
            //lab = lab2_2;
            UpdateLab();
        }

        private void button1_Click(object sender, EventArgs e) {
            //lab = lab2_1;
            UpdateLab();
        }

        private void button3_Click(object sender, EventArgs e){
           // lab = lab2_3;
            UpdateLab();
        }

        private void button5_Click(object sender, EventArgs e) {
            //lab = lab2_4;
            UpdateLab();
        }

        float[] arr;
        private void textData_KeyDown(object sender, KeyEventArgs e){
            if (e.KeyCode != Keys.Enter) return;
            buttonCount_Click(sender, e); 
        }

        private void textData2_KeyDown(object sender, KeyEventArgs e){
            if (e.KeyCode != Keys.Enter) return;
            buttonCount_Click(sender, e);
        }

        private void buttonTest1_Click(object sender, EventArgs e){
            textData.Text = lab.test1_1; 
            textData2.Text = lab.test1_2; 
            textData3.Text = lab.test1_3; 
        }

        private void buttonTest2_Click(object sender, EventArgs e){
            textData.Text = lab.test2_1;
            textData2.Text = lab.test2_2;
            textData3.Text = lab.test2_3;
        }

        private void buttonTest3_Click(object sender, EventArgs e) {
            textData.Text = lab.test3_1;
            textData2.Text = lab.test3_2;
            textData3.Text = lab.test3_3;
        }

        private void buttonTest4_Click(object sender, EventArgs e){
            textData.Text = lab.test4_1;
            textData2.Text = lab.test4_2;
            textData3.Text = lab.test4_3;
        }

        private void buttonCount_Click(object sender, EventArgs e){
            lab.InputData1(textData.Text);
            if (lab.numData > 1) lab.InputData2(textData2.Text);
            if (lab.numData > 2) lab.InputData3(textData3.Text);
            lab.OutData1();
            richTextBoxOut.Text = lab.outData1;
        }

        private void button6_Click(object sender, EventArgs e) {
           // lab = lab2_5;
            UpdateLab();
        }

        private void textData3_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode != Keys.Enter) return;
            buttonCount_Click(sender, e);
        }
    }
}
