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
    class Lab3_2 : Lab
    {

        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // Эти поля необходимы для быстрой отладки
        // Заполнив их 1 раз, можно сэкономить время на вводе данных
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public Lab3_2() : this(null) { }

        public Lab3_2(Button relatedButton) : base(relatedButton)
        {
            inputData1 = new List<float[]>();
            typeInput = 1;
            labelName = "2. Нахождение обратной матрицы через окаймляющие блоки";
            labelDataName1 = "матрица:";
            labelDataName2 = " ";
            labelDataName3 = " ";
            // Число данных
            numData = 1;
            // Число тестов
            numTests = 4;
            // Эти данные будут вводиться во входную строку, имитируя ручной ввод
            // Номер теста_номер входной строки
            test1_1 = "1;-2 3;-2";
            test2_1 = "1;0;0 0;1;0 0;0;1";
            test3_1 = "1;6;-4 -8;6;7 -7;0;8";
            test4_1 = "1;2;3 4;5;6 7;8;9";

            //test1_1 = "2;0 1;0";
            //test2_1 = "0;1 1;0";
            //test3_1 = "0;-1;2 1;0;3 4;-3;-2";
            //test4_1 = "7;7;3 -2;-4;1 2;7;-7";

            test1_2 = "1;-3 4;-2";
            test2_2 = "0;1 1;0";
            test3_2 = "1;0;0 0;1;0 0;0;1";
            test4_2 = "2;-8;-4 -4;2;1 -5;-6;-1";

            test1_3 = "-1;1";
            test2_3 = "-1;1";
            test3_3 = "-1;1";
            test4_3 = "-1;1";

            a1 = new List<float[]>();
            a2 = new List<float[]>();
            a3 = new List<float[]>();
            a4 = new List<float[]>();

            ch = new bool();
        }

        //-------------------------------------------------
        List<float[]> dn;
        public float Det(List<float[]> a, float det = 1)
        {
            if ((a == null) || (a.Count <= 0)) return 0;
            if (a.Count != a[0].Length) { error = "Матрица не квадратная!"; return 0; }
            if (a.Count == 1)
                return det * a[0][0];
            dn = new List<float[]>();
            if (a[0][0] == 0)
            {
                k = 1;
                while (a[0][k] == 0) { k++; if (a.Count - 1 < k) return 0; }
                if (a[0].Length < k) return 0;
                //if ((k % 2) != 0) 
                det *= -1;
                ChLin(a, 0, k);
            }
            det *= a[0][0];
            for (int i = 0; i < a.Count - 1; i++)
            {
                dn.Add(new float[a[0].Length - 1]);
                for (int j = 0; j < dn[0].Length; j++)
                {
                    dn[i][j] = a[i + 1][j + 1] - a[i + 1][0] * a[0][j + 1] / a[0][0];
                }
            }
            return Det(dn, det);
        }

        List<float[]> b;
        int k;
        float tem2;
        public List<float[]> ChLin(List<float[]> a, int l1, int l2)
        {
            b = new List<float[]>();
            if ((a == null) || (a.Count <= 1)) return a;
            b = a;
            for (int i = 0; i < a.Count; i++)
            {
                tem2 = a[i][l2];
                b[i][l2] = a[i][l1];
                b[i][l1] = tem2;
            }
            return b;
        }
        //-------------------------------------------------
        // Проверка на размерность - ответственность пользователя!
        public List<float[]> SumMat(List<float[]> a, List<float[]> b)  {
            List<float[]> tem = new List<float[]>(a.Count);
            //float[] line = new float[a[0].Length];
            for (int i = 0; i < a.Count; i++) {
                tem.Add(new float[a[0].Length]);
                for (int j = 0; j < a[0].Length; j++)
                    tem[i][j] = a[i][j] + b[i][j]; 
            }
            return tem;
        }
        public List<float[]> DifMat(List<float[]> a, List<float[]> b)
        {
            List<float[]> tem = new List<float[]>(a.Count);
            //float[] line = new float[a[0].Length];
            for (int i = 0; i < a.Count; i++) {
                tem.Add(new float[a[0].Length]);
                for (int j = 0; j < a[0].Length; j++)
                    tem[i][j] = a[i][j] - b[i][j];
            }
            return tem;
        }
        public List<float[]> MultMatr(List<float[]> a, List<float[]> b) {
            List<float[]> tem = new List<float[]>(a.Count);
            //float[] line = new float[a[0].Length];
            for (int i = 0; i < a.Count; i++) {
                tem.Add(new float[b[0].Length]);
                for (int j = 0; j < b[0].Length; j++)
                    for (int k = 0; k < a[0].Length; k++)
                    {
                        if (k > b.Count - 1) return tem;
                        tem[i][j] += a[i][k] * b[k][j];
                    }
            }
            return tem;
        }
        public List<float[]> NegMatr(List<float[]> a) {
            List<float[]> tem = new List<float[]>(a.Count);
            for (int i = 0; i < a.Count; i++) {
                tem.Add(new float[a[0].Length]);
                for (int j = 0; j < a[0].Length; j++)
                    tem[i][j] = -1*a[i][j];
            }
            return tem;
        }

        List<float[]> tem;
        List<float[]> a1;
        List<float[]> a2;
        List<float[]> a3;
        List<float[]> a4;
        List<float[]> x;
        List<float[]> y;
        List<float[]> th;
        float det;
        public List<float[]> RevMat(List<float[]> a){
            error = "";
            if ((a == null) || (a.Count < 1)) return a;
            if (a.Count != a[0].Length) { error = "Матрица не квадратная!"; return a; }
            if (Det(a)==0) { error = "Матрица необратима!"; return null; }
            a1 = new List<float[]>();
            det = new float();
            if (a.Count == 1)
            {
                a1.Add(new float[1]);
                a1[0][0] = 1/a[0][0];
                return a1;
            }
            if (a.Count == 2) {
                det = Det2(a);
                a1.Add(new float[2]);
                a1.Add(new float[2]);
                a1[0][0] = a[1][1]/det;
                a1[0][1] = -a[0][1] / det;
                a1[1][0] = -a[1][0] / det;
                a1[1][1] = a[0][0] / det;
                return a1;
            }
            
            for(int i =0; i < a.Count - 1; i++) {
                a1.Add(new float[a.Count-1]);
                for (int j = 0; j < a[0].Length - 1; j++)
                    a1[i][j] = a[i][j];
            }
            if (Det(a1)==0) { error = "Метод неприменим, один из миноров особенный!"; return null; }
            a1 = RevMat(a1);
            a2 = new List<float[]>();
            a3 = new List<float[]>();
            a4 = new List<float[]>();
            x = new List<float[]>();
            y = new List<float[]>();
            th = new List<float[]>();

            for (int i = 0; i < a.Count - 1; i++) {
                a2.Add(new float[1]);
                a2[i][0] = a[i][a[0].Length - 1];
            }

            a3.Add(new float[a.Count - 1]);
            for (int i=0; i< a.Count-1;i++) {
                a3[0][i] = a[a.Count - 1][i];
            }

            a4.Add(new float[1]);
            a4[0][0] = a[a.Count - 1][a[0].Length - 1];
            //
            x = MultMatr(a1,a2);
            y = MultMatr(a3,a1);
            th = DifMat(a4, MultMatr(a3,x));
            th[0][0] = 1/th[0][0];
            //th.Add(new float[1]);
            //th[0][0] = 1 / a[a.Count - 1][a[0].Length - 1];
            //
            a1 =SumMat(a1,MultMatr(MultMatr(x,th),y));
            a2 = NegMatr(MultMatr(x,th));
            a3 = NegMatr(MultMatr(th,y));
            a4 = th;

            // Сборка
            tem = new List<float[]>(a.Count);
            for (int i = 0; i < a1.Count; i++) {
                tem.Add(new float[a.Count]);
                tem[i] = a1[i].Concat(a2[i]).ToArray();
            }
            for (int i = a1.Count; i < a1.Count + a3.Count; i++) {
                tem.Add(new float[a.Count]);
                tem[i] = a3[i - a1.Count].Concat(a4[i - a1.Count]).ToArray();
            }
            return tem;
        }

        public float Det2(List<float[]> a) {
            error = "";
            if ((a == null) || (a.Count <= 0) || (a.Count > 2)) return 0;
            if (a.Count != a[0].Length) { error = "Матрица не квадратная!"; return 0; }
            if (a.Count == 1) return a[0][0];
            return a[0][0] * a[1][1] - a[0][1] * a[1][0];
        }


        public bool CheckRevM(List<float[]> a, List<float[]> b, float ex = 0.001f)
        {
            if ((a == null) || (b == null) || (a.Count <= 0) || (a.Count != b.Count) || (a[0].Length != b[0].Length))
                return false;
            tem = new List<float[]>(a.Count);
            tem = MultMatr(a, b);
            for(int i = 0; i < tem.Count; i++) {
                for (int j = 0; j < tem.Count; j++) {
                    if (i != j)
                        if ((tem[i][j] > ex) || (tem[i][j] < -ex)) return false;
                    if (i == j)
                        if ((tem[i][j] - 1 > ex) || (tem[i][j] - 1 < -ex)) return false;
                }
            }
            return true;
        }

        new List<float[]> inputData1;
        LabArray out1_1;
        Polynomial poly1;
        LabArray arr1;
        bool ch;
        LabArray e;
        // Перевод результата в выходные данные
        public override string OutData1() {
            InputData();
            outData1 = $"Введена матрица:\n{arr1.strMatForm} ";
            out1_1 = new LabArray(RevMat(arr1.arrForm));
            outData1 += "\nОбратная матрица:\n" + out1_1.strMatForm ;
            //out1_1 = new LabArray(RevMat(arrA.arrForm));
            //outData1 = outData1 + $"\nНайденное произведение:\n{out1_1.strMatForm}";
            outData1 += "\n" + error + "\n";
            if (arr1.arrForm == null)
                outData1 += "\nОШИБКА: массив задан некорректно!";

            ch = CheckRevM(arr1.arrForm,out1_1.arrForm);
            outData1 += "\nПроверка обратной матрицы с точностью 0,001:\n ";
            if (ch == true)
            {
                e = new LabArray( MultMatr(arr1.arrForm, out1_1.arrForm));
                outData1 += "Найденная матрица действительно обратна\nA*A^(-1)=\n" + e.strMatForm;
            }
            if (ch == false)
            {
                outData1 += "Проверка не пройдена.\n";
            }

            //outData1FormPosDeeg = array1.FindDegPos(outData1, array1.degreesPositions.Length);
            //outData1FormLenDeeg = array1.lengthOfDegrees;
            return outData1;
        }
        public void InputData() {
            inputData3 = InputData3(inSData3);
            poly1 = new Polynomial();
            arr1 = new LabArray(inSData1);
            ch = new bool();
        }

    }
}
