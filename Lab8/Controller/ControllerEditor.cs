using System;
using System.Drawing;
using System.Globalization;
using static System.Math;

namespace Lab8
{
    public class ControllerEditor
    {

        public Model model;

        public Font font;

        // Конструктор
        //----------------------------------------------------------------------------
        public ControllerEditor(Model model)
        {
            this.model = model;
        }

        // запись в tBox
        public void Paint(System.Windows.Forms.TextBox tBox)
        {
            // Знаков точности
            int rdig = 4;
            tBox.Text = "Матрица коэффициентов: \t\t\tCтолбец свободных членов:" + Environment.NewLine;
            string s = "";
            for (int row = 0; row < model.rows; row++)
            {
                s = "";
                for (int col = 0; col < model.cols; col++)
                    s += "\t" + Round(model.matrix[row, col], rdig);
                s += "\t\t" + Round(model.extension[row], rdig);
                tBox.Text += s + Environment.NewLine;
            }

            if (model.nice) {
                tBox.Text += "Результат:" + Environment.NewLine;
                s = "";
                for (int row = 0; row < model.result.Length; row++)
                {
                    s += "\t" + Round(model.result[row], rdig);
                }
                tBox.Text += s + Environment.NewLine;

                if (model.count > 0)
                    tBox.Text += "Итераций:\t" + model.count + Environment.NewLine;
            }
            else
            {
                tBox.Text += "Ошибка: " + model.nicelog + Environment.NewLine;
            }

        }
    }
}
