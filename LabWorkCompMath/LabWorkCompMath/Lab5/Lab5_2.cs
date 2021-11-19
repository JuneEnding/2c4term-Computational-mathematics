using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabWorkCompMath.GeneralLab;
using LabWorkCompMath.Lab1;
using LabWorkCompMath;
using System.Windows.Forms;

namespace LabWorkCompMath.Lab2{
    class Lab5_2 : Lab
    {

        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // Эти поля необходимы для быстрой отладки
        // Заполнив их 1 раз, можно сэкономить время на вводе данных
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public Lab5_2() : this(null) { }

        public Lab5_2(Button relatedButton) : base(relatedButton)
        {
            inputData1 = new List<float[]>();
            typeInput = 1;
            labelName = "2. Найти максимальное собственное значение матрицы 3×3";
            labelDataName1 = "матрица:";
            labelDataName2 = "начальный вектор";
            labelDataName3 = "степень приближения";
            // Число данных
            numData = 3;
            // Число тестов
            numTests = 4;
            // Эти данные будут вводиться во входную строку, имитируя ручной ввод
            // Номер теста_номер входной строки
            test1_1 = "2;1;-4 -3;4;0 -3;-1;8";
            test2_1 = "1;-3;-2 -1;4;4 -2;3;6";
            test3_1 = "-1;7;2 9;8;1 5;2;7";
            test4_1 = "-10;1;-1 -4;-8;-1 -2;-5;-9";
            
            //test1_1 = "2;0 1;0";
            //test2_1 = "0;1 1;0";
            //test3_1 = "0;-1;2 1;0;3 4;-3;-2";
            //test4_1 = "7;7;3 -2;-4;1 2;7;-7";

            test1_2 = "1 1 1";
            test2_2 = "1 1 1";
            test3_2 = "1 1 1";
            test4_2 = "1 1 1";

            test1_3 = "4";
            test2_3 = "4";
            test3_3 = "4";
            test4_3 = "4";


            ch = new bool();
        }

            

        public List<float[]> MultMatr(List<float[]> a, List<float[]> b) {
            List<float[]> tem = new List<float[]>(a.Count);
            float[] line = new float[a[0].Length];
            for (int i = 0; i < a.Count; i++) {
                tem.Add(new float[a[0].Length]);
                for (int j = 0; j < b[0].Length; j++)
                    for (int k = 0; k < b.Count; k++)
                        tem[i][j] += a[i][k] * b[k][j];
            }
            return tem;
        }

        float ei;
        //List<float[]> tem;
        List<float[]> an;
        List<float[]> appr1;
        List<float[]> appr2;
        List<float[]> appr3;
        public float MaxEig(List<float[]> a, List<float[]> b, int deg = 5)
        {
            ei = 0;
            an = new List<float[]>();
            an = a;
            for (int i = 0; i < deg; i++)
                an = MultMatr(an, an); // Экономия времени вычисления!

            appr1 = MultMatr(an, b);
            an = MultMatr(an, a);
            appr2 = MultMatr(an, b);// Первый собственный вектор

            // Из-за частного случая задачи, вичисление можно сделать более наглядным, чем в цикле
            // Для массивов разной длины здесь следует использовать цикл
            ei = (float)(appr2[0][0] / appr1[0][0] + appr2[1][0] / appr1[1][0] + appr2[2][0] / appr1[2][0]) / 3;

            return ei;
        }

        //float ei;
        ////List<float[]> tem;
        //List<float[]> an;
        //List<float[]> anl;
        //List<float[]> appr1;
        //List<float[]> appr2;
        //public float MaxEig(List<float[]> a, List<float[]> b, int deg = 2)
        //{
        //    ei = 0;
        //    an = new List<float[]>();
        //    an = a;
        //    for (int i = 0; i < deg; i++)
        //        an = MultMatr(an, an); // Экономия времени вычисления!
        //    anl = an;
        //    an = MultMatr(anl,a);
        //    while ((ArMean(anl)-ArMean(an) >1)|| (ArMean(anl) - ArMean(an) < -1)){
        //        anl = an;
        //        an = MultMatr(anl, a);
        //    }

        //    appr1 = MultMatr(anl, b);
        //    //an = MultMatr(an, a);
        //    appr2 = MultMatr(an, b);// Первый собственный вектор

        //    // Из-за частного случая задачи, вичисление можно сделать более наглядным, чем в цикле
        //    // Для массивов разной длины здесь следует использовать цикл
        //    ei = (appr2[0][0] / appr1[0][0] + appr2[1][0] / appr1[1][0] + appr2[2][0] / appr1[2][0]) / 3;

        //    return ei;
        //}

        float tem;
        public float ArMean(List<float[]> a)
        {
            tem = 0;
            for(int i = 0; i < a.Count;i++) 
                tem += a[i][0];
            return tem/a.Count;

        }

        new List<float[]> inputData1;
        LabArray out1_1;
        Polynomial poly1;
        LabArray arr1;
        LabArray arr2;
        LabArray arr3;
        bool ch;
        LabArray e;
        // Перевод результата в выходные данные
        public override string OutData1() {
            InputData();
            outData1 = $"Введена матрица:\n{arr1.strMatForm} ";
            outData1 += "Максимальное собственное значение матрицы:\nλ1 = " + MaxEig(arr1.arrForm, arr2.arrForm, (int)arr3.arrForm[0][0]);
            outData1 += "\n" + error + "\n";
            if (arr1.arrForm == null)
                outData1 += "\nОШИБКА: массив задан некорректно!";

            //outData1FormPosDeeg = array1.FindDegPos(outData1, array1.degreesPositions.Length);
            //outData1FormLenDeeg = array1.lengthOfDegrees;
            return outData1;
        }
        public void InputData() {
            inputData3 = InputData3(inSData3);
            poly1 = new Polynomial();
            arr1 = new LabArray(inSData1);
            arr2 = new LabArray(inSData2);
            arr3 = new LabArray(inSData3);
            ch = new bool();
        }

    }
}
