using System;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;

namespace GrafObj
{
    delegate void DelegateView(Graphics g);

    public partial class Form1 : Form
    {
        private Model model = new Model();
        private DelegateView _view = null;
        private ControllerEditor graf;
        private Point clikpoint;
        private Boolean mousedown = false;
        private TypeAction typeaction = TypeAction.None;
        private enum TypeAction
        {
            None,
            ObjectMove,
            RelationMove
        }

        public Form1()
        {
            InitializeComponent();

            //Editor();
            //model = LoadModel( System.IO.Path.GetFullPath(@"..\..\") + "default.fml"); // Дефолтная загрузка по умолчанию
            pictureObj.Invalidate();
        }

        public void Editor() { _view = tEditor; }

        private void tEditor(Graphics g)
        {
            graf = new ControllerEditor(model);
            graf.clikpoint = clikpoint;
            graf.scale = Convert.ToInt32(ScaleNnum.Value);
            graf.model.formula = tFormula.Text;
            graf.model.tintervalx = tintervalx.Text;
            graf.model.tstep = tstep.Text;
            graf.model.CalcModel();
            graf.Paint(g);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Editor();
            pictureObj.Invalidate();
        }

        private void pictureObj_Paint(object sender, PaintEventArgs e)
        {
            _view?.Invoke(e.Graphics);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            pictureObj.Invalidate();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.Xml.Serialization.XmlSerializer writerRw = new System.Xml.Serialization.XmlSerializer(typeof(Model));
                System.IO.StreamWriter fileRw = new System.IO.StreamWriter(saveFileDialog1.FileName);
                writerRw.Serialize(fileRw, model);
                fileRw.Close();
            }
        }

        private Model LoadModel(string FileName)
        {
            Model res = null;
            System.Xml.Serialization.XmlSerializer readerRr = new System.Xml.Serialization.XmlSerializer(typeof(Model)); //Получ. по модели формата загружаемого файла
            System.IO.StreamReader fileRr = new System.IO.StreamReader(FileName); // По этому формату грузим из файлнэйм
            res = (Model)readerRr.Deserialize(fileRr);// Десериализуем результат 
            fileRr.Close();
            return res;// И возвращаем его 
        }
        
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                model = LoadModel(openFileDialog1.FileName);
                pictureObj.Invalidate();
            }
        }

        public Color ColorFromName(string color)
        {
            if (color == null)
                return Color.Black;
            Color col = Color.FromName(color);
            if (col.ToArgb() == 0)
                col = Color.FromArgb(int.Parse(color, NumberStyles.HexNumber));
            return col;
        }

        private void pictureObj_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                //model.DeselectObject();//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                clikpoint = e.Location;
                pictureObj.Invalidate();
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (typeaction != TypeAction.RelationMove)
                {
                    //contextMenuStrip1.Show((Control)sender, e.Location);
                }
            }
        }

        private void pictureObj_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //newrelation = true;
            //if (typeaction == TypeAction.None)
            //if (model.ObjectSelected())
            {
                // Запуск редактирования объекта
                //EditObject(model.GetSelectedObject());
                pictureObj.Invalidate();
            }
        }

        private void pictureObj_MouseDown(object sender, MouseEventArgs e){
            if (e.Button == MouseButtons.Left)
            {
                mousedown = true;
                //if ( model.ObjectSelected() )
                //if ( model.PointInObject(e.Location, 40, 40) == model.GetSelectedObject() )
                {
                    typeaction = TypeAction.ObjectMove;
                    // передвигаем курсор в угол выбранного объекта
                    //Cursor.Position = new Point(
                        //Cursor.Position.X + model.GetSelectedObject().location.X - e.Location.X,
                        //Cursor.Position.Y + model.GetSelectedObject().location.Y - e.Location.Y
                    //);
                }
                //else { if (model.PointInObject(e.Location, 40, 40) == null)
                    typeaction = TypeAction.RelationMove;
                //}
            }
            Debug();
        }

        private void pictureObj_MouseUp(object sender, MouseEventArgs e){
            mousedown = false;
            typeaction = TypeAction.None;
            //if (model.ObjectSelected())
            {
                //model.GetSelectedObject().location = e.Location;
                pictureObj.Invalidate();
            }
            Debug();
        }

        private void pictureObj_MouseMove(object sender, MouseEventArgs e){
            //if (model.ObjectSelected())
            {
                if (typeaction == TypeAction.ObjectMove)
                {
                    clikpoint = e.Location;
                    //model.GetSelectedObject().location = e.Location;
                    pictureObj.Invalidate();
                }
                if (typeaction == TypeAction.RelationMove)
                {
                    //Model.DataElem elfrom = model.GetSelectedObject();
                    //Model.DataElem elto = model.PointInObject(e.Location, 40, 40);
                    //if (elto != null)
                        //model.NewRelation(elfrom, elto);

                        //clikpoint = e.Location;
                        //model.GetSelectedObject()
                        pictureObj.Invalidate();
                }
            }
            Debug();
        }

        public void Debug(){
            lInfo.Text = "mousedown: " + mousedown
                        + "\ntypeaction: " + typeaction
                        //+ "\nObjectSelected: " + model.ObjectSelected() + " " + model.GetSelectedObject()?.name
                        + "\nXY: " + clikpoint.ToString()
                        //+ "\ntimer: " + model.timer.ToString();
            ;
        }

        private void pictureObj_Resize(object sender, EventArgs e)
        {
            pictureObj.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            tFormula.Text = "-0.008, -0.066, -0.209, -0.439, -0.734, -1.044, -1.31, -1.484, -1.542, -1.491, -1.366, -1.218, -1.093, -1.02, -0.998, -1, -0.982, -0.901, -0.733, -0.479, -0.174, 0.128, 0.372, 0.513, 0.537, 0.46, 0.323, 0.177, 0.065, 0.009, -0.002";
            tintervalx.Text = "-3, 3";
            tstep.Text = "0.2";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tFormula.Text = "-5, -4.597, -4.178, -3.727, -3.234, -2.688, -2.082, -1.411, -0.674, 0.131, 1, 1.929, 2.91, 3.935, 4.99, 6.063, 7.134, 8.187, 9.198, 10.145, 11";
            tintervalx.Text = "0, 2";
            tstep.Text = "0.1";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tFormula.Text = "0, 1.483, 2.739, 3.782, 4.647, 5.437, 6.363, 7.723, 9.749, 12.314, 14.659, 15.538, 14.109, 11.222, 9.578, 11.331, 14.75, 15.096, 11.393, 9.66, 13.403";
            tintervalx.Text = "0, 4";
            tstep.Text = "0.2";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tFormula.Text = "-4.045, 1.782, 2.279, 2.398, 2.322, 2.109, 1.784, 1.355, 0.83, 0.281, 0, 0.281, 0.83, 1.355, 1.784, 2.109, 2.322, 2.398, 2.279, 1.782, -4.045";
            tintervalx.Text = "-3, 3";
            tstep.Text = "0.3";
        }


        private void button6_Click(object sender, EventArgs e)
        {
            tFormula.Text = "9, 4, 1, 0, 1, 4, 9";
            tintervalx.Text = "-3, 3";
            tstep.Text = "1";
        }
    }
}
