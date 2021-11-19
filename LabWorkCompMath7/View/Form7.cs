using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tFormula.Text = "(x - 1) * y / x ^ 2";
            ty_x.Text = "y(1) = e";
            tintervalx.Text = "1, 2";
            tstep.Text = "0.1";
        }
    }
}
