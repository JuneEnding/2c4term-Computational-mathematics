using System;
using LabWorkCompMath.GeneralLab;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace LabWorkCompMath.Lab2
{
    class Lab6_3 : Lab
    {

        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // Эти поля необходимы для быстрой отладки
        // Заполнив их 1 раз, можно сэкономить время на вводе данных
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public Lab6_3() : this(null) { }

        public Lab6_3(Button relatedButton) : base(relatedButton)
        {
            typeInput = 1;
            labelName = "3. Нахождение определителя матрицы через элементарные преобразования";
            labelDataName1 = "матрица:";
            labelDataName2 = "верхняя граница:";
            labelDataName3 = "степень приближения:";
            // Число данных
            numData = 1;
            // Число тестов
            numTests = 4;
            // Эти данные будут вводиться во входную строку, имитируя ручной ввод
            // Номер теста_номер входной строки

            test1_1 = "1;6;-4 -8;6;7 -7;0;8";
            test2_1 = "-4,6;-1,71;-3,06 2,66;-3,52;0,22 -0,79;-1,9;-4,04";
            test3_1 = "1;0;0 0;1;0 0;0;1";
            test4_1 = "1;2;3 4;5;6 7;8;9";

            test1_2 = "1;-3 4;-2";
            test2_2 = "0;1 1;0";
            test3_2 = "1;0;0 0;1;0 0;0;1";
            test4_2 = "2;-8;-4 -4;2;1 -5;-6;-1";

            test1_3 = "-1;1";
            test2_3 = "-1;1";
            test3_3 = "-1;1";
            test4_3 = "-1;1";
        }

        // ГЛАВНЫЙ АЛГОРИТМ
        List<float[]> dn;
        public float Det(List<float[]> a, float det = 1) {
            if ((a==null)||(a.Count <= 0)) return 0;
            if (a.Count != a[0].Length) {  error = "Матрица не квадратная!"; return 0; }
            if (a.Count == 1)
                return det*a[0][0];
            dn = new List<float[]>();
            if (a[0][0] == 0) {
                k = 1;
                while (a[0][k] == 0) {k++; if (a.Count-1 < k) return 0; }
                if (a[0].Length < k) return 0;
                //if ((k % 2) != 0) 
                det *= -1;
                ChLin(a, 0, k);
            }
            det *= a[0][0];
            for (int i = 0; i<a.Count-1;i++)
            {
                dn.Add(new float[a[0].Length-1]);
                for (int j = 0; j<dn[0].Length;j++)
                {
                    dn[i][j] = a[i+1][j+1] - a[i+1][0] * a[0][j+1] / a[0][0];
                }
            }
            return Det(dn, det);
        }

        List<float[]> b;
        int k;
        float tem;
        public List<float[]> ChLin(List<float[]> a, int l1, int l2)
        {
            b = new List<float[]>();
            if ((a == null) || (a.Count <= 1)) return a;
            b = a;
            for (int i = 0; i < a.Count; i++) {
                tem = a[i][l2];
                b[i][l2] = a[i][l1];
                b[i][l1] = tem;
            }
            return b;
        }

        public 

        new List<float[]> inputData1;
        LabArray out1_1;
        Polynomial poly1;
        LabArray arr1;


        // Перевод результата в выходные данные
        public override string OutData1()
        {
            InputData();
            outData1 = $"Введена матрица:\n{arr1.strMatForm} ";
            //out1_1 = NewtonI2(array1.arrForm, InputData2(inSData2));
            //out1_1 = new LabArray(RevMat(arrA.arrForm));
            //outData1 = outData1 + $"\nНайденное произведение:\n{out1_1.strMatForm}";

            outData1 += "\nОпределитель матрицы равен: " + Det(arr1.arrForm);
            outData1 += "\n" + error + "\n";
            if (arr1.arrForm == null)
                outData1 += "\nОШИБКА: массив задан некорректно!";
            //outData1FormPosDeeg = array1.FindDegPos(outData1, array1.degreesPositions.Length);
            //outData1FormLenDeeg = array1.lengthOfDegrees;
            return outData1;
        }
        public void InputData()
        {
            inputData3 = InputData3(inSData3);
            poly1 = new Polynomial();
            arr1 = new LabArray(inSData1);

        }
    }
}
