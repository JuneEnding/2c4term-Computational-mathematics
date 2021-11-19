using System;
using static System.Math;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
namespace Lab8
{
    public class Model
    {

        public float[,] matrix;
        public float[] extension;
        public float[] result;

        public String tMatrix { get; set; }
        public String tExt { get; set; }
        public int rows { get; set; }
        public int cols { get; set; }

        public int count { get; set; }
        public int maxcount { get; set; } = 1000;
        public float accuracy = 0.0001f;

        public bool nice;
        public String nicelog;

        public Model() {}

        //**************************************
        // ГЛАВНЫЙ АЛГОРИТМ
        //**************************************
        public void CalcModel(int typeCalc)
        {
            count = 0;
            // матрица коэффициентов
            matrix = StringToArr2(tMatrix);
            // свободные члены матрицы
            extension = StringToArr(tExt);
            // решение
            result = new float[extension.Length];
            //сходимость
            nice = true;
            nicelog = "";

            //Текущая точность, чтобы войти в цикл (differency >= accuracy) ставим равенство 
            float differency = accuracy;

            // строк матрицы
            rows = tMatrix.Split(';').Length;
            // колонок матрицы
            cols = matrix.Length / rows;

            if (typeCalc == 1) // Гаусса
            {
                for (int k = 0; k < rows - 1; k++)
                    for (int i = k + 1; i < rows; i++)
                    {
                        for (int j = k + 1; j < rows; j++)
                            matrix[i, j] = matrix[i, j] - matrix[k, j] * (matrix[i, k] / matrix[k, k]);
                        extension[i] = extension[i] - extension[k] * matrix[i, k] / matrix[k, k];
                    }

                float s;
                for (int k = rows - 1; k >= 0; k--)
                {
                    s = 0;
                    for (int j = k + 1; j < rows; j++)
                        s = s + matrix[k, j] * result[j];
                    result[k] = (extension[k] - s) / matrix[k, k];
                }
            }
            else if (typeCalc == 2) // Прогонки (трехдиагональная)
            {
                nice = The3Diagonals();
                // a    - диагональ под главной (индексы [1; rows - 1])
                // b    - диагональ над главной (индексы: [0; rows - 2])
                // c    - главная диагональ (индексы: [0; rows - 1])
                // Заполнение диагоналей
                // a
                float[] a = new float[rows];
                for (int i = 0; i < rows - 1; i++)
                    a[i + 1] = matrix[i + 1, i];
                // b
                float[] b = new float[rows - 1];
                for (int i = 0; i < rows - 1; i++)
                    b[i] = matrix[i, i + 1];
                // c
                float[] c = new float[rows];
                for (int i = 0; i < rows; i++)
                    c[i] = matrix[i, i];

                float m;
                for (int i = 1; i < rows; i++)
                {
                    m = a[i] / c[i - 1];
                    c[i] = c[i] - m * b[i - 1];
                    extension[i] = extension[i] - m * extension[i - 1];
                }

                result[rows - 1] = extension[rows - 1] / c[rows - 1];
                for (int i = rows - 2; i >= 0; i--)
                    result[i] = (extension[i] - b[i] * result[i + 1]) / c[i];

            }
            else if (typeCalc == 3) // Итерации
            {
                //Расширенная матрица
                //matrix.GetLength(0) получение размерности
                float[,] a = new float[rows, cols + 1];
                //Предыдущие значения xi
                float[] previousValues = new float[rows];
                //Текущие значения xi
                float[] currentValues = new float[rows];

                //Заполнение расширенной матрицы
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < cols; j++)
                        a[i, j] = matrix[i, j];
                //Заполнение расширенной матрицы свободными членами
                for (int i = 0; i < rows; i++)
                    a[i, cols] = extension[i];

                //Обнуляем предыдущие значения
                for (int i = 0; i < rows; i++)
                    previousValues[i] = 0.0f;

                // Цикл итераций
                for (count = 0; differency >= accuracy && count < maxcount; count++)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        currentValues[i] = a[i, rows];
                        // Сумма по строке i кроме диагонали
                        for (int j = 0; j < rows; j++)
                            if (i != j)
                                currentValues[i] -= a[i, j] * previousValues[j];
                        currentValues[i] /= a[i, i];
                    }

                    //Подсчет погрешности
                    differency = 0.0f; // текущая точность
                    for (int i = 0; i < rows; i++)
                        differency += Abs(currentValues[i] - previousValues[i]);

                    //Присвоение предыдущих значений
                    for (int i = 0; i < rows; i++)
                        previousValues[i] = currentValues[i];
                }

                // Копирование последних значений в result
                result = previousValues;
            }
            else if (typeCalc == 4) // Зейделя
            {
                nice = TheMaxDiagonally();
                float s;
                float xi;
                for (count = 0; differency >= accuracy && count < maxcount; count++)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        // Сумма по строке i кроме диагонали
                        s = 0;
                        for (int j = 0; j < rows; j++)
                            if (i != j)
                                s += matrix[i, j] * result[j];

                        xi = (extension[i] - s) / matrix[i, i];
                        differency = Math.Abs(xi - result[i]);
                        result[i] = xi;
                    }
                }

            }
            // Возможно алгоритм затрет matrix или extension - заполним заново
            matrix = StringToArr2(tMatrix);
            extension = StringToArr(tExt);
        }

        public bool The3Diagonals()
        {
            for (int i = 2; i < rows; i++)
                for (int j = 0; j < i - 2; j++)
                    if (matrix[i, j] != 0)
                    {
                        nicelog = "Матрица не трехдиагональная! k(" + (i + 1) + ", " + (j + 1) + ") = " + matrix[i, j];
                        return false;
                    }

            for (int i = 0; i < rows; i++)
                for (int j = i + 2; j < rows; j++)
                    if (matrix[i, j] != 0)
                    {
                        nicelog = "Матрица не трехдиагональная! k(" + (i+1) + ", " + (j + 1) + ") = " + matrix[i, j];
                        return false;
                    }
            return true;
        }

        public bool TheMaxDiagonally()
        {
            for (int i = 0; i < rows; i++)
            {
                double sum = 0;
                for (int j = 0; j < cols; j++)
                    if (i != j)
                        sum += Abs(matrix[i, j]);

                if (Abs(matrix[i, i]) < sum)
                {
                    nicelog = "В строке: " + (i + 1) + " элемент главной диагонали меньше суммы остальных коэффициентов!";
                    return false;
                }
            }
            return true;
        }

        private float[] StringToArr(string tMatrix)
        {
            string[] strmatrix = tMatrix.Split(',');
            float[] matrix = new float[strmatrix.Length];
            for (int count = 0; count < strmatrix.Length; count++)
            {
                matrix[count] = float.Parse(strmatrix[count].Replace('.', ','));
            }

            return matrix;
        }

        private float[,] StringToArr2(string tMatrix)
        {
            string[] strmatrix = tMatrix.Split(';');
            string[] elmatrix;
            int rows = strmatrix[0].Split(',').Length;

            float[,] matrix = new float[strmatrix.Length, rows];
            //
            try {
                for (int count = 0; count < strmatrix.Length; count++)
                {
                    elmatrix = strmatrix[count].Split(',');

                    for (int row = 0; row < elmatrix.Length; row++)
                        matrix[count, row] = float.Parse(elmatrix[row].Replace('.', ','));
                }
            }
            catch (FormatException)  {
                MessageBox.Show("Данные введены некорректно!\n\n" 
                                , "Ошибка ввода данных");
            }
            //

            return matrix;
        }


    }// End class Model
}
