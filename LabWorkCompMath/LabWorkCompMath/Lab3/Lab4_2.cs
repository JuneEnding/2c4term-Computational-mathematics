﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabWorkCompMath.GeneralLab;
using System.Windows.Forms;

namespace LabWorkCompMath.Lab3
{
    public class Lab4_2 : Lab
    {

        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // Эти поля необходимы для быстрой отладки
        // Заполнив их 1 раз, можно сэкономить время на вводе данных
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public Lab4_2() : this(null) { }

        public Lab4_2(Button relatedButton) : base(relatedButton)
        {
            labelName = "2. Определить верхнюю границу положительных действительных корней полинома по методу Лагранжа";
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
            maxAbsB = a[0]*-1;
            for(int i = 0; i < a.Length; i++) 
                if (a[i] < 0)
                    if (a[i] * -1 > maxAbsB)
                        maxAbsB = a[i] * -1;
            return maxAbsB;
        }
         
        float upb;
        public double UpBord(float[] a) {
            int i = 1;
            if (a[0] < 0)
                for (int k = 0; k < a.Length; k++)
                    a[k] *= -1; 
            while ((a[i] >= 0) && (i < a.Length))
                i++;
            if (i >= a.Length)
                return 0;

            return 1 + Math.Pow((double)(FindB(a) / a[0]), 1.0 / i);
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
