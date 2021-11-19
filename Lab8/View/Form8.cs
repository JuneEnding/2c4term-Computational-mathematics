using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab8
{
    public partial class Form8 : Form
    {

        //delegate void DelegateView(Graphics g);
        delegate void DelegateView(TextBox tbox);
        private DelegateView _view = null;

        private Model model = new Model();
        private ControllerEditor graf;

        public Form8()
        {
            InitializeComponent();
        }

        public ControllerEditor fillsField() {
            graf = new ControllerEditor(model);
            graf.model.tMatrix = tMatrix.Text;
            graf.model.tExt = tExt.Text;
            return graf;
        }

        public void Gauss() { _view = tGauss; }
        private void tGauss(TextBox tbox)
        {
            graf = fillsField();
            graf.model.CalcModel(1);
            graf.Paint(tbox);
        }

        public void Progonka() { _view = tProgonka; }
        private void tProgonka(TextBox tbox)
        {
            graf = fillsField();
            graf.model.CalcModel(2);
            graf.Paint(tbox);
        }
        public void Iterations() { _view = tIterations; }
        private void tIterations(TextBox tbox)
        {
            graf = fillsField();
            graf.model.CalcModel(3);
            graf.Paint(tbox);
        }
        public void Zeydel() { _view = tZeydel; }
        private void tZeydel(TextBox tbox)
        {
            graf = fillsField();
            graf.model.CalcModel(4);
            graf.Paint(tbox);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Gauss();
            _view?.Invoke(ResultTextBox);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Progonka();
            _view?.Invoke(ResultTextBox);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Iterations();
            _view?.Invoke(ResultTextBox);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Zeydel();
            _view?.Invoke(ResultTextBox);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tMatrix.Text = "1, -5, -7, 1; 1, -3, -8, -4; -2, 4, 2, 1; -9, 9, 5, 3";
            tExt.Text = "-75, -41, 18, 29";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tMatrix.Text = "15, 8, 0, 0, 0; 2, -15, 4, 0, 0; 0, 4, 11, 5, 0; 0, 0, -3, 16, -7; 0, 0, 0, 3, 8";
            tExt.Text = "92, -84, -77, 15, -11";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tMatrix.Text = "29, 8, 9, -9; -7, -25, 0, 9; 1, 6, 16, -2; -7, 4, -2, 17";
            tExt.Text = "197, -226, -95, -58";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            tMatrix.Text = "0.05, -0.06, -0.12, 0.14; 0.04, -0.12, 0.68, 0.11; 0.34, 0.08, -0.06, 0.44; 0.11, 0.12, -0.03, -0.8";
            tExt.Text = "-2.17, 1.4, -2.1, -0.8";
        }
    }
}
