using LabWorkCompMath.GeneralLab;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace LabWorkCompMath.Lab2
{
    class Lab5_5 : Lab
    {

        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // Эти поля необходимы для быстрой отладки
        // Заполнив их 1 раз, можно сэкономить время на вводе данных
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public Lab5_5() : this(null) { }

        public Lab5_5(Button relatedButton) : base(relatedButton)
        {
            inputData1 = new List<float[]>();
            typeInput = 1;
            labelName = "5. Найти частные производные полинома от двух переменных";
            labelDataName1 = "коэффициенты полинома:";
            labelDataName2 = "точка (x0, y0)";
            labelDataName3 = "степень приближения:";
            // Число данных
            numData = 1;
            // Число тестов
            numTests = 3;
            // Эти данные будут вводиться во входную строку, имитируя ручной ввод
            // Номер теста_номер входной строки
            test1_1 = "-1;4;3 1;3;-4 -4;1;-3";
            test2_1 = "4;3;0;-3 1;1;3;-4";
            test3_1 = "3;-4 0;-1 -2;-4";

            test1_2 = "-1;2";
            test2_2 = "1;-3";
            test3_2 = "2;1";

            test1_3 = "10";
            test2_3 = "10";
            test3_3 = "10";
        }

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

        new List<float[]> inputData1;
        float out1_1;
        Polynomial poly1;
        LabArray array1;
        LabArray arrayX;
        LabArray arrayY;



        // Перевод результата в выходные данные
        public override string OutData1()
        {
            poly1 = new Polynomial();
            array1 = new LabArray(inSData1);
            arrayX = new LabArray(DerivativeX(array1.arrForm));
            arrayY = new LabArray(DerivativeY(array1.arrForm));
           // arrayY = new LabArray(inSData1);
            outData1 = $"Введены коэффициенты: \n";
            outData1 += array1.strMatForm;
            //out1_1 = Gorner2(array1.arrForm, InputData2(inSData2));
            outData1 = outData1 + "Полином:\n" +
                                $"f( x, y ) = " + array1.viewForm +
                                $"\n\ndf(x,y)/dx = " + arrayX.viewForm +
                                $"\n\ndf(x,y)/dy = " + arrayY.viewForm + " \n";
            if (array1.arrForm == null)
                outData1 += "\nОшибка: многочлен задан некорректно!";
            outData1FormPosDeeg = array1.FindDegPos(outData1, array1.degreesPositions.Length + arrayX.degreesPositions.Length);
            array1.lengthOfDegrees = CutNull(array1.lengthOfDegrees);
            arrayX.lengthOfDegrees = CutNull(arrayX.lengthOfDegrees);
            arrayY.lengthOfDegrees = CutNull(arrayX.lengthOfDegrees);
            outData1FormLenDeeg = array1.lengthOfDegrees.Concat(arrayX.lengthOfDegrees.Concat(arrayY.lengthOfDegrees)).ToArray();
            return outData1;
        }

    }
}
