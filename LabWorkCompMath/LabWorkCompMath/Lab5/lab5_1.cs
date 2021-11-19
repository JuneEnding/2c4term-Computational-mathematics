using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabWorkCompMath.GeneralLab;
using System.Windows.Forms;

namespace LabWorkCompMath.Lab2
{

    class Lab5_1 : Lab { 
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // Эти поля необходимы для быстрой отладки
        // Заполнив их 1 раз, можно сэкономить время на вводе данных
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public Lab5_1() : this(null) { }

        public Lab5_1(Button relatedButton) : base(relatedButton)
        {
            inputData1 = new List<float[]>();
            typeInput = 1;
            labelName = "1. Нахождение характеристического  полинома  произвольной квадратной матрицыпо методу Лаверрье";
            labelDataName1 = "матрица:";
            labelDataName2 = "правая матрица:";
            labelDataName3 = "грубый корень:";
            
            // Число данных
            numData = 1;
            // Число тестов
            numTests = 4;
            // Эти данные будут вводиться во входную строку, имитируя ручной ввод
            // Номер теста_номер входной строки
            test1_1 = "5;4 3;-2";
            test2_1 = "4;-4;0 3;1;3 1;2;-3";
            test3_1 = "3;4;-1;-1 -1;-3;1;-1 -2;-4;4;2 -1;0;-5;0";
            test4_1 = "-6,5;7,8;8,1 1,6;2,4;-9,1 -8,1;3,1;-1";

            test1_2 = "1;-3 4;-2";
            test2_2 = "0;1 1;0";
            test3_2 = "1;0;0 0;1;0 0;0;1";
            test4_2 = "2;-8;-4 -4;2;1 -5;-6;-1";

            test1_3 = "-1;1";
            test2_3 = "-1;1";
            test3_3 = "-1;1";
            test4_3 = "-1;1";
            //--------------
        }

        float[] sp;
        float[] p;
        List<float[]> an;
        public float[] Leverrier(List<float[]> a) {
            sp = new float[a.Count];
            p = new float[a.Count+1];
            an = new List<float[]>(a);
            sp[0] = Sp(a);
            for (int i = 1; i< a.Count-1;i++) {
                an = MultMatr(an, a);
                sp[i] = Sp(an);
            }

            // Экономим время на вычислении!

            for (int i = 0; i < a.Count; i++) {
                    for (int k = 0; k < a[0].Length; k++)
                        sp[a.Count - 1] += an[i][k] * a[k][i];
            }

            p[0] = 1;
            for (int i = 0; i<a.Count; i++)
            {
                p[i+1] = sp[i];
                for(int k=1; k < i + 1; k++)
                {
                    p[i+1] += p[k] * sp[i-k];
                }
                p[i+1] *= (float)-1 / (i+1);
            }

            return p;
        }

        float s;
        public float Sp(List<float[]> a) {
            if ((a == null) || (a.Count <= 0) || (a.Count != a[0].Length))
                return 0;
            s = 0;
            for (int i = 0; i<a.Count; i++)
                s += a[i][i];
            return s;
        }

        public List<float[]> MultMatr(List<float[]> a, List<float[]> b)
        {
            List<float[]> tem = new List<float[]>(a.Count);
            float[] line = new float[a[0].Length];
            for (int i = 0; i < a.Count; i++)
            {
                tem.Add(new float[a[0].Length]);
                for (int j = 0; j < a[0].Length; j++)
                    for (int k = 0; k < a[0].Length; k++)
                        tem[i][j] += a[i][k] * b[k][j];
            }
            return tem;
        }

        char[] charStr;
        public string XToLambda(string s)
        {
            charStr = s.ToCharArray();
            for(int i = 0; i < charStr.Length; i++)
            {
                if (charStr[i] == 'x')
                    charStr[i] = 'λ';
            }
            return new string(charStr);
        }

        new List<float[]> inputData1;
        LabArray out1_1;
        Polynomial poly1;
        LabArray arr1;

        // Перевод результата в выходные данные
        public override string OutData1() {
            InputData();
            outData1 = $"Введена матрица A:\n{arr1.strMatForm} \n";
            poly1 = new Polynomial(Leverrier(arr1.arrForm));

            poly1.strForm = XToLambda(poly1.strForm);
            outData1 += "Характеристический полином матрицы:\n |A| = "+ poly1.strForm;

            outData1 += "\n" + error + "\n";
            if (arr1.arrForm == null) 
                outData1 += "\nОШИБКА: массив задан некорректно!";
            outData1FormPosDeeg = poly1.FindDegPos(outData1, poly1.degreesPositions.Length);
            outData1FormLenDeeg = poly1.lengthOfDegrees;
            return outData1;
        }
        public void InputData()
        {
            inputData3 = InputData3(inSData3);
            poly1 = new Polynomial();
            arr1 = new LabArray(inSData1);
        }

    }
}
