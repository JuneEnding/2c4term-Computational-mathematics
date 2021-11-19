using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWorkCompMath
{
    class Lab1_5 : Lab
    {

        public Lab1_5()
        {
            labelName = "5.	Найти один из корней полинома методом дихотомии";
            labelDataName1 = "коэффициенты полинома:";
            labelDataName2 = "число искомых корней:";
            // Число данных
            numData = 2;
            // Число тестов
            numTests = 3;
            // Номер теста_номер входной строки
            test1_1 = "1;-7;7;15;0;0;0";
            test2_1 = "4;0;-95;75;226;-120";
            test3_1 = "1;3;-14;-30;49;27;-36";
            test1_2 = "3";
            test2_2 = "3";
            test3_2 = "3";

        }

        // В данном случае не выношу переменные, так как важность понятности программы превышает 
        // затраты памяти, кроме того в С# работает автоматическая сборка мусора!

        public float[] DichotomyForPoly(float[] a, float nR){
            int     iter        = 0;
            float   rightBorder = Lab1_4.BorderUp(a,0,1);
            float   leftBorder  = Lab1_4.BorderDown(a, 0, 1);
            float   middle      = (rightBorder + leftBorder) / 2;
            float   nRoots      = 0;
            float[] Roots       = new float[(int)nR]; // Тип данных float необходим для повторного использования кода
            while (nRoots< nR) {
                if (iter > 100000) return (Roots); // Страхование на случай превышения n попыток найти значение
                if ((Lab1_1.Gorner(a, middle) < 0.001) && (Lab1_1.Gorner(a, middle) > -0.001)) {
                    Roots[(int)nRoots] = middle;
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
        //int iter = 0;
        //float rightBorder = Lab1_4.BorderUp(a, 0, 1);
        //float leftBorder = Lab1_4.BorderDown(a, 0, 1);
        //float middle = (rightBorder + leftBorder) / 2;
        //int nRoots = 0;
        //float[] Roots = new float[3];

        //    while ((nRoots<3)&&(Lab1_1.Gorner(a, middle) > 0.001)&&(Lab1_1.Gorner(a, middle) < -0.001)){
        //        if (iter > 100000) return (Roots); // Страхование на случай превышения n попыток найти значение
        //        if(!((Lab1_1.Gorner(a, middle) > 0.001) && (Lab1_1.Gorner(a, middle) < -0.001)))
        //        {
        //            Roots[nRoots] = middle;
        //            nRoots++;

        //        }
        //        if(Lab1_1.Gorner(a, leftBorder) * Lab1_1.Gorner(a, middle) < 0)
        //            rightBorder = middle;
        //        else
        //            leftBorder = middle;
        //        middle = (rightBorder + leftBorder) / 2;
        //        iter++;
        //    }


        //public float DichotomyForPoly(float[] a)
        //{
        //    int iter = 0;
        //    float rightBorder = Lab1_4.BorderUp(a, 0, 1);
        //    float leftBorder = Lab1_4.BorderDown(a, 0, 1);
        //    float middle = (rightBorder + leftBorder) / 2;

        //    while ((Lab1_1.Gorner(a, middle) > 0.001) || (Lab1_1.Gorner(a, middle) < -0.001))
        //    {
        //        if (iter > 100000) return (123456789); // Страхование на случай превышения n попыток найти значение

        //        if (Lab1_1.Gorner(a, leftBorder) * Lab1_1.Gorner(a, middle) < 0)
        //            rightBorder = middle;
        //        else
        //            leftBorder = middle;
        //        middle = (rightBorder + leftBorder) / 2;
        //        iter++;
        //    }

        //    return middle;
        //}


        // Результат конкретно этого пункта 
        float[] out1_1;

        // Перевод результата в выходные данные
        public override string OutData1() {
            out1_1 = DichotomyForPoly(inputData1, inputData2[0]);
            outData1 = "Найденные корни:" +
                       '[' + string.Join(" ", out1_1) + ']';

            return outData1;
        }
    }
}
