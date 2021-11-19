using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabWorkCompMath.GeneralLab;
using System.Windows.Forms;

namespace LabWorkCompMath.Lab2
{
    class Lab2_1 : Lab
    {

        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // Эти поля необходимы для быстрой отладки
        // Заполнив их 1 раз, можно сэкономить время на вводе данных
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public Lab2_1() : this(null) { }

        public Lab2_1(Button relatedButton) : base(relatedButton)
        {
            labelName = "1. Найти производную полинома";
            labelDataName1 = "коэффициенты полинома:";
            // Число данных
            numData = 1;
            // Число тестов
            numTests = 4;
            // Эти данные будут вводиться во входную строку, имитируя ручной ввод
            // Номер теста_номер входной строки
            test1_1 = "1;1;1;1;1;1";
            test2_1 = "3;7;-5;-2;4";
            test3_1 = "-2;5";
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

        // Результат конкретно этого пункта
        float[] out1_1;
        Polynomial poly1;
        Polynomial poly2;

        // Перевод результата в выходные данные
        public override string OutData1() {
            poly1 = new Polynomial(inputData1);
            //algorithm(inputData1, inputData2, inputData3);
            out1_1 = Derivative(inputData1);
            poly2 = new Polynomial(out1_1);
            outData1 = $"Введен полином: \n" +
                       $"f(x) = {poly1.strForm}" +
                       $"\nПроизводная от полинома : \n" +
                       $"f(x) = {poly2.strForm}";
           // if (poly2.floatForm.Length == 0) 
            outData1FormPosDeeg = poly1.FindDegPos(outData1, poly1.degreesPositions.Length + poly2.degreesPositions.Length);
            outData1FormLenDeeg = poly1.lengthOfDegrees.Concat(poly2.lengthOfDegrees).ToArray();
            outData1FormPosMult = poly1.FindMultPos(outData1, poly1.degreesPositions.Length + poly2.degreesPositions.Length);
            return outData1;
        }
    }
}
