using System;

namespace Lab_1_2_2
{
    class Program
    {
        static float[] a1 = { 3, 1, -8, 0, 8, 7, 6};
        static float[] a2 = { 8, -7, 28, -5, -40, 10, -3, -28, -17, -9 };
        static float[] a3 = { 1, -1, -6, 4, 8};
        static float b1 = -2;
        static float b2 = 1;
        static float b3 = 2;

        static void PrintIn(float[] a, float a0)
        {
            Console.Write("Коэффициенты: ");
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write($"\t{a[i]}");
            }
            Console.Write($"\t|в точке: {a0}\n\t\t");
        }

        static float Gorner(float[] a, float a0) {
            //PrintIn(a, a0);
            int k = a.Length - 1;

            float[] b = new float[k + 1];
            b[0] = a[0];
            Console.Write(b[0]);
            for (int i = 1; i < k; i++)
            {
                b[i] = a[i] + b[i - 1] * a0;
                Console.Write($"\t{b[i]}");
            }
            float rez = b[k];
            Console.Write($"\nОтвет:\t\t{b[k]}\n\n");
            return (b[k]);
        }

        static float[] GornerDiv(float[] a, float a0) {
            int k = a.Length - 1;
            float[] b = new float[k];

            b[0] = a[0];
            for (int i = 1; i < k; i++) {
                b[i] = a[i] + b[i - 1] * a0;
            }
            return b;
        }

        static void Main(string[] args) {
            float[] tem;
            tem = GornerDiv(a1, b1);
            Console.WriteLine("");
            Console.WriteLine("[{0}]", string.Join(", ", tem));
            Console.ReadKey();
        }
    }
}
