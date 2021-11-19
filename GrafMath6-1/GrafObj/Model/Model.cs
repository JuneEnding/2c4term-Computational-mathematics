using System;
using static System.Math;
using System.Drawing;
using Microsoft.CSharp;
using org.mariuszgromada.math.mxparser;
using System.Collections.Generic;
using System.Globalization;

namespace GrafObj
{
    public class Model
    {

        public float[] fmatrix;
        // = new float[] {-0.008f, -0.066f, -0.209f, -0.439f, -0.734f, -1.044f, -1.31f, -1.484f, -1.542f, -1.491f, -1.366f, -1.218f, -1.093f, -1.02f, -0.998f, -1f, -0.982f, -0.901f, -0.733f, -0.479f, -0.174f, 0.128f, 0.372f, 0.513f, 0.537f, 0.46f, 0.323f, 0.177f, 0.065f, 0.009f, -0.002f};
        //{-5f, -4.597f, -4.178f, -3.727f, -3.234f, -2.688f, -2.082f, -1.411f, -0.674f, 0.131f, 1f, 1.929f, 2.91f, 3.935f, 4.99f, 6.063f, 7.134f, 8.187f, 9.198f, 10.145f, 11f};
        //{0f, 1.483f, 2.739f, 3.782f, 4.647f, 5.437f, 6.363f, 7.723f, 9.749f, 12.314f, 14.659f, 15.538f, 14.109f, 11.222f, 9.578f, 11.331f, 14.75f, 15.096f, 11.393f, 9.66f, 13.403f};
        //{9,4,1,0,1,4,9};
        public float[] DERfmatrix;

        private float[] intevalx;
        private float[] intevaly = new float[2];
        private float step;
        private float count;
        public float shift { get; set; } = 60;

        public String formula { get; set; }
        public String tintervalx { get; set; }
        public String tstep { get; set; }

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

        //***********************************************************************
        // ГЛАВНЫЙ АЛГОРИТМ
        //***********************************************************************
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

        //ПОГРЕШНОСТЬ
        public float Inaccuracy(float[] a, float h)
        {
            return (a[1] - a[0]) / (h);
        }

        public void CalcModel()
        {
            fmatrix = StringToArr(formula);
            intevalx = StringToArr(tintervalx);
            Step = StringToArr(tstep)[0];
            //Step = float.Parse(tstep.Replace('.', ','));
            Count = (Intevalx[1] - Intevalx[0]) / Step + 1;



            //foreach (float y in fmatrix)
            for (int count = 0; count < Count; count++)
            {
                //fmatrix[count] = Fun(formula, Intevalx[0] + count * Step);
                if (count == 0)
                {
                    Intevaly[0] = fmatrix[count];
                    Intevaly[1] = fmatrix[count];
                }
                Intevaly[0] = Min(Intevaly[0], fmatrix[count]);
                Intevaly[1] = Max(Intevaly[1], fmatrix[count]);
            }

            DERfmatrix = GridDerivative(fmatrix, step);
            for (int count = 0; count < Count - 1; count++)
            {
                Intevaly[0] = Min(Intevaly[0], DERfmatrix[count]);
                Intevaly[1] = Max(Intevaly[1], DERfmatrix[count]);
            }

        }

        private float[] StringToArr(string formula)
        {
            string[] strmatrix = formula.Split(',');
            float[] matrix = new float[strmatrix.Length];
            for (int count = 0; count < strmatrix.Length; count++)
            {
                matrix[count] = float.Parse(strmatrix[count].Replace('.', ','));
            }
            return matrix;
        }

        public float Fun(String strf, float x)
        {
            //Argument ax = new Argument("x", x);
            //Expression e1 = new Expression(strf, ax);
            //return (float)e1.calculate();
            return (float)(Pow(Sin(x),3) - Pow(Sin(x / 2), 2) + 2);
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
