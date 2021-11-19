using System;
using LabWorkCompMath.GeneralLab;
using System.Windows.Forms; 
using System.Linq;
using System.Collections.Generic;

namespace LabWorkCompMath.Lab2 {
    class Lab4_3 : Lab {

        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // Эти поля необходимы для быстрой отладки
        // Заполнив их 1 раз, можно сэкономить время на вводе данных
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public Lab4_3() : this(null) { }

        public Lab4_3(Button relatedButton) : base(relatedButton)
        {
            labelName = "3. Определение верхней границы положительных действительных корней полинома по методу Ньютона";
            labelDataName1 = "коэффициенты полинома:";
            // Число данных
            numData = 1;
            // Число тестов
            numTests = 3;
            // Эти данные будут вводиться во входную строку, имитируя ручной ввод
            // Номер теста_номер входной строки
            test1_1 = "1;4;1;-14;-20;-8";
            test2_1 = "-1;-2;-2;-5;0;-3;-4;2;-5;0";
            test3_1 = "1;1,4;-13,85;1,842;6,264";
            test4_1 = "3";
        }

        //??? Нужно ли преобразовывать исходные данные ???
        // По правилам - нет, тогда нужно создать новый массив, иначе можно было обойтись без него
        // ГЛАВНЫЙ АЛГОРИТМ
        // ПРОИЗВОДНАЯ
        public static float[] Derivative(float[] a)
        {
            float[] b = new float[a.Length - 1];
            for (int i = 0; i < a.Length - 1; i++)
            {
                b[i] = a[i] * (a.Length - i - 1);
            }
            return b;
        }

        float maxAbsB;
        public float FindB(float[] a)
        {
            maxAbsB = new float();
            maxAbsB = a[0] * -1;
            for (int i = 0; i < a.Length; i++)
                if (a[i] < 0)
                    if (a[i] * -1 > maxAbsB)
                        maxAbsB = a[i] * -1;
            return maxAbsB;
        }

        List<float[]> finDif;
        public List<float[]> FinDif(float[] a)
        {
            finDif = new List<float[]>();
            finDif.Add(a);
            for (int i = 0; finDif[i].Length>0; i++) 
                finDif.Add(Derivative(finDif[i])); 
            return finDif;
        }

        float upb;
        public double UpBord(float[] a, int k=1) {
            int iter=0;
            if (a[0] < 0)
                for (int i = 0; i < a.Length; i++)
                    a[i] *= -1;
            List<float[]> difr = FinDif(a);
            for(int i = 0; i < difr.Count; i++)
                while (Lab1_1.Gorner(a, k) < 0) {
                    if (iter > 100) return 0;
                    iter++;
                    k++;
                }
            return k;
        }

        // Результат конкретно этого пункта
        float[] out1_1;
        Polynomial poly1;
        Polynomial poly2;

        // Перевод результата в выходные данные
        public override string OutData1()
        {
            poly1 = new Polynomial(inputData1);
            outData1 = $"Введен полином: \n" +
                       $"f(x) = {poly1.strForm}" +
                       $"\nВерхняя граница действительных корней: \n" +
                       $"{UpBord(poly1.floatForm)}";
            // if (poly2.floatForm.Length == 0) 
            outData1FormPosDeeg = poly1.FindDegPos(outData1, poly1.degreesPositions.Length);
            outData1FormLenDeeg = poly1.lengthOfDegrees.ToArray();
            outData1FormPosMult = poly1.FindMultPos(outData1, poly1.degreesPositions.Length);
            return outData1;
        }
    }
}
