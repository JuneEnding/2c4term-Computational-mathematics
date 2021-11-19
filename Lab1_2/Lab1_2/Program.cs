using System;

namespace Lab1_2 {
    class Program {
        static float[]  a1 = { -5, -1, 3, -2, 5 };
        static float[]  a2 = { -3, -2, 0, -2, 1 };
        static float[]  a3 = { -0.9f, 2.1f, 3.7f, -2.4f, 0.8f };
        static float    b1 = -1;
        static float    b2 = 1.3f;
        static float    b3 = 3;

        static void PrintIn(float[] a, float a0)
        {
            Console.Write("Коэффициенты: ");
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write($"\t{a[i]}");
            }
            Console.Write($"\t|в точке: {a0}\n\t\t");
        }

        static float Gorner(float[] a, float a0)
        {
            PrintIn(a, a0);
            int k = a.Length - 1;

            float[] b = new float[k + 1];
            b[0] = a[0];
            Console.Write(b[0]);
            for (int i = 1; i < a.Length; i++)
            {
                b[i] = a[i] + b[i - 1] * a0;
                Console.Write($"\t{b[i]}");
            }
            float rez = b[k];
            Console.Write($"\nОтвет:\t\t{b[k]}\n\n");
            return (b[k]);
        }

        static void Main(string[] args) {
            Gorner(a1,b1);
            Gorner(a2,b2);
            Gorner(a3,b3);
            Console.ReadKey();
        }
    }
}
