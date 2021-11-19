using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Класс для работы с полиномом
namespace LabWorkCompMath.GeneralLab
{
    public class Polynomial
    {
        public string   strForm = "";
        public float[]  floatForm = { };
        public int[]    degreesPositions = { };
        public int[]    multiplicationPositions = { };
        public int[]    lengthOfDegrees  = { };

        public Polynomial() { }
        public Polynomial(float[] a) {
            this.strForm    = PrintPoly(a);
            this.floatForm  = a;
            // Позиции номеруются слева направо - [0] содержит данные о максимальной степени
            if (a.Length - 2 > 0) {
            this.lengthOfDegrees = new int[a.Length - 2];
            degreesPositions = FindDegPos(this.strForm, a.Length - 2);
            lengthOfDegrees  = FindLenDeg(this.strForm, degreesPositions);
            multiplicationPositions = FindMultPos(this.strForm, a.Length);
            }
        }

        // Печать полинома
        // float -> полином типа string
        // !!! Переменные внутри функции позволяют использовать ее  без создания члена класса
        // конечно, занимается некоторая память в куче. Но в С# существует уборка мусора
        // И данная функция используется редко и таким образом не способна захломить кучу
        public static string PrintPoly(float[] a) {
            if (a.Length == 0) return "0";
            if ((a.Length == 1) && (a[0] == 0)) return "0";
            string poly = "";
            int n = 2;
            bool existPlus = false;
            // Анализ первых членов
            if ((a.Length > 0) && (a[a.Length - 1] != 0)) { poly = $"{a[a.Length - 1]}"; if (a[a.Length - 1] > 0) existPlus = true; }
            if (a.Length <= 1) return poly;
            if (existPlus && (a[a.Length - 2] != 0)) { poly = "+" + $"{poly}"; if (a[a.Length - 2] < 0) existPlus = false; }
            switch (a[a.Length - 2]) {
                case 1:
                    poly = $"x" + $"{poly}";
                    existPlus = true;
                    break;
                case -1:
                    poly = $"-x" + $"{poly}";
                    existPlus = false;
                    break;
                default:
                    if (a[a.Length - 2] > 0) { poly = $"{a[a.Length - 2]}*x" + $"{poly}"; existPlus = true; }
                    if (a[a.Length - 2] < 0) { poly = $"{a[a.Length - 2]}*x" + $"{poly}"; existPlus = false; }
                    break;
            }

            for (int j = a.Length - 3; j >= 0; j--) {
                if (existPlus && (a[j] != 0)) { poly = "+" + $"{poly}"; if (a[j] < 0) existPlus = false; }
                if (a[j] == 1) { poly = $"x^{n}" + $"{poly}"; existPlus = true; n++; continue; }
                if (a[j] == -1) { poly = $"-x^{n}" + $"{poly}"; existPlus = false; n++; continue; }
                if (a[j] > 0) { poly = $"{a[j]}*x^{n}" + $"{poly}"; existPlus = true; }
                if (a[j] < 0) { poly = $"{a[j]}*x^{n}" + $"{poly}"; existPlus = false; }
                n++;
            }
            
            poly = $"{poly}";
            return poly;
        }
        // Позиции записываются по ходу чтения!!!
        int j;
        public int[] FindDegPos(string str, int[] pos){
            j = 0;
            for (int i = 0; i < str.Length ; i++) {
                if ((str[i] == '^')&&(j<pos.Length)) {
                    pos[j] = i;
                    j++;
                }
            }
            return pos;
        }
        public int[] FindDegPos(string str, int nPos) {
            int[] pos = new int[nPos];
            j = 0;
            for (int i = 0; i< str.Length; i++) {
                if ((str[i] == '^') && (j < pos.Length)) {
                    pos[j] = i;
                    j++;
                }
            }
            return pos;
        }
        public int[] FindMultPos(string str, int nPos) {
            int[] pos = new int[nPos];
            j = 0;
            for (int i = 0; i < str.Length; i++) {
                if ((str[i] == '*') && (j < pos.Length)) {
                    pos[j] = i;
                    j++;
                }
            }
            return pos;
        }

        int k;
        public int[] FindLenDeg(string str, int[] pos) {
            int[] lenDeg = new int[pos.Length];
            j = 0;
            foreach (int i in pos) {
                k = i+1;
                while(((( '0' <= str[k]) && (str[k] <= '9'))||('.' == str[k])) && (j < pos.Length)) {
                    lenDeg[j]++;
                    k++;
                }
                j++;
            }
            return lenDeg;
        }

    }
}
