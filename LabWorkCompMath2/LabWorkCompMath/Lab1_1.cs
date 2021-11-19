using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWorkCompMath{
    public class Lab1_1:Lab {
        
        public Lab1_1()
        {
            labelName   = "1. Найти значение полинома в точке по схеме Горнера";
            labelDataName1 = "коэффициенты полинома:";
            labelDataName2 = "искать значение в точке:";
            // Число данных
            numData = 2;
            // Число тестов
            numTests    = 3;
            test1_1     = "-5;-1;3;-2;5";
            test2_1     = "-3;-2;0;-2;1";
            test3_1     = "-0,9;2,1;3,7;-2,4;0,8";
            test1_2     = "-1";
            test2_2     = "1,3";
            test3_2     = "3";
        }

        public static float Gorner(float[] a, float a0) {
            float[] b;
            int k;
            k = a.Length - 1;
            b = new float[k + 1];
            b[0] = a[0];
            for (int i = 1; i < a.Length; i++)
                b[i] = a[i] + b[i - 1] * a0;
            float rez = b[k];
            return (b[k]);
        }
        // Результат конкретно этого пункта
        float out1_1;

        // Перевод результата в выходные данные
        public override string OutData1()
        {
            //algorithm(inputData1, inputData2, inputData3);
            out1_1 = Gorner(inputData1, inputData2[0]);
            outData1 = out1_1.ToString();
            return outData1;
        }
    }
}
