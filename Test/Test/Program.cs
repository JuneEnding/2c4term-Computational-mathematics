using System;

namespace Test
{
    class Program
    {
        public string PrintPoly(float[] a)
        {
            string poly = "";
            poly = $"{a[0]}";
            int n = 1;
            for (int i = (a.Length - 1); i > 0; i--)
            {
                poly = $"{a[i]}*x^{i.ToString()}+" + $"{poly}";
                n++;

            }
            return poly;
        }
        static void Main(string[] args)
        {
            float[] a = { 0, 8 };
            int b = 1;
            string poly = "";
            Console.WriteLine($"{Math.Abs(0) > 0.001}");
            poly = $"{a[0]}" + $"{poly}";
            poly = $"{a[1]}" + $"{poly}";
            Console.WriteLine($"{PrintPoly(a)}");
            Console.ReadKey();
        }
    }
}
