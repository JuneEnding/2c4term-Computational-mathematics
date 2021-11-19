using System.Drawing;
using System.Globalization;
using static System.Math;

namespace GrafObj
{
    public class ControllerEditor
    {

        public Model model;

        public Point clikpoint { get; set; }    // нажатая кнопка
        public int scale { get; set; }  = 4;    // масштабирование (теоретически можно скалировать объект формы)
        //public string formula { get; set; }
        public Font font;

        // Конструктор
        //----------------------------------------------------------------------------
        public ControllerEditor(Model model)
        {
            this.model = model;
        }

        // отрисовка в gr
        public void Paint(Graphics gr)
        {
            //model.formula = formula;
            //model.CalcModel();

            font = new Font("Times New Roman", 4 * scale, FontStyle.Regular);
            float WH = gr.ClipBounds.Height;
            float WW = gr.ClipBounds.Width - 0;
            int bold = scale / 4 + 1;
            //Pen pen3 = new Pen(Color.Black, 3 * bold);
            Pen penXY1 = new Pen(Color.LightGray, 1);
            Pen penXY3 = new Pen(Color.LightGray, 3);
            float xs = model.xScale(WW);

            // текущие координаты x и f(x)
            float curX1 = 0;
            float curY1 = 0;
            float pcurX1 = 0;
            float pcurY1 = 0;

            //верт грид
            for (int count = 0; count < model.Count; count++)
            {
                curX1 = model.shift / 2 + xs * count;
                curY1 = model.shift / 4;
                gr.DrawLine(penXY1, curX1, curY1, curX1, WH - curY1);
                // текст оси х
                gr.DrawString((Round(model.Intevalx[0] + model.Step * count,2)).ToString(), font, new SolidBrush(Color.DarkGray), curX1 + 5, WH - curY1 - 4 * scale);
            }

            //горизонт грид
            for (float count = (float)Truncate(model.Intevaly[0] * 10) / 10; count <= model.Intevaly[1]; count = count + 0.5f)
            {
                curX1 = model.shift / 4;
                curY1 = model.Fx(count, WH);
                gr.DrawLine(penXY1, curX1, curY1, WW - curX1, curY1);
                // текст оси y
                gr.DrawString(Round((count),2).ToString(), font, new SolidBrush(Color.DarkGray), curX1 - 15, curY1 - 6 * scale);
            }

            // f(x)
            float[] f = model.fmatrix;
            Color curC = Color.Black;
            Pen pen1 = new Pen(curC, bold);
            for (int count = 0; count < model.Count; count++)
            {
                SolidBrush elBrush = new SolidBrush(curC);
                pcurX1 = curX1;
                pcurY1 = curY1;

                curX1 = model.shift / 2 + xs * count;
                curY1 = model.Fx(f, count, WH);

                // точка
                gr.FillEllipse(elBrush, curX1 - bold * 5 / 2, curY1 - bold * 5 / 2, bold * 5, bold * 5);

                // текст значения f(x)
                gr.DrawString(f[count].ToString(), font, new SolidBrush(curC), curX1 + 5, curY1 - 6 * scale);

                if (count > 0)
                    gr.DrawLine(pen1, curX1, curY1, pcurX1, pcurY1);

            }

            // f'(x)
            f = model.DERfmatrix;
            curC = Color.Red;
            pen1 = new Pen(curC, bold);
            for (int count = 0; count < model.Count - 1; count++)
            {
                SolidBrush elBrush = new SolidBrush(curC);
                pcurX1 = curX1;
                pcurY1 = curY1;

                curX1 = model.shift / 2 + xs * (count + 0.5f);
                curY1 = model.Fx(f, count, WH);

                // точка
                gr.FillEllipse(elBrush, curX1 - bold * 5 / 2, curY1 - bold * 5 / 2, bold * 5, bold * 5);

                // текст значения f'(x)
                gr.DrawString(f[count].ToString(), font, new SolidBrush(curC), curX1 + 5, curY1 - 6 * scale);

                if (count > 0)
                    gr.DrawLine(pen1, curX1, curY1, pcurX1, pcurY1);

            }

            //инфо
            curX1 = model.shift / 2 + 80;
            curY1 = model.shift / 4 + 20;
            gr.FillRectangle(new SolidBrush(Color.White), curX1, curY1, 220, 100);

            curY1 = curY1 + 20;
            curC = Color.Black;
            gr.DrawLine(new Pen(curC, bold), curX1 + 10, curY1, curX1 + 50, curY1);
            gr.DrawString("y(x)", font, new SolidBrush(curC), curX1 + 60, curY1 - 4 * scale);

            curY1 = curY1 + 20;
            curC = Color.Red;
            gr.DrawLine(new Pen(curC, bold), curX1 + 10, curY1, curX1 + 50, curY1);
            gr.DrawString("y'(x)", font, new SolidBrush(curC), curX1 + 60, curY1 - 4 * scale);

            curY1 = curY1 + 20;
            curC = Color.Black;
            gr.DrawString("Погрешность R0 = " + model.Inaccuracy(model.fmatrix, model.Step), font, new SolidBrush(curC), curX1, curY1 - 10);


        }

        private Color ColorFromName(string color)
        {
            Color col = Color.FromName(color);
            if (col.ToArgb() == 0)
                col = Color.FromArgb(int.Parse(color, NumberStyles.HexNumber));
            return col;
        }
    }
}
