using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace LabWorkCompMath
{
    class Lab1_4 : Lab {

        public Lab1_4() {
            labelName = "4. Найти границы корней полинома";
            labelDataName1 = "коэффициенты полинома:";
            labelDataName2 = "точка отсчета:";
            labelDataName3 = "шаг:";
            // Число данных
            numData = 3;
            // Число тестов
            numTests = 4;
            // Номер теста_номер входной строки
            test1_1 = "1;0;-12;-16;0";
            test2_1 = "2;-13;1;103;-183;90";
            test3_1 = "-2;-13;-13;28";
            test4_1 = "0;0;5;-16;-45;0";
            test1_2 = "0";
            test2_2 = "0";
            test3_2 = "0";
            test4_2 = "0";
            test1_3 = "1";
            test2_3 = "1";
            test3_3 = "1";
            test4_3 = "1";
        }
        // Все коэф. д.б >=0, 0 - меньше или равно
        // Переменные, кнечно, можно и вынести, но понятность существеннее,
        // чем затраты памяти
        public static float BorderUp(float[] a, float startPoint, float step) {
            float border = startPoint;
            int iter = 0;
            float[] b;
        Start:
            if (a[0] < 0) { iter++; goto Start; }; // !!! В алгоритме a[0] д.б. строго > 0, здесь ослабление, т.к. иначе невозможно получить 
            if (iter > 100) return (startPoint - step); // Страхование на случай превышения n попыток найти значение
            border += step;
                                                   // Тестовое значение

            b = Lab1_2.GornerDiv(a,border);
            for (int i = 1; i < b.Length; i++) {
                if (b[i] < 0) { iter++; goto Start;  };
            }
            return border;
        }

        public static float BorderDown(float[] a, float startPoint, float step) {
            for (int i = 0; i < a.Length; i++)
                a[i] = (-1*(a[i]))* ((float)Math.Pow(-1, (a.Length - i - 1)));
            return -BorderUp(a,  startPoint, step);
        }
        //a.Length-i-1
        //i-1

        // Результат конкретно этого пункта
        float out1_1;
        float out1_2;

        // Перевод результата в выходные данные
        public override string OutData1()
        {
            //algorithm(inputData1, inputData2, inputData3);
            out1_1 = BorderUp(inputData1, inputData2[0], inputData3[0]);
            out1_2 = BorderDown(inputData1, inputData2[0], inputData3[0]);
            outData1 = "Нижняя граница: " + out1_1.ToString() + "\n" 
                     + "Верхняя граница: " + out1_2.ToString() + "\n"
                     + "\n" + "Значение границы, по знаку отличное от ожидаемого, означает отсутствие возможности вычислить ее данным способом" + "\n"
                     + "!!! При проверке тестовых значений вручную выяснилась невозможность получения некоторых тестовых значений";
            return outData1;
        }
    }
}
