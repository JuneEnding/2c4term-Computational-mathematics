using LabWorkCompMath.GeneralLab;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace LabWorkCompMath.Lab2
{
    class Lab4_4 : Lab
    {

        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // Эти поля необходимы для быстрой отладки
        // Заполнив их 1 раз, можно сэкономить время на вводе данных
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public Lab4_4() : this(null) { }

        public Lab4_4(Button relatedButton) : base(relatedButton)
        {
            inputData1 = new List<float[]>();
            typeInput = 1;
            labelName = "4. Реализовать деление полинома на полином произвольной степени";
            labelDataName1 = "коэффициенты полинома делимого:";
            labelDataName2 = "коэффициенты полинома делителя:";
            labelDataName3 = "степень приближения:";
            // Число данных
            numData = 2;
            // Число тестов
            numTests = 3;
            // Эти данные будут вводиться во входную строку, имитируя ручной ввод
            // Номер теста_номер входной строки
            test1_1 = "-1;-2;-2;-5;0;-3;-4;2;-5;0";
            test2_1 = "1;4;1;-14;-20;-8";
            test3_1 = "1;0;0;-1";

            test1_2 = "1;4;1;-14;-20;-8";
            test2_2 = "1;3";
            test3_2 = "1;1;1";

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

        public static List<float[]> PolynomialDivide(float[] a, float[] b) {
        List<float[]> tem;//!!!!!!!!!!!!! 
            float[] p = new float[a.Length - b.Length + 1];
            float[] r = new float[b.Length - 1];
            int l = (a.Length + b.Length - 1);
            float[,] res = new float[b.Length + 1, l];
            
            for (int i = 0; i < a.Length; i++)
                res[0, b.Length - 1 + i] = a[i];
            for (int i = 0; i < b.Length - 1; i++)
                res[b.Length - i - 1, i] = -b[i + 1];
            
            res[res.GetLength(0) - 1, b.Length - 1] = a[0] / b[0];

            for (int i = 0; i < a.Length - b.Length + 1; i++) {
                for (int j = 0; j < b.Length - 1; j++) 
                    res[b.Length - j - 1, j + b.Length + i] += res[res.GetLength(0) - 1, b.Length - 1 + i] * res[b.Length - j - 1, j];
                for (int j = 0; j < b.Length; j++)
                    res[res.GetLength(0) - 1, b.Length + i] += res[j, b.Length + i];
                if (b.Length + i < a.Length)
                    res[res.GetLength(0) - 1, b.Length + i] = res[res.GetLength(0) - 1, b.Length + i] / b[0];
            }

            for (int j = 0; j < b.Length - 2; j++)
                for (int i = 0; i < res.GetLength(0) - 1; i++)
                    res[res.GetLength(0) - 1, res.GetLength(1) - 1 - j] += res[i, res.GetLength(1) - 1 - j];

            for (int i = 0; i < p.Length; i++) 
                p[i] = res[res.GetLength(0) - 1, b.Length + i - 1];

            for (int i = 0; i < r.Length; i++) 
                r[i] = res[res.GetLength(0) - 1, b.Length + i - 1 + p.Length];
            bool f = false;

            for (int i = 0; i < r.Length; i++) 
                if (r[i] != 0) {
                    f = true;
                    break;
                }
            tem = new List<float[]>();
            tem.Add(p);
            if ((r.Length == 0)||(AllZero(r)==true)) {
                tem.Add(new float[1]);
                tem[1][0] = 0;
            }
                else
                tem.Add(r);
            return tem;
        }

        public static bool AllZero(float[] r) {
            for (int i = 0; i < r.Length; i++)
                if (r[i] != 0)
                    return false;
            return true; 
        }

        new List<float[]> inputData1;
        List<float[]> out1_1;
        Polynomial poly1;
        Polynomial polyPrev;
        Polynomial polyRem;
        LabArray array1;
        LabArray arrayX;
        LabArray arrayY;

        // Перевод результата в выходные данные
        public override string OutData1()
        {
            poly1 = new Polynomial();
            arrayX = new LabArray(inSData1);
            arrayY = new LabArray(inSData2);
            // arrayY = new LabArray(inSData1);
            outData1 = $"Полином-делимое: \nf = ";
            outData1 += arrayX.viewForm;
            outData1 += $"\nПолином-делитель: \ng = ";
            outData1 += arrayY.viewForm;
            out1_1 = PolynomialDivide(arrayX.arrForm[0], arrayY.arrForm[0]);
            polyPrev = new Polynomial(out1_1[0]);
            
            polyRem = new Polynomial(out1_1[1]);
            outData1 = outData1 +  $"\n\nЧастное: " + polyPrev.strForm +
                                   $"\n\nОстаток: " + polyRem.strForm + " \n";
            //if (array1.arrForm == null)
            //    outData1 += "\nОшибка: многочлен задан некорректно!";
            outData1FormPosDeeg = arrayX.FindDegPos(outData1, arrayY.degreesPositions.Length + arrayX.degreesPositions.Length + polyPrev.degreesPositions.Length+ polyRem.degreesPositions.Length);
            arrayX.lengthOfDegrees = CutNull(arrayX.lengthOfDegrees);
            arrayY.lengthOfDegrees = CutNull(arrayX.lengthOfDegrees);
            polyPrev.lengthOfDegrees = CutNull(polyPrev.lengthOfDegrees);
            polyRem.lengthOfDegrees = CutNull(polyRem.lengthOfDegrees);
            outData1FormLenDeeg = arrayX.lengthOfDegrees.Concat(arrayY.lengthOfDegrees.Concat(polyPrev.lengthOfDegrees.Concat(polyRem.lengthOfDegrees))).ToArray();

            return outData1;
        }

    }
}


//outData1FormPosDeeg = arrayX.FindDegPos(outData1, arrayY.degreesPositions.Length + arrayX.degreesPositions.Length + polyPrev.degreesPositions.Length+ polyRem.degreesPositions.Length);
//            arrayX.lengthOfDegrees = CutNull(arrayX.lengthOfDegrees);
//arrayY.lengthOfDegrees = CutNull(arrayX.lengthOfDegrees);
//outData1FormLenDeeg = arrayX.lengthOfDegrees.Concat(arrayY.lengthOfDegrees).ToArray();