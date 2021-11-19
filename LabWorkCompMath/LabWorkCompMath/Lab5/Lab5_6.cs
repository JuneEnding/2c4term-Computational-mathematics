using System.Collections.Generic;
using LabWorkCompMath.GeneralLab;
using System.Windows.Forms;

namespace LabWorkCompMath.Lab2 {
    class Lab5_6 : Lab {

        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // Эти поля необходимы для быстрой отладки
        // Заполнив их 1 раз, можно сэкономить время на вводе данных
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public Lab5_6() : this(null) { }

        public Lab5_6(Button relatedButton) : base(relatedButton) {
            inputData1 = new List<float[]>();
            typeInput = 1;
            labelName = "6. Найти комплексный корень уравнения методом Ньютона для систем уравнений с двумя неизвестными";
            labelDataName1 = "действительная матрица:";
            labelDataName2 = "комплексная матрица:";
            labelDataName3 = "грубый корень:";
            // Число данных
            numData = 3;
            // Число тестов
            numTests = 3;
            // Эти данные будут вводиться во входную строку, имитируя ручной ввод
            // Номер теста_номер входной строки
            test1_1 = "0;0;-2 0;0;0 2;2;3";
            test2_1 = "0;0;-5 0;0;0 5;7;10";
            test3_1 = "0;0;-2 0;0;0 2;3;7";

            test1_2 = "0;0;0 0;4;2 0;0;0";
            test2_2 = "0;0;0 0;10;7 0;0;0";
            test3_2 = "0;0;0 0;4;3 0;0;0";

            test1_3 = "-1;1";
            test2_3 = "-1;1";
            test3_3 = "-1;1";
        }

        //public float NewtonI2(List<float[]> a, List<float[]> b, float upB = 25, float exact = 0.0001f)
        //{
        //    error = "";
        //    downB = upB;
        //    signAbroad = 1;
        //    iter = 0;
        //    derivA = Lab2_1.Derivative(a);
        //    deriv2A = Lab2_1.Derivative(Lab2_1.Derivative(a));
        //    if (Lab1_1.Gorner(a, upB + 0.5f) < 0) signAbroad *= -1; // ускоряет вычисление
        //    while (Lab1_1.Gorner(a, downB) * signAbroad > 0)
        //    {
        //        if (iter > 10000) { error = "Превышен лимит итераций при поиске границ!"; return x0; }
        //        downB -= 0.5f;
        //        iter++;
        //    }
        //    if (Lab1_1.Gorner(a, upB) * Lab1_1.Gorner(deriv2A, upB) < 0)
        //        x0 = upB;
        //    else
        //        x0 = downB;
        //    //xn = x0;
        //    xn = x0 - Lab1_1.Gorner(a, x0) / Lab1_1.Gorner(derivA, x0);
        //    while ((xn - x0 < -exact) || (xn - x0 > exact))
        //    {
        //        if (iter > 100000) { error = "Превышен лимит итераций при поиске корня!"; return x0; }
        //        if (Lab1_1.Gorner(derivA, x0) == 0) { error = "f'(a) = 0"; return x0; }
        //        x0 = xn;
        //        xn = x0 - Lab1_1.Gorner(a, x0) / Lab1_1.Gorner(derivA, x0);
        //        iter++;
        //    }
        //    error = "\nПонадобилось итераций: " + iter;
        //    return x0;
        //}

        float[] x0;
        int iter;
        List<float[]> derivAY;
        List<float[]> derivAX;
        List<float[]> derivBY;
        List<float[]> derivBX;
        // ГЛАВНЫЙ АЛГОРИТМ
        // Алгоритм можно сделать более универсальным, если один из входных параметров буддет массивом 
        // со всеми уравнениями системы
        //public float NewtonI2(List<float[]> a, List<float[]> b, float upB = 25, float exact = 0.001f) {
        public float[] NewtonI2(List<float[]> a, List<float[]> b, float[] x, float exact = 0.001f, int maxIter = 10000) {
            error = "";
            iter = 0;
            x0 = x;
            derivAY = Lab2_5_2.DerivativeY(a);
            derivAX = Lab2_5_2.DerivativeX(a);
            derivBY = Lab2_5_2.DerivativeY(b);
            derivBX = Lab2_5_2.DerivativeX(b);
            if (Jacobian2(a, b, x) == 0){ error = "Якобиан = 0"; return x0; }
            x0[0] += -1/Jacobian2(a, b, x0) *(Lab2_4_2.Gorner2(a, x0) * Lab2_4_2.Gorner2(derivBY, x0) - Lab2_4_2.Gorner2(b, x0) * Lab2_4_2.Gorner2(derivAY, x0)); 
            x0[1] += -1/Jacobian2(a, b, x0) *(Lab2_4_2.Gorner2(derivAX, x0) * Lab2_4_2.Gorner2(b, x0) - Lab2_4_2.Gorner2(derivBX, x0) * Lab2_4_2.Gorner2(a, x0)); 
            // !!! Изменить на проверку как в третьем номере
            while ((Lab2_4_2.Gorner2(a, x0) > exact)||(Lab2_4_2.Gorner2(a, x) < -exact)||(Lab2_4_2.Gorner2(b, x) > exact) || (Lab2_4_2.Gorner2(b, x) < -exact)){
                if (iter > maxIter) {
                    error = "Число итераций превысило " + maxIter + "!";
                    return x0;
                }
                if (Jacobian2(a, b, x0) == 0){ error = "Якобиан = 0"; return x0; }
                x0[0] += -1 / Jacobian2(a, b, x0) * (Lab2_4_2.Gorner2(a, x0) * Lab2_4_2.Gorner2(derivBY, x0) - Lab2_4_2.Gorner2(b, x0) * Lab2_4_2.Gorner2(derivAY, x0));
                x0[1] += -1 / Jacobian2(a, b, x0) * (Lab2_4_2.Gorner2(derivAX, x0) * Lab2_4_2.Gorner2(b, x0) - Lab2_4_2.Gorner2(derivBX, x0) * Lab2_4_2.Gorner2(a, x0));

                iter++;
            }

            error = "Число итераций: " + iter;
            return x0;
        }
        List<float[]>[,] jacobian;
        List<float[]> ax;
        List<float[]> bx;
        List<float[]> ay;
        List<float[]> by;
        int len;
        public float Jacobian2(List<float[]> a, List<float[]> b, float[] x) {
            ax = Lab2_5_2.DerivativeX(a);
            bx = Lab2_5_2.DerivativeX(b);
            ay = Lab2_5_2.DerivativeY(a);
            by = Lab2_5_2.DerivativeY(b);
            return Lab2_4_2.Gorner2(ax, x)* Lab2_4_2.Gorner2(by, x) - Lab2_4_2.Gorner2(bx, x) * Lab2_4_2.Gorner2(ay, x);
        }

        //public List<List<float>> Jacobian2(List<float[]> a, List<float[]> b)
        //{
        //    jacobian = new List<List<float>>();
        //    len = 0;
        //    ax = Lab2_5_2.DerivativeX(a);
        //    bx = Lab2_5_2.DerivativeX(b);
        //    ay = Lab2_5_2.DerivativeY(a);
        //    by = Lab2_5_2.DerivativeY(b);
        //    if ((ax.Count > 0) && (bx.Count > 0))
        //        len = ax[0].Length;
        //    else return null;
        //    for (int i = 0; i < ax.Count; i++)
        //    {
        //        jacobian.Add(new List<float>());
        //        for (int j = 0; j < len; j++)
        //        {
        //            jacobian[i].Add(ax[i][j]);
        //        }
        //    }
        //    if (bx.Count > 0)
        //        len += bx[0].Length;
        //    else return null;
        //    for (int i = 0; i < bx.Count; i++)
        //    {
        //        for (int j = jacobian[i].Count; j < len; j++)
        //        {
        //            jacobian[i].Add(bx[i][j - jacobian[i].Count]);
        //        }
        //    }
        //    if ((ay.Count > 0) && (by.Count > 0))
        //        len = ay[0].Length;
        //    else return null;
        //    for (int i = jacobian.Count; i < ax.Count + ay.Count; i++)
        //    {
        //        jacobian.Add(new List<float>());
        //        for (int j = 0; j < len; j++)
        //        {
        //            jacobian[i].Add(ay[i - ax.Count][j]);
        //        }
        //    }
        //    if (by.Count > 0)
        //        len += by[0].Length;
        //    else return null;
        //    for (int i = jacobian.Count; i < ax.Count + ay.Count; i++)
        //    {
        //        for (int j = jacobian[i].Count; j < len; j++)
        //        {
        //            jacobian[i].Add(by[i - ax.Count][j - jacobian[i].Count]);
        //        }
        //    }
        //    return jacobian;
        //}

        new List<float[]> inputData1;
        float[] out1_1;
        Polynomial poly1;
        LabArray arrA;
        LabArray arrB;


        // Перевод результата в выходные данные
        public override string OutData1()
        {
            InputData();
            if (inputData3.Length != 2) return outData1 = "Грубый корень введен некорректно!";
            outData1 = $"Введено: \n";
            outData1 += $"Действительная матрица:\n{arrA.strMatForm} \nКомплексная матрица:\n{arrB.strMatForm}";
            //out1_1 = NewtonI2(array1.arrForm, InputData2(inSData2));
            outData1 += $"Введен грубый корень: {inputData3[0]}";
            if (inputData3[1] >= 0) outData1 += "+";
            if (inputData3[1] == 1) outData1 += "i\n";
            else if (inputData3[1] == -1)
                outData1 += "-i\n";
            else
                outData1 += inputData3[1] + "i\n";
            out1_1 = NewtonI2(arrA.arrForm, arrB.arrForm, inputData3);
            outData1 = outData1 + $"\nНайден комплексный корень: {out1_1[0]}";
            if ((out1_1[0] == 0)||(out1_1[1] == 0)) error += "\nНули отображаются для видимости структуры ответа!"; ;
            if (out1_1[1] >= 0) outData1 += "+";
            if (out1_1[1] == 1) outData1 += "i\n";
            else if (out1_1[1] == -1)
                outData1 += "-i\n";
            else
                outData1 += out1_1[1] + "i\n";
            outData1 += "\n" + error + "\n";
            if ((arrA.arrForm == null)|| (arrB.arrForm == null))
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
