using LabWorkCompMath.GeneralLab;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System;

namespace LabWorkCompMath.Lab2 {
    //********************************************************************************
    // ЛАБОРАТОРНАЯ РАБОТА 3, пункт 5 (делала работу четвертой, во избежание конфликта имен оставила так)
    //********************************************************************************
    class Lab4_5 : Lab  {

        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // Эти поля необходимы для быстрой отладки
        // Заполнив их 1 раз, можно сэкономить время на вводе данных
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public Lab4_5() : this(null) { }

        public Lab4_5(Button relatedButton) : base(relatedButton) {
            inputData1 = new List<float[]>();
            typeInput = 1;
            labelName = "5. Определить количество действительных корней по методу Штурма";
            labelDataName1 = "коэффициенты полинома:";

            // Число данных
            numData = 1;
            // Число тестов
            numTests = 4;
            // Эти данные будут вводиться во входную строку, имитируя ручной ввод
            // Номер теста_номер входной строки
            test1_1 = "1;-4;-42;104;361;-420";
            test2_1 = "-1;-2;-2;-5;0;3;4;2;-5;0";
            test3_1 = "1;1,4;-13,85;1,842;6,264";
            test4_1 = "1;0;1";

        }
        // В данном случае не выношу переменные, так как важность понятности программы превышает 
        // затраты памяти, кроме того в С# работает автоматическая сборка мусора!
        // Кроме того это позволяет использовать функции в других программах!

        public static List<float[]> DerivativeX(List<float[]> a) {
        List<float[]> b;
            b = new List<float[]>();
            for (int i = 0; i < a.Count; i++) {
                b.Add( Lab2_1.Derivative(a[i]));
            }
            return b;
        }
        public static List<float[]> DerivativeY(List<float[]> a) {
        List<float[]> b;
            b = new List<float[]>();
            if (a.Count == 0) return b;
            //line = new float[a[0].Length];
            for (int i = 0; i < a.Count - 1; i++) { 
                b.Add(Line(a, i));
            }
            return b;
        }
        public static float[] Line(List<float[]> a, int i) {
            float[] line;
            line = new float[a[0].Length];
            for (int j = 0; j < line.Length; j++) {
                line[j] = a[i][j] * (a.Count - 1 - i);
            }
            return line;
        }

        public static float Poly_R(float[] a) {
            float max;
            max = new float();
            while ((Lab1_1.Gorner(a, 0) <= 0.001) && (Lab1_1.Gorner(a, 0) >= -0.001))
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
            for (int i = 0; i < a.Length - 1; i++)
                if (Math.Abs(a[i]) > max)
                    max = Math.Abs(a[i]);

            return 1 / (1 + max / Math.Abs(a[a.Length - 1]));
        }


        //**************************************************************************************
        // ГЛАВНЫЙ АЛГОРИТМ
        //**************************************************************************************
        // Тут необходимо вставить проверку на наличие кратных корней. Предполагаю, что их нет!
        //public int Assault(float[] p, int ex = 100) {
        public int Assault(float[] p) {
            int n = 0;
            int i = 1;
            List<float[]> aSys = new List<float[]>(); // Система Штурма
            //Заполняю систему Штурма
            aSys.Add(p);
            aSys.Add(Lab2_1.Derivative(p));
            while (aSys[i].Length>1) { // Проверить проверку конца составления системы
                aSys.Add(Lab4_4.PolynomialDivide(aSys[i - 1], aSys[i])[1]);
                i++;
                for (int k = 0; k< aSys[i].Length; k++)
                    aSys[i][k] *= -1;
            }
            return N(aSys, -Poly_R(p)-1) - N(aSys, Poly_R(p)+1); // (4) с 170 Демидович Марон
        }

        public int N(List<float[]> aSys, float x) {
            int n = 0;
            for (int i =1; i<aSys.Count; i++)
                if (Lab1_1.Gorner(aSys[i - 1], x) * Lab1_1.Gorner(aSys[i], x) < 0)
                    n++;
            return n;
        }

        new List<float[]> inputData1;
        float out1_1;
        Polynomial poly1;
        LabArray array1;

        // Перевод результата в выходные данные
        public override string OutData1(){
            poly1 = new Polynomial();
            array1 = new LabArray(inSData1);
            outData1 = $"Вы ввели: \nf(x) =";
            outData1 += array1.viewForm;
            outData1 = outData1 + "\nКоличества корней:\n" + Assault(array1.arrForm[0]);
            if (array1.arrForm == null)
                outData1 += "\nОшибка: многочлен задан некорректно!";
            outData1FormPosDeeg = array1.FindDegPos(outData1, array1.degreesPositions.Length);
            array1.lengthOfDegrees = CutNull(array1.lengthOfDegrees);

            outData1FormLenDeeg = array1.lengthOfDegrees.ToArray();
            return outData1;
        }

    }
}
