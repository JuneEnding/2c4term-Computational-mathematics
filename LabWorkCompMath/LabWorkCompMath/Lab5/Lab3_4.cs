using LabWorkCompMath.GeneralLab;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LabWorkCompMath.Lab2
{
    class Lab3_4 : Lab
    {

        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // Эти поля необходимы для быстрой отладки
        // Заполнив их 1 раз, можно сэкономить время на вводе данных
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public Lab3_4() : this(null) { }

        public Lab3_4(Button relatedButton) : base(relatedButton)
        {
            inputData1 = new List<float[]>();
            typeInput = 1;
            labelName = "4. Найти значение полинома от двух переменных в точке по схеме";
            labelDataName1 = "коэффициенты полинома:";
            labelDataName2 = "точка (x0, y0)";
            labelDataName3 = "степень приближения:";
            // Число данных
            numData = 2;
            // Число тестов
            numTests = 3;
            // Эти данные будут вводиться во входную строку, имитируя ручной ввод
            // Номер теста_номер входной строки
            test1_1 = "8;0;3;8 1;7;1;4";
            test2_1 = "-3;2;3 2;-1;-4 2;2;4 1;-4;4";
            test3_1 = "3,2;4,5 2,3;-4,5";

            test1_2 = "-1;2";
            test2_2 = "1;-3";
            test3_2 = "2;1";

            test1_3 = "10";
            test2_3 = "10";
            test3_3 = "10";
        }

        public static float Gorner2(List<float[]> a, float[] a0){
            float[] b;
            b = new float[a.Count];
            for (int i = 0; i < a.Count; i++)
                b[i] = Lab1_1.Gorner(a[i], a0[0]);
            return Lab1_1.Gorner(b, a0[1]);
        }

        new List<float[]> inputData1;
        float out1_1;
        Polynomial poly1;
        LabArray array1;


        // Перевод результата в выходные данные
        public override string OutData1()
        {
            poly1 = new Polynomial();
            array1 = new LabArray(inSData1);
            outData1 = $"Введены коэффициенты: \n";
            outData1 += array1.strMatForm;
            out1_1 = Gorner2(array1.arrForm, InputData2(inSData2));
            outData1 = outData1 + "\nПолином:\n" + 
                                $"f( x, y ) = " + array1.viewForm +
                                $"\n\nЗначение полинома в точке ({inSData2}):\t" + out1_1 + " \n";
            if (array1.arrForm == null)
                outData1 += "\nОшибка: многочлен задан некорректно!";
            outData1FormPosDeeg = array1.FindDegPos(outData1, array1.degreesPositions.Length);
            outData1FormLenDeeg = array1.lengthOfDegrees;
            return outData1;
        }

    }
}
