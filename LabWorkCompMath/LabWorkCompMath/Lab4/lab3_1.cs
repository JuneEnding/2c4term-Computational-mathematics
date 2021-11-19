using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabWorkCompMath.GeneralLab;
using System.Windows.Forms;

namespace LabWorkCompMath.Lab2
{

    class Lab3_1 : Lab
    {

        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // Эти поля необходимы для быстрой отладки
        // Заполнив их 1 раз, можно сэкономить время на вводе данных
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public Lab3_1() : this(null) { }

        public Lab3_1(Button relatedButton) : base(relatedButton)
        {
            inputData1 = new List<float[]>();
            typeInput = 1;
            labelName = "1. Умножение квадратных матриц разложением на блоки";
            labelDataName1 = "левая матрица:";
            labelDataName2 = "правая матрица:";
            labelDataName3 = "грубый корень:";
            // Число данных
            numData = 2;
            // Число тестов
            numTests = 4;
            // Эти данные будут вводиться во входную строку, имитируя ручной ввод
            // Номер теста_номер входной строки
            test1_1 = "2;0 1;0";
            test2_1 = "0;1 1;0";
            test3_1 = "0;-1;2 1;0;3 4;-3;-2";
            test4_1 = "7;7;3 -2;-4;1 2;7;-7";

            test1_2 = "1;-3 4;-2";
            test2_2 = "0;1 1;0";
            test3_2 = "1;0;0 0;1;0 0;0;1";
            test4_2 = "2;-8;-4 -4;2;1 -5;-6;-1";

            test1_3 = "-1;1";
            test2_3 = "-1;1";
            test3_3 = "-1;1";
            test4_3 = "-1;1";
        }


        float[] x0;
        int iter;


        List<float[]> m;
        List<float[]> ma;
        List<float[]> mb;
        List<float[]> mc;
        List<float[]> md;
        List<float[]> ma2;
        List<float[]> mb2;
        List<float[]> mc2;
        List<float[]> md2;
        int c;
        int l;
        // ГЛАВНЫЙ АЛГОРИТМ
        public List<float[]>  BreakMat2(List<float[]> a, List<float[]> b)
        {
            if ((a == null)||(b == null)) return a;
            c = a.Count / 2;
            l = a[0].Length / 2;
            //if ((c<=1)||(l<=1)) return MultMatr(a, b);
            if ((c<=2)&&(l<=2)) return MultMatr(a, b);
            ma = new List<float[]>(c);
            mb = new List<float[]>(c);
            mc = new List<float[]>(a.Count - c);
            md = new List<float[]>(a.Count - c);
            ma2 = new List<float[]>(c);
            mb2 = new List<float[]>(c);
            mc2 = new List<float[]>(a.Count - c);
            md2 = new List<float[]>(a.Count - c);
            for (int i = 0; i < c; i++) {
                Array.Copy(a[i], 0, ma[i], 0, l);
                Array.Copy(a[i], 0, ma2[i], 0, l);
                if ((ma.Count>2)||(ma[0].Length>2)) 
                    ma = BreakMat2(ma, ma2);
            }
            for (int i = 0; i < c; i++) {
                Array.Copy(a[i], l, mb[i], 0, a[i].Length);
                Array.Copy(a[i], l, mb2[i], 0, a[i].Length);
                if ((mb.Count > 2) || (mb[0].Length > 2))
                    mb = BreakMat2(mb, mb2);
            }
            for (int i = c; i < a.Count; i++) {
                Array.Copy(a[i], 0, mc[i], 0, l);
                Array.Copy(a[i], 0, mc2[i], 0, l);
                if ((mc.Count > 2) || (mc[0].Length > 2))
                    mc = BreakMat2(mc,mc2);
            }
            for (int i = c; i < a.Count; i++) {
                Array.Copy(a[i], l, md[i], 0, a[i].Length);
                Array.Copy(a[i], l, md2[i], 0, a[i].Length);
                if ((md.Count > 2) || (md[0].Length > 2))
                    md = BreakMat2(md,md2);
            }
            //!!! m = BreakMat2(ma);
            return MultBl4Matr(ma, mb, mc, md, ma2, mb2, mc2, md2);
        }

        List<float[]> mA;
        List<float[]> mB;
        List<float[]> mC;
        List<float[]> mD;
        public List<float[]> MultBl4Matr(List<float[]> a, List<float[]> b, List<float[]> c, List<float[]> d, List<float[]> a2, List<float[]> b2, List<float[]> c2, List<float[]> d2){
            m = new List<float[]>(a.Count+c.Count);// Размер произведения м-ц
            mA = SumMat(MultMatr(a,a2),MultMatr(b, c2));
            mB = SumMat(MultMatr(a,b2),MultMatr(b, d2));
            mC = SumMat(MultMatr(c,a2),MultMatr(d, c2));
            mD = SumMat(MultMatr(c,b2),MultMatr(d, d2));
            for (int i = 1; i <mA.Count; i++)
                m[i] = mA[i].Union(mB[i]).ToArray();
            for (int i = m.Count; i < m.Count + mC.Count; i++)
                m[i] = mC[i - m.Count].Union(mD[i - m.Count]).ToArray();
            
            return m;
        }

        public List<float[]> SumMat(List<float[]> a, List<float[]> b) {
            List<float[]> tem = new List<float[]>(a.Count);
            float[] line = new float[a[0].Length];
            for (int i = 0; i < a.Count; i++) 
                for (int j = 0; j < a[0].Length; j++) {
                   tem[i][j] = a[i][j]+ b[i][j];
                }
            return tem;
        }
        public List<float[]> MultMatr(List<float[]> a, List<float[]> b) {
            List<float[]> tem = new List<float[]>(a.Count);
            float[] line = new float[a[0].Length];
            for (int i = 0; i< a.Count; i++) {
                tem.Add(new float[a[0].Length]);
                for (int j = 0; j < a[0].Length; j++) 
                    for (int k = 0; k < a[0].Length; k++)
                        tem[i][j] += a[i][k] * b[k][j];
            }
            return tem;
        }

        new List<float[]> inputData1;
        LabArray out1_1;
        Polynomial poly1;
        LabArray arrA;
        LabArray arrB;


        // Перевод результата в выходные данные
        public override string OutData1()
        {
            InputData();
            outData1 = $"Введено: \n";
            outData1 += $"Левая матрица:\n{arrA.strMatForm} \nПравая матрица:\n{arrB.strMatForm}";
            //out1_1 = NewtonI2(array1.arrForm, InputData2(inSData2));
            out1_1 = new LabArray(BreakMat2(arrA.arrForm, arrB.arrForm)); 
            outData1 = outData1 + $"\nНайденное произведение:\n{out1_1.strMatForm}";

            outData1 += "\n" + error + "\n";
            if ((arrA.arrForm == null) || (arrB.arrForm == null))
                outData1 += "\nОШИБКА: массив задан некорректно!";
            //outData1FormPosDeeg = array1.FindDegPos(outData1, array1.degreesPositions.Length);
            //outData1FormLenDeeg = array1.lengthOfDegrees;
            return outData1;
        }
        public void InputData()
        {
            inputData3 = InputData3(inSData3);
            poly1 = new Polynomial();
            arrA = new LabArray(inSData1);
            arrB = new LabArray(inSData2);

        }

    }
}
