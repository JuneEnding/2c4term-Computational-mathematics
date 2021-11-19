using System.Collections.Generic;
using LabWorkCompMath.GeneralLab;
using System.Windows.Forms;
using System.Linq;
using System;
namespace LabWorkCompMath.Lab2 {
    //********************************************************************************
    // ЛАБОРАТОРНАЯ РАБОТА 3, пункт 6 (делала работу четвертой, во избежание конфликта имен оставила так)
    //********************************************************************************
    class Lab4_6 : Lab {

        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // Эти поля необходимы для быстрой отладки
        // Заполнив их 1 раз, можно сэкономить время на вводе данных
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public Lab4_6() : this(null) { }

        public Lab4_6(Button relatedButton) : base(relatedButton) {
            inputData1 = new List<float[]>();
            typeInput = 1;
            labelName = "6. Отделить корни полинома с помощью метода Штурма и вычислить их по одному из методов, реализованных \nв предыдущих лабораторных работах.";
            labelDataName1 = "коэффициенты полинома:";
            labelDataName2 = "комплексная матрица:";
            labelDataName3 = "грубый корень:";
            // Число данных
            numData = 1;
            // Число тестов
            numTests = 4;
            // Эти данные будут вводиться во входную строку, имитируя ручной ввод
            // Номер теста_номер входной строки
            test1_1 = "1;-4;-42;104;361;-420";
            test2_1 = "-1;-2;-2;-5;0;-3;-4;2;-5;0";
            test3_1 = "1;1,4;-13,85;1,842;6,264";
            test4_1 = "1;-2,18;-20,156;88,1304;-121,0277;49,4916;7,8382";

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
        // Тут необходимо вставить проверку на наличие кратных корней. Предполагаю, что их нет!
        // public int Assault(float[] p, int ex = 100) {
        public int Assault(float[] p) {
            int n = 0;
            int i = 1;
            List<float[]> aSys = new List<float[]>(); // Система Штурма
            //Заполняю систему Штурма
            aSys.Add(p);
            aSys.Add(Lab2_1.Derivative(p));
            while (aSys[i].Length > 1) { // Проверить проверку конца составления системы
                aSys.Add(Lab4_4.PolynomialDivide(aSys[i - 1], aSys[i])[1]);
                i++;
                for (int k = 0; k < aSys[i].Length; k++)
                    aSys[i][k] *= -1;
            }
            return N(aSys, -Poly_R(p) - 1) - N(aSys, Poly_R(p) + 1);
        }

        public int N(List<float[]> aSys, float x) {
            int n = 0;
            for (int i = 1; i < aSys.Count; i++)
                if (Lab1_1.Gorner(aSys[i - 1], x) * Lab1_1.Gorner(aSys[i], x) < 0)
                    n++;
            return n;
        }

        public float DichotomyForPoly(float[] a, float leftBorder, float rightBorder) {
            int iter = 0;
            float middle = (rightBorder + leftBorder) / 2;

            while ((Lab1_1.Gorner(a, middle) > 0.001) || (Lab1_1.Gorner(a, middle) < -0.001))
            {
                if (iter > 100000) return (123456789); // Страхование на случай превышения n попыток найти значение

                if (Lab1_1.Gorner(a, leftBorder) * Lab1_1.Gorner(a, middle) < 0)
                    rightBorder = middle;
                else
                    leftBorder = middle;
                middle = (rightBorder + leftBorder) / 2;
                iter++;
            }

            return middle;
        }

        //**************************************************************************************
        // ГЛАВНЫЙ АЛГОРИТМ
        //**************************************************************************************
        public List<float[]> MainF(float[] p, float step = 0.0005f) {
            List<float[]> res = new List<float[]>();
            List<float[]> res2 = new List<float[]>();
            res.Add(new float[p.Length]);
            res.Add(new float[p.Length]);
            res.Add(new float[p.Length]);
            int n = 0;
            int i = 1;
            List<float[]> aSys = new List<float[]>(); // Система Штурма
            //Заполняю систему Штурма
            aSys.Add(p);
            aSys.Add(Lab2_1.Derivative(p));
            while (aSys[i].Length > 1) { // Проверить проверку конца составления системы
                aSys.Add(Lab4_4.PolynomialDivide(aSys[i - 1], aSys[i])[1]);
                i++;
                for (int k = 0; k < aSys[i].Length; k++)
                    aSys[i][k] *= -1;
            }
            // !!! Как я понимаю, задачу можно было решить несколькими способами: 1) отталкиваясь от границ
            // Тогда нужно было искать N(a) - N(b)=1 с шагом 1, если N(a) - N(b)=2, уменьшаю интервал до нахождения N(a) - N(b)=1
            // после отделенные корни можно найти любым известным методом
            // 2) Искать сами корни, для сравнения точности после можно легко от них найти границы их содержания для проверки другими методами
            // Для обучения я решила реализовать второй способ. Поняла, что он плох, ибо точность нахождения корней методом Штурма зависит от
            // задаваемого шага, тратится время на циклы. Способ отделения корней неточен.
            // На практике я буду применять метод 1). 

            float a = -Poly_R(p); // min граница
            float B = Assault(p);
            float B2 = Poly_R(p); // max граница
            float b = a+step;
            int t = 0;
            int c = 0;
            for (int k=0; k <= B;k++) {
                while (N(aSys, a) - N(aSys, b)!=1) { // главное условие задачи
                    b += step;
                    t++;
                    if (b > B2) {
                        res2.Add(new float[c]);
                        res2.Add(new float[c]);
                        res2.Add(new float[c]);
                        res2.Add(new float[c]);
                        for (int j = 0; j < res.Count; j++)
                            for (int l = 0; l < res2[0].Length; l++)
                                res2[j][l] = res[j][l];
                        for (int l = 0; l < res2[0].Length; l++)
                            res2[3][l] = DichotomyForPoly(p, res2[1][l], res2[2][l]);
                        return res2;
                    }
                }
                res[0][k] = b;
                res[1][k] = b - step;
                res[2][k] = b + step;
                a = b;
                b = a + step;
                t++;
                c++;
            }


            return res;
        }

        new List<float[]> inputData1;
        List<float[]> out1_1;
        Polynomial poly1;
        LabArray array1;

        // Перевод результата в выходные данные
        public override string OutData1() {
            poly1 = new Polynomial();
            array1 = new LabArray(inSData1);
            outData1 = $"ВЫ ВВЕЛИ: \nf(x) =";
            outData1 += array1.viewForm;
            out1_1 = MainF(array1.arrForm[0]);
            outData1 += "\n\nОтвет:\n";
            for(int i=0;i< out1_1[0].Length; i++) {
                outData1 += $"\nКорень\t" + out1_1[0][out1_1[0].Length-1-i];
                outData1 += "\tcодержится в интервале: [ " + out1_1[1][out1_1[0].Length-1-i] + ",\t" + out1_1[2][out1_1[0].Length - 1 - i]+" ]";
                outData1 += $"\nЧерез Дихотомию равен\t" + out1_1[3][out1_1[0].Length-1-i]+"\n";
            }
            outData1FormPosDeeg = array1.FindDegPos(outData1, array1.degreesPositions.Length);
            array1.lengthOfDegrees = CutNull(array1.lengthOfDegrees);
            outData1FormLenDeeg = array1.lengthOfDegrees.ToArray();
            return outData1;
        }
    }
}
