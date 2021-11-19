using System;
using LabWorkCompMath.GeneralLab;
using System.Windows.Forms;

namespace LabWorkCompMath.Lab2
{
    class Lab2_3_2 : Lab
    {

        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // Эти поля необходимы для быстрой отладки
        // Заполнив их 1 раз, можно сэкономить время на вводе данных
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public Lab2_3_2() : this(null) { }

        public Lab2_3_2(Button relatedButton) : base(relatedButton)
        {
            labelName = "3. Методом Ньютона найти наибольший из корней уравнения";
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
        }


        // ДЕЛЕНИЕ ПРОМЕЖУТКА НА БОЛЕЕ МЕЛКИЕ ПРОМЕЖУТКИ РАЗМЕРОМ <= STEP
        public float[] SplitIntoIntervals(float leftBorder, float rightBorder, float step) {
            float[] intervals = new float[(int)Math.Ceiling((rightBorder - leftBorder + 1) / step)];
            intervals[0] = leftBorder;
            for (int i = 1; intervals[i - 1] + step < rightBorder; i++)
                intervals[i] = intervals[i - 1] + step;
            intervals[intervals.Length - 1] = rightBorder;
            return intervals;
        }
        // Перегрузка SplitIntoIntervals с step = 1
        // !!! Нужны тесты
        public float[] SplitIntoIntervals(float leftBorder, float rightBorder) {
            float[] intervals = new float[(int)Math.Ceiling(rightBorder - leftBorder + 1)];
            intervals[0] = leftBorder;
            for (int i = 1; intervals[i - 1] + 1 < rightBorder; i++)
                intervals[i] = intervals[i - 1] + 1;
            intervals[intervals.Length - 1] = rightBorder;
            return intervals;
        }

        // Ищет все корни полинома методом исследования интервалов СНИЗУ, включая кратные
        public float[] SeparatingRootsBottom(float[] a, float step)
        {
            float[] b = a;
            float[] roots = new float[b.Length - 1]; // Тип данных float необходим для повторного использования кода
            int nRoots = 0;
            float point = Lab2_4.BorderDown(b, 0, 1);
            float rightBorder = Lab2_4.BorderUp(b, 0, 1);

            while (point < rightBorder) {
                if ((Lab1_1.Gorner(b, point) <= 0.001) && (Lab1_1.Gorner(b, point) >= -0.001)){
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

        //------------------------------------------------------------------------
        // Нахождение максимального корня с помощью анализа промежутков
        public float MaxRootTop(float[] a, float step)
        {
            float[] b = a;
            float point = Lab2_4.BorderUp(b, 0, 1);
            float leftBorder = Lab2_4.BorderDown(b, 0, 1);

            while (point >= leftBorder)
            {
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
        public float[] ChordsMaybe(float[] a, int nA)
        {
            float[] approximations = new float[nA];
            int nApprox = 0;
            float up = Lab2_4.BorderUp(a, 0, 1);
            float down = Lab2_4.BorderDown(a, 0, 1);
            int iter = 0;

            // Проверка условия применения метода
            if (up * down > 0) return approximations;

            while (iter < nA)
            {
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
            while (Lab1_1.Gorner(a, downB) * signAbroad > 0) {
                downB -= 0.5f;
            }

            while (true)
            { // Исправить до точности!
                if (iter > 10000) break;
                if (Lab1_1.Gorner(a, upB) - Lab1_1.Gorner(a, downB) == 0) break;
                approxX = downB - (Lab1_1.Gorner(a, downB)) * (upB - downB) / (Lab1_1.Gorner(a, upB) - Lab1_1.Gorner(a, downB));
                if ((Lab1_1.Gorner(a, downB) <= 0.001) && (Lab1_1.Gorner(a, downB) >= -0.001)) return approxX;
                if (Lab1_1.Gorner(a, downB) * Lab1_1.Gorner(a, approxX) < 0) // ?? Нужна ли проверка??
                    upB = approxX;
                else
                    downB = approxX;
                iter++;
            }
            return approxX;
        }


        //??? Если выражение не подходит под условия, то нужно увеличивать отрезок исследования
        //    Или прекращать алгоритм???
        float x0;
        float xn;
        float downB;
        int signAbroad;
        int iter;
        float[] derivA;
        float[] deriv2A;

        //public float Newton(float[] a, float upB, float exact = 0.001f) {
        //    error = "";
        //    downB = upB;
        //    signAbroad = 1;
        //    iter = 0;
        //    derivA = Lab2_1.Derivative(a);
        //    deriv2A = Lab2_1.Derivative(Lab2_1.Derivative(a));
        //    if (Lab1_1.Gorner(a, upB + 0.5f) < 0) signAbroad *= -1; // ускоряет вычисление
        //    while (Lab1_1.Gorner(a, downB) * signAbroad > 0) {
        //        if (iter > 100) {  break; }
        //        downB -= 0.5f;
        //        iter++;
        //    }
        //    iter = 0;
        //    if (Lab1_1.Gorner(a, upB) * Lab1_1.Gorner(deriv2A, upB) < 0)
        //        x0 = upB;
        //    else
        //        x0 = downB;
        //    xn = x0;
        //    while ((xn-x0 < -exact) || (xn - x0 > exact)) { 
        //        if (iter > 100000) return x0; 
        //        if (Lab1_1.Gorner(derivA, x0) == 0)  return x0; 
        //        x0 = xn;
        //        xn = x0 - Lab1_1.Gorner(a, x0) / Lab1_1.Gorner(derivA, x0);
        //        iter++;
        //    }
        //    error = "\nПонадобилось итераций: " + iter;
        //    return x0;
        //}
        public float Newton(float[] a, float upB, float exact = 0.0001f)
        {
            error = "";
            downB = upB;
            signAbroad = 1;
            iter = 0;
            derivA = Lab2_1.Derivative(a);
            deriv2A = Lab2_1.Derivative(Lab2_1.Derivative(a));
            if (Lab1_1.Gorner(a, upB + 0.5f) < 0) signAbroad *= -1; // ускоряет вычисление
            while (Lab1_1.Gorner(a, downB) * signAbroad > 0)
            {
                if (iter > 10000) { error = "Превышен лимит итераций при поиске границ!"; return x0; }
                downB -= 0.5f;
                iter++;
            }
            if (Lab1_1.Gorner(a, upB) * Lab1_1.Gorner(deriv2A, upB) < 0)
                x0 = upB;
            else
                x0 = downB;
            //xn = x0;
            xn = x0 - Lab1_1.Gorner(a, x0) / Lab1_1.Gorner(derivA, x0);
            while ((xn - x0 < -exact) || (xn - x0 > exact))
            {
                if (iter > 100000) { error = "Превышен лимит итераций при поиске корня!"; return x0; }
                if (Lab1_1.Gorner(derivA, x0) == 0) { error = "f'(a) = 0"; return x0; }
                x0 = xn;
                xn = x0 - Lab1_1.Gorner(a, x0) / Lab1_1.Gorner(derivA, x0);
                iter++;
            }
            error = "\nПонадобилось итераций: " + iter;
            return x0;
        }

        // Результат конкретно этого пункта 
        float out1_1;
        Polynomial poly1;

        // Перевод результата в выходные данные
        public override string OutData1() {
            poly1 = new Polynomial(inputData1);
            outData1 = $"Введённые данные: \n" +
                        $"f(x)={poly1.strForm}";
            out1_1 = Newton(inputData1, (int)inputData2[0]);
            outData1 = outData1 +
                        "\nНайденный МАКСИМАЛЬНЫЙ приближенный корень с точностью 0.001:\n" +
                        ' ' + string.Join(" ", out1_1) + ' ';
            if (error != "") outData1 = outData1 + "\n\n" + error;
            outData1FormPosDeeg = poly1.FindDegPos(outData1, poly1.degreesPositions.Length);
            outData1FormLenDeeg = poly1.lengthOfDegrees;
            return outData1;
        }

    }
}
