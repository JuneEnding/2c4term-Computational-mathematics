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
    class Lab2_2_2 : Lab{

        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // Эти поля необходимы для быстрой отладки
        // Заполнив их 1 раз, можно сэкономить время на вводе данных
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public Lab2_2_2() : this(null) { }

        public Lab2_2_2(Button relatedButton) : base(relatedButton) {
            labelName = "2.	Методом хорд найти наибольший из корней уравнения";
            labelDataName1 = "коэффициенты полинома:";
            labelDataName2 = "верхняя граница:";
            labelDataName3 = "степень приближения:";
            // Число данных
            numData = 2;
            // Число тестов
            numTests = 5;
            // Эти данные будут вводиться во входную строку, имитируя ручной ввод
            // Номер теста_номер входной строки
            test1_1 = "1;-4;-42;104;361;-420";
            test2_1 = "10;42;-137;-604;-615;-100";
            test3_1 = "1;-2;-39;148;-140";
            test4_1 = "1;-13;47;-23;-48;36";
            test5_1 = "1;-1;-3;-9";

            test1_2 = "9";
            test2_2 = "5";
            test3_2 = "8";
            test4_2 = "13";
            test5_2 = "3";

            test1_3 = "10";
            test2_3 = "10";
            test3_3 = "10";
            test4_3 = "10";
            test5_3 = "10";
        }

      
        // ДЕЛЕНИЕ ПРОМЕЖУТКА НА БОЛЕЕ МЕЛКИЕ ПРОМЕЖУТКИ РАЗМЕРОМ < STEP
        public float[] SplitIntoIntervals(float leftBorder, float rightBorder, float step)
        {
            float[] intervals = new float[(int)Math.Ceiling((rightBorder - leftBorder + 1) / step)];
            intervals[0] = leftBorder;
            for (int i = 1; intervals[i - 1] + step < rightBorder; i++)
                intervals[i] = intervals[i - 1] + step;
            intervals[intervals.Length - 1] = rightBorder;
            return intervals;
        }
        // Перегрузка SplitIntoIntervals с step = 1
        // !!! Нужны тесты
        public float[] SplitIntoIntervals(float leftBorder, float rightBorder)
        {
            float[] intervals = new float[(int)Math.Ceiling(rightBorder - leftBorder + 1)];
            intervals[0] = leftBorder;
            for (int i = 1; intervals[i - 1] + 1 < rightBorder; i++)
                intervals[i] = intervals[i - 1] + 1;
            intervals[intervals.Length - 1] = rightBorder;
            return intervals;
        }

        // Страшный алгоритм, попытка понять причем в интервалах метод дихотомии
        // Нахождение корней разбиванием интервала поиска на промежутки  с помощью дихотомии 
        // невозможно в силу нарушения условия равенства знаков границ
        public float[] IntervalsForPoly(float[] a)
        {
            float[] roots = new float[a.Length - 1]; // Тип данных float необходим для повторного использования кода
            int nRoots = 0;
            float[] intervals = SplitIntoIntervals(Lab2_4.BorderDown(a, 0, 1), Lab2_4.BorderUp(a, 0, 1), 0.5f);
            for (int i = 0; i < intervals.Length; i++)
            {
                //while (((Lab1_1.Gorner(a, middle) > 0.001) || (Lab1_1.Gorner(a, middle) < -0.001))&&(leftBorder <= rightBorder))
                if ((Lab1_1.Gorner(a, intervals[i]) <= 0.001) && (Lab1_1.Gorner(a, intervals[i]) >= -0.001))
                {
                    if (nRoots < roots.Length) roots[nRoots] = intervals[i];
                    nRoots++;
                }
            }

            return roots;
        }


        // Ищет все корни полинома методом исследования интервалов СНИЗУ, включая кратные
        public float[] SeparatingRootsBottom(float[] a, float step)
        {
            float[] b = a;
            float[] roots = new float[b.Length - 1]; // Тип данных float необходим для повторного использования кода
            int nRoots = 0;
            float point = Lab2_4.BorderDown(b, 0, 1);
            float rightBorder = Lab2_4.BorderUp(b, 0, 1);

            while (point < rightBorder)
            {
                if ((Lab1_1.Gorner(b, point) <= 0.001) && (Lab1_1.Gorner(b, point) >= -0.001))
                {
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

        // Ищет все корни полинома методом исследования интервалов СВЕРХУ, включая кратные
        public float[] SeparatingRootsTop(float[] a, float step) {
            float[] b = a;
            float[] roots = new float[b.Length - 1]; // Тип данных float необходим для повторного использования кода
            int nRoots = 0;
            float point = Lab2_4.BorderUp(b, 0, 1);
            float leftBorder = Lab2_4.BorderDown(b, 0, 1);

            while (point >= leftBorder) {
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

        //------------------------------------------------------------------------
        // Нахождение максимального корня с помощью анализа промежутков
        public float MaxRootTop(float[] a, float step) {
            float[] b = a;
            float point = Lab2_4.BorderUp(b, 0, 1);
            float leftBorder = Lab2_4.BorderDown(b, 0, 1); 

            while (point >= leftBorder) {
                if ((Lab1_1.Gorner(b, point) <= 0.001) && (Lab1_1.Gorner(b, point) >= -0.001)) 
                    break;
                point += step;
            }
            return point;
        }

        // ГЛАВНЫЙ АЛГОРИТМ
        // МЕТОД ХОРД
        // ???? Как связана с пунктом вторая производная (выпуклость - впуклость)
        // ??? Для метода необходимо анализировать выпуклость?
        public float[] ChordsMaybe(float[] a, int nA) {
            float[] approximations = new float[nA];
            int nApprox = 0;
            float up = Lab2_4.BorderUp(a, 0, 1);
            float down = Lab2_4.BorderDown(a, 0, 1);
            int iter = 0;

            // Проверка условия применения метода
            if (up*down>0) return approximations; 

            while (iter < nA) {
                if (Lab1_1.Gorner(a, up) - Lab1_1.Gorner(a, down) == 0) continue;
                approximations[nApprox] = down - (Lab1_1.Gorner(a, down)) * (up - down) / (Lab1_1.Gorner(a, up) - Lab1_1.Gorner(a, down));
                if (Lab1_1.Gorner(a, down) * Lab1_1.Gorner(a, approximations[nApprox]) < 0)
                    up = approximations[nApprox];
                else
                    down = approximations[nApprox];
                nApprox++;
                iter++;

            }
            return approximations;
        }

        public float Chords(float[] a, float upB) {
            float approxX = upB;
            float downB = upB;
            int signAbroad = 1;
            int iter = 0;
            if (Lab1_1.Gorner(a, upB + 0.5f) < 0) signAbroad = -1; // ускоряет вычисление
            while (Lab1_1.Gorner(a, downB) * signAbroad >0) {
                downB -= 0.5f;
            }

            while (true) { // Исправить до точности!
                if (iter>10000) break;
                if (Lab1_1.Gorner(a, upB) - Lab1_1.Gorner(a, downB) == 0) break;
                approxX = downB - (Lab1_1.Gorner(a, downB)) * (upB - downB) / (Lab1_1.Gorner(a, upB) - Lab1_1.Gorner(a, downB));
                if ((Lab1_1.Gorner(a, downB) <= 0.001)&& (Lab1_1.Gorner(a, downB) >= - 0.001)) return approxX;
                if (Lab1_1.Gorner(a, downB) * Lab1_1.Gorner(a, approxX) < 0) // ?? Нужна ли проверка??
                    upB = approxX;
                else
                    downB = approxX;
                iter++;
            }
            return approxX;
        }

        // Результат конкретно этого пункта 
        float out1_1;
        Polynomial poly1;

        // Перевод результата в выходные данные
        public override string OutData1() {
            poly1 = new Polynomial(inputData1);
            outData1 = $"Введен полином: \n" +
                        $"f(x)={poly1.strForm}";
            out1_1 = Chords(inputData1, (int)inputData2[0]);
            outData1 = outData1  +
                        "\nНайденный приближенный корень с точностью 0.001:\n" +
                        ' ' + string.Join(" ", out1_1) + ' ' +
                        "\n\n" +
                        "При ошибке входных данных может выдаться ноль.";
            outData1FormPosDeeg = poly1.FindDegPos(outData1, poly1.degreesPositions.Length);
            outData1FormLenDeeg = poly1.lengthOfDegrees;
            return outData1;
        }

    }
}
