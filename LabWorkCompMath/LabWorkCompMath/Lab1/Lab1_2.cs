using System.Windows.Forms;
using LabWorkCompMath.GeneralLab;
using System.Collections.Generic;
using System.Linq;

namespace LabWorkCompMath {
    class Lab2_2 : Lab {

        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // Эти поля необходимы для быстрой отладки
        // Заполнив их 1 раз, можно сэкономить время на вводе данных
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        public Lab2_2() : this(null) { }

        public Lab2_2(Button relatedButton) : base(relatedButton) {
            labelName       = "2. Найти частное от деления полинома на (х-a)";
            labelDataName1  = "коэффициенты полинома:";
            labelDataName2  = "(х-a) - делитель полинома, число а:";
            // Число данных
            numData     = 2;
            // Число тестов
            numTests    = 3;
            // Эти данные будут вводиться во входную строку, имитируя ручной ввод
            // Номер теста_номер входной строки
            test1_1     = "3;1;-8;0;8;7;6";
            test2_1     = "8;-7;28;-5;-40;10;-3;-28;-17;-9";
            test3_1     = "1;-1;-6;4;8";
            test1_2     = "-2";
            test2_2     = "1";
            test3_2     = "2";
        }

        // ГЛАВНЫЙ АЛГОРИТМ
        public static float[] GornerDiv(float[] a, float a0) {
            int k = a.Length - 1;
            if (k<=0) return new float[0];
            float[] b = new float[k];

            b[0] = a[0];
            for (int i = 1; i < k; i++)
                b[i] = a[i] + b[i - 1] * a0;
            return b;
        }

        // Результат конкретно этого пункта
        float[] out1_1;
        string sign = "-";
        float[] OutinputData2 = new float[1]; // Переменная необходима для отсутствия затирания входных данных
        Polynomial poly1;
        Polynomial poly2;
        // Перевод результата в выходные данные
        public override string OutData1() {
            poly1 = new Polynomial(inputData1);
            sign = "-";
            OutinputData2[0] = inputData2[0];
            if (OutinputData2[0] < 0) { sign = "+"; OutinputData2[0] *= -1; };
            //algorithm(inputData1, inputData2, inputData3);
            out1_1 = GornerDiv(inputData1, inputData2[0]);
            poly2 = new Polynomial(out1_1);
            outData1 = $"Введен полином: \n" +
                       $"f(x)={poly1.strForm}" +
                       $"\nПолином, полученный делением на ( х{sign}{OutinputData2[0]} ) : \n" +
                       $"f(x)/( х{sign}{OutinputData2[0]} ) = \n{poly2.strForm}" ;
            outData1FormPosDeeg = poly1.FindDegPos(outData1, poly1.degreesPositions.Length + poly2.degreesPositions.Length);
            outData1FormLenDeeg = poly1.lengthOfDegrees.Concat(poly2.lengthOfDegrees).ToArray(); 
            return outData1;
        }
    }
}
