using System;
using static System.Math;
using System.Drawing;
using org.mariuszgromada.math.mxparser;
using System.Collections.Generic;

namespace Lab7
{
    public class Model
    {

        public float[] fmatrix;
        public float[] DERfmatrix;

        private float[] intevalx = new float[] { -3f, 3f };
        private float[] intevaly = new float[2];
        private float step = 0.2f;
        public int accuracy = 2;
        private float count;
        public float shift { get; set; } = 60;
        public String formula { get; set; }

        public float Step { get => step; set => step = value; }
        public float Count { get => count; set => count = value; }
        public float[] Intevaly { get => intevaly; set => intevaly = value; }
        public float[] Intevalx { get => intevalx; set => intevalx = value; }

        public Model() {}

        //________________________________________________________________________
        List<float[]> finDif;
        public List<float[]> FinDifferences(float[] a, int he = 1)
        {
            finDif = new List<float[]>(he + 1);
            finDif.Add(a);
            for (int i = 0; i < he; i++)
            {
                finDif.Add(new float[finDif[i].Length - 1]);
                for (int k = 0; k < finDif[i + 1].Length; k++)
                    finDif[i + 1][k] = finDif[i][k + 1] - finDif[i][k];

            }
            return finDif;
        }

        public float[] GridDerivative(float[] a, float h)
        {
            float[] a1;
            float[] dy;
            a1 = new float[a.Length - 1];
            dy = FinDifferences(a)[1];
            for (int i = 0; i < a1.Length; i++)
            {
                a1[i] = dy[i] / h; // бва. 565
            }
            return a1;
        }

        public void CalcModel()
        {
            Count = (Intevalx[1] - Intevalx[0]) / Step + 1;

            //foreach (float y in fmatrix)
            fmatrix = new float[(int)Count];
            for (int count = 0; count < Count; count++)
            {
                fmatrix[count] = Fun(formula, Intevalx[0] + count * Step);
                if (count == 0)
                {
                    Intevaly[0] = fmatrix[count];
                    Intevaly[1] = fmatrix[count];
                }
                Intevaly[0] = Min(Intevaly[0], fmatrix[count]);
                Intevaly[1] = Max(Intevaly[1], fmatrix[count]);
            }

            //DERfmatrix = GridDerivative(fmatrix, step);
            //for (int count = 0; count < Count - 1; count++)
            //{
            //    Intevaly[0] = Min(Intevaly[0], DERfmatrix[count]);
            //    Intevaly[1] = Max(Intevaly[1], DERfmatrix[count]);
            //}

        }

        public float Fun(String strf, float x)
        {
            Argument ax = new Argument("x", x);
            Expression e1 = new Expression(strf, ax);
            return (float)e1.calculate();
        }

        public float xScale(float WW)
        {
            return (WW - shift) / (Count);
        }

        public float yScale(float WH)
        {
            return (WH - shift) / (Intevaly[1] - Intevaly[0]);
        }

        public float Fx(float[] f, int x, float WH)
        {
            float k = yScale(WH);
            return (WH - shift / 2) - k * (f[x] - Intevaly[0]);
        }

        public float Fx(float x, float WH)
        {
            float k = yScale(WH);
            return (WH - shift / 2) - k * (x - Intevaly[0]);
        }

    }// End class Model
}
