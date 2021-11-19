using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LabWorkCompMath.GeneralLab;
using LabWorkCompMath;

namespace LabWorkCompMath {
    class Lab1_5 : Lab {

        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // Эти поля необходимы для быстрой отладки
        // Заполнив их 1 раз, можно сэкономить время на вводе данных
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public Lab1_5() : this(null) { }

        public Lab1_5(Button relatedButton) : base(relatedButton) {
            labelName       = "5.	Найти корни полинома c помощью анализа промежутков";
            labelDataName1  = "коэффициенты полинома:";
            labelDataName2  = "число искомых корней:";
            // Число данных
            numData     = 1;
            // Число тестов
            numTests    = 3;
            // Эти данные будут вводиться во входную строку, имитируя ручной ввод
            // Номер теста_номер входной строки
            test1_1     = "1;-7;7;15;0;0;0";
            test2_1     = "4;0;-95;75;226;-120";
            test3_1     = "1;3;-14;-30;49;27;-36";
            test1_2     = "3";
            test2_2     = "3";
            test3_2     = "3";

        }

        // В данном случае не выношу переменные, так как важность понятности программы превышает 
        // затраты памяти, кроме того в С# работает автоматическая сборка мусора!
        // Кроме того это позволяет использовать функции в других программах!

        // ГЛАВНЫЙ АЛГОРИТМ
        public float[] DichotomyForPoly(float[] a, int nR){
            float[] Roots       = new float[nR]; // Тип данных float необходим для повторного использования кода
            if ((a.Length - 1) < nR) return Roots; // Проверка на возможность найти необходимое количество корней

            int     iter        = 0;
            float   rightBorder = Lab2_4.BorderUp(a,0,1);
            float   leftBorder  = Lab2_4.BorderDown(a, 0, 1);
            float   middle      = (rightBorder + leftBorder) / 2;
            int     nRoots      = 0;

            while (nRoots< nR) {
                if (iter > 1000) return (Roots); // Страхование на случай превышения n попыток найти значение
                if ((Lab1_1.Gorner(a, middle) < 0.001) && (Lab1_1.Gorner(a, middle) >= -0.001)) {
                    Roots[nRoots] = middle;
                    nRoots++;
                }
                if (Lab1_1.Gorner(a, leftBorder) * Lab1_1.Gorner(a, middle) < 0)
                rightBorder = middle;
                else
                    leftBorder = middle;
                middle = (rightBorder + leftBorder) / 2;
                iter++;
            }
          
            return Roots;
        }

        public float[] SplitIntoIntervals(float leftBorder, float rightBorder, float step) {
            float[] intervals = new float[(int)Math.Ceiling((rightBorder - leftBorder + 1)/step)];
            intervals[0] = leftBorder;
            for (int i = 1; intervals[i - 1] + step < rightBorder; i++) 
                intervals[i] = intervals[i - 1] + step;
            intervals[intervals.Length-1] = rightBorder;
            return intervals;
        }
        // Перегрузка SplitIntoIntervals с step = 1
        // !!! Нужны тесты
        public float[] SplitIntoIntervals(float leftBorder, float rightBorder) {
            float[] intervals = new float[(int)Math.Ceiling(rightBorder - leftBorder+1)];
            intervals[0] = leftBorder;
            for (int i = 1; intervals[i - 1] + 1 < rightBorder; i++)
                intervals[i] = intervals[i - 1] + 1;
            intervals[intervals.Length - 1] = rightBorder;
            return intervals;
        }

        // Страшный алгоритм, попытка понять причем в интервалах метод дихотомии
        // Нахождение корней разбиванием интервала поиска на промежутки  с помощью дихотомии 
        // невозможно в силу нарушения условия равенства знаков границ
        public float[] IntervalsForPoly(float[] a) {
            float[] roots = new float[a.Length-1]; // Тип данных float необходим для повторного использования кода
            int   nRoots = 0;
            float[] intervals = SplitIntoIntervals(Lab2_4.BorderDown(a, 0, 1), Lab2_4.BorderUp(a, 0, 1), 0.5f);
            for (int i = 0; i < intervals.Length; i++) {
                //while (((Lab1_1.Gorner(a, middle) > 0.001) || (Lab1_1.Gorner(a, middle) < -0.001))&&(leftBorder <= rightBorder))
                if ((Lab1_1.Gorner(a, intervals[i]) <= 0.001) && (Lab1_1.Gorner(a, intervals[i]) >= -0.001)) {
                    if (nRoots<roots.Length) roots[nRoots] = intervals[i];
                    nRoots++;
                } 
            }

            return roots;
        }

        // ГЛАВНЫЙ АЛГОРИТМ
        // Ищет все корни полинома методом исследования интервалов, включая кратные
        public float[] IntervalsForPolyAll(float[] a, float step) {
            float[] b = a;
            float[] roots = new float[b.Length - 1]; // Тип данных float необходим для повторного использования кода
            int nRoots = 0;
            float point = Lab2_4.BorderDown(b, 0, 1);
            float leftBorder = Lab2_4.BorderUp(b, 0, 1);

            while (point < leftBorder) {
                if ((Lab1_1.Gorner(b, point) <= 0.001) && (Lab1_1.Gorner(b, point) >= -0.001)) {
                    if (nRoots > roots.Length) break;
                    roots[nRoots] = point;
                    b = Lab2_2.GornerDiv(b, point);
                    nRoots++;
                    continue;
                }
                point += step;
            }
            return roots;
        }

        public float DichotomyForPoly(float[] a, float rightBorder, float leftBorder) {
            int iter = 0;
            float middle = (rightBorder + leftBorder) / 2;

            while ((Lab1_1.Gorner(a, middle) > 0.001) || (Lab1_1.Gorner(a, middle) < -0.001))
            {
                if (iter > 10000) return (123456789); // Страхование на случай превышения n попыток найти значение

                if (Lab1_1.Gorner(a, leftBorder) * Lab1_1.Gorner(a, middle) < 0)
                    rightBorder = middle;
                else
                    leftBorder = middle;
                middle = (rightBorder + leftBorder) / 2;
                iter++;
            }

            return middle;
        }
        // ГЛАВНЫЙ АЛГОРИТМ ВАРИАНТ 2
        // Та же функция, только с  первым возвращаемым корнем
        public float DichotomyForPoly(float[] a)
        {
            int iter = 0;
            float rightBorder = Lab2_4.BorderUp(a, 0, 1);
            float leftBorder = Lab2_4.BorderDown(a, 0, 1);
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


        // Результат конкретно этого пункта 
        float[] out1_1;
        Polynomial poly1;

        // Перевод результата в выходные данные
        public override string OutData1() {
            poly1 = new Polynomial(inputData1);
            outData1 = $"Введен полином: \n" +
                        $"f(x)={poly1.strForm}";
           out1_1 = IntervalsForPolyAll(inputData1, 0.5f);
            outData1 = outData1 +
                        "\nНайденные корни:" +
                        '[' + string.Join(" ", out1_1) + ']' +
                        "\n\n" +
                        "При ошибке входных данных выдаются нули.";
            outData1FormPosDeeg = poly1.FindDegPos(outData1, poly1.degreesPositions.Length);
            outData1FormLenDeeg = poly1.lengthOfDegrees;
            return outData1;
        }

    }
}
