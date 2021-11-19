using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabWorkCompMath.GeneralLab;
using System.Windows.Forms;

namespace LabWorkCompMath.Lab4
{
    class Lab4_1 : Lab
    {

        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // Эти поля необходимы для быстрой отладки
        // Заполнив их 1 раз, можно сэкономить время на вводе данных
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public Lab4_1() : this(null) { }

        public Lab4_1(Button relatedButton) : base(relatedButton)
        {
            labelName = "1. Определить нижнюю и верхнюю границу кольца, внутри которого расположены все корни полинома";
            labelDataName1 = "коэффициенты полинома:";
            // Число данных
            numData = 1;
            // Число тестов
            numTests = 3;
            // Эти данные будут вводиться во входную строку, имитируя ручной ввод
            // Номер теста_номер входной строки
            test1_1 = "1;-4;-42;104;361;-420";
            test2_1 = "-1;-2;-2;-5;0;-3;-4;2;-5;0";
            test3_1 = "1;1,4;-13,85;1,842;6,264";
            test4_1 = "3";
        }

        //??? Нужно ли преобразовывать исходные данные ???
        // По правилам - нет, тогда нужно создать новый массив, иначе можно было обойтись без него
        // ГЛАВНЫЙ АЛГОРИТМ
        // ПРОИЗВОДНАЯ
        public static float[] Derivative(float[] a) {
            float[] b = new float[a.Length-1];
            for (int i = 0; i < a.Length - 1; i++) {
                b[i] = a[i] * (a.Length - i - 1);
            }
            return b;
        }

        //public float Max(float[] a)
        //{
        //    max = new float();
        //    max = a[0];
        //    for (int i = 0; i < a.Length; i++)
        //        if (a[i] > max)
        //            max = a[i];
        //    return max;
        //}

        public static float Poly_R(float[] a) {
        float max;
            max = new float();
            while((Lab1_1.Gorner(a, 0) <= 0.001) && (Lab1_1.Gorner(a, 0) >= -0.001))
                a = Lab2_2.GornerDiv(a, 0);
     
            max = Math.Abs(a[1]);
            for (int i = 1; i < a.Length; i++)
                if (Math.Abs(a[i]) > max)
                    max = Math.Abs(a[i]);

            return 1 + max / Math.Abs(a[0]);
        }

        public static float Poly_r(float[] a) {
            float max;
            max = new float();
            while ((Lab1_1.Gorner(a, 0) <= 0.001) && (Lab1_1.Gorner(a, 0) >= -0.001))
                a = Lab2_2.GornerDiv(a, 0);
            max = Math.Abs(a[0]);
            for (int i = 0; i < a.Length-1; i++)
                if (Math.Abs(a[i]) > max)
                    max = Math.Abs(a[i]);

            return 1/(1 + max / Math.Abs(a[a.Length -1]));
        }

        // Результат конкретно этого пункта
        float[] out1_1;
        Polynomial poly1;
        Polynomial poly2;

        // Перевод результата в выходные данные
        public override string OutData1() {
            poly1 = new Polynomial(inputData1);
            outData1 = $"Введен полином: \n" +
                       $"f(x) = {poly1.strForm}" +
                       $"\nВсе корни уравнения расположены в круговом кольце: \n" +
                       $"{Poly_r(poly1.floatForm)} < |x| < {Poly_R(poly1.floatForm)}";
            // if (poly2.floatForm.Length == 0) 
            outData1FormPosDeeg = poly1.FindDegPos(outData1, poly1.degreesPositions.Length);
            outData1FormLenDeeg = poly1.lengthOfDegrees.ToArray();
            outData1FormPosMult = poly1.FindMultPos(outData1, poly1.degreesPositions.Length);
            return outData1;
        }
    }
}
