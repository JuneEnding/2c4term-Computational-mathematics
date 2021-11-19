using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabWorkCompMath.GeneralLab;
using System.Windows.Forms;

namespace LabWorkCompMath.Lab2
{

    class Lab6_1 : Lab { 
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // Эти поля необходимы для быстрой отладки
        // Заполнив их 1 раз, можно сэкономить время на вводе данных
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public Lab6_1() : this(null) { }

        public Lab6_1(Button relatedButton) : base(relatedButton)
        {
            inputData1 = new List<float[]>();
            typeInput = 1;
            labelName = "1. Нахождение приближённой сеточной производной по заданной сеточной функции";
            labelDataName1 = "функция:";
            labelDataName2 = "интервал:";
            labelDataName3 = "шаг:";

            // Число данных
            numData = 3;
            // Число тестов
            numTests = 5;
            // Эти данные будут вводиться во входную строку, имитируя ручной ввод
            // Номер теста_номер входной строки
            test1_1 = "-0,008;-0,066;-0,209;-0,439;-0,734;-1,044;-1,31;-1,484;-1,542;-1,491;-1,366;-1,218;-1,093;-1,02;-0,998;-1;-0,982;-0,901;-0,733;-0,479;-0,174;0,128;0,372;0,513;0,537;0,46;0,323;0,177;0,065;0,009;-0,002";
            test2_1 = "4;-4;0 3;1;3 1;2;-3";
            test3_1 = "3;4;-1;-1 -1;-3;1;-1 -2;-4;4;2 -1;0;-5;0";
            test4_1 = "-6,5;7,8;8,1 1,6;2,4;-9,1 -8,1;3,1;-1";

            test1_2 = "-3;3";
            test2_2 = "0;2";
            test3_2 = "1;0;0 0;1;0 0;0;1";
            test4_2 = "2;-8;-4 -4;2;1 -5;-6;-1";
            test5_2 = "2;-8;-4 -4;2;1 -5;-6;-1";

            test1_3 = "0,2";
            test2_3 = "0,1";
            test3_3 = "0,2";
            test4_3 = "0,3";
            test5_3 = "0,3";
            //--------------
            point = new float();
            
        }

        public List<float[]> MultMatr(List<float[]> a, List<float[]> b)
        {
            List<float[]> tem = new List<float[]>(a.Count);
            float[] line = new float[a[0].Length];
            for (int i = 0; i < a.Count; i++)
            {
                tem.Add(new float[a[0].Length]);
                for (int j = 0; j < a[0].Length; j++)
                    for (int k = 0; k < a[0].Length; k++)
                        tem[i][j] += a[i][k] * b[k][j];
            }
            return tem;
        }

        char[] charStr;

        List<float[]> XY1;
        float point;
        public List<float[]> XYfromDat(float[] a, float[] bord, float step)
        {
            XY1 = new List<float[]>();
            point = bord[0];
            XY1.Add(a); 
            XY1.Add(new float[a.Length]); 
            for(int i = 0; i < a.Length; i++)
            {
                XY1[1][i] = point;
                point += step;
            }
            return XY1;
        }

        List<float[]> finDif;
        public List<float[]> FinDifferences(float[] a, int he = 1) {
            finDif = new List<float[]>(he+1);
            finDif.Add(a);
            for (int i = 0; i < he; i++) {
                finDif.Add(new float[finDif[i].Length-1]);
                for(int k = 0; k< finDif[i+1].Length; k++)
                    finDif[i + 1][k] = finDif[i][k + 1] - finDif[i][k];
                
            } 
            return finDif;
        }

        float[] a1;
        float[] dy;
        public float[] GridDerivative(float[] a, float h)
        {
            a1 = new float[a.Length - 1];
            dy = FinDifferences(a)[1];
            for (int i = 0; i < a1.Length; i++)
            {
                a1[i] = dy[i] / h; // стр. 565
            }
            return a1;
        }

        new List<float[]> inputData1;
        LabArray out1_1;
        Polynomial poly1;
        LabArray arr1;
        LabArray arr2;
        LabArray arr3;
        LabArray arrXY1;
        List<float[]> masTem;
        float[] dArr1;
        // Перевод результата в выходные данные
        public override string OutData1() {
            InputData();
            outData1 = $"Введены точки функции:\n{arr1.strMatForm2} \n";
            //arrXY1 = XYfromDat(arr1.arrForm[0], arr2.arrForm[0], (arr3.arrForm[0]));// что за хрень

            //********************************
            masTem = FinDifferences(arr1.arrForm[0]);
            dArr1 = GridDerivative(arr1.arrForm[0], inputData3[0]); 

            //outData1 += "\n" + error + "\n";
            if (arr1.arrForm == null) 
                outData1 += "\nОШИБКА: массив задан некорректно!";
            outData1FormPosDeeg = poly1.FindDegPos(outData1, poly1.degreesPositions.Length);
            outData1FormLenDeeg = poly1.lengthOfDegrees;

            FormLab6 newForm = new FormLab6();
            newForm.Show();
            return outData1;
        }
        public void InputData()
        {
            inputData3 = InputData3(inSData3);
            poly1 = new Polynomial();
            arr1 = new LabArray(inSData1);
            arr2 = new LabArray(inSData2);
            arr3 = new LabArray(inSData3);
        }

    }
}
