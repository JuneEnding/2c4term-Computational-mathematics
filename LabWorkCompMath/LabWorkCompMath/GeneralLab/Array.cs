using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabWorkCompMath.Lab1;
namespace LabWorkCompMath.GeneralLab {
    public class LabArray {
        public string strForm = "";
        public string strMatForm = "";
        public string strMatForm2 = "";
        public string viewForm = "";
        public int[] degreesPositions = { };
        public int[] multiplicationPositions = { };
        public int[] lengthOfDegrees = { };

        public List<float[]> arrForm;
        public List<List<float>> listForm;

        public List<List<float>> ArrToList(List<float[]> a)
        {
            len = 0;
            listForm = new List<List<float>>();
            if (a.Count > 0)
                len = arrForm[0].Length;
            for (int i = 1; i < arrForm.Count; i++)
                if (arrForm[i].Length != len)
                    return null;
            for (int i = 0; i < a.Count; i++) {
                listForm.Add(new List<float>());
                for (int j = 0; j < len; j++) {
                    listForm[i].Add(a[i][j]);
                }
            }
            return listForm;
        }

        public LabArray() { }
        public LabArray(string str) {
            arrForm = new List<float[]>();
            this.strForm = str;
            //this.viewForm = PrintArr(str);
            this.arrForm = strToArr(str);
            strMatForm = StrMatForm(arrForm);
            strMatForm2 = StrMatForm2(arrForm);
            viewForm = PrintArr(arrForm);
            // Позиции номеруются слева направо - [0] содержит данные о максимальной степени
            if ((arrForm!=null)&&((arrForm.Count > 2)||(arrForm[0].Length>2))) {
                this.lengthOfDegrees = new int[arrForm.Count*arrForm[0].Length - 2];
                degreesPositions = FindDegPos(this.viewForm, arrForm.Count * arrForm[0].Length - 2);
                lengthOfDegrees = FindLenDeg(this.viewForm, degreesPositions);
                multiplicationPositions = FindMultPos(this.viewForm, arrForm.Count * arrForm[0].Length);
            }
            listForm = ArrToList(arrForm);
        }
        public LabArray(List<float[]> arr)
        {
            arrForm = new List<float[]>();
            this.strForm = "";
            //this.viewForm = PrintArr(str);
            this.arrForm = arr;
            strMatForm = StrMatForm(arrForm);
            strMatForm2 = StrMatForm2(arrForm);
            viewForm = PrintArr(arrForm);
            // Позиции номеруются слева направо - [0] содержит данные о максимальной степени
            if ((arrForm != null) && ((arrForm.Count > 2) || (arrForm[0].Length > 2)))
            {
                this.lengthOfDegrees = new int[arrForm.Count * arrForm[0].Length - 2];
                degreesPositions = FindDegPos(this.viewForm, arrForm.Count * arrForm[0].Length - 2);
                lengthOfDegrees = FindLenDeg(this.viewForm, degreesPositions);
                multiplicationPositions = FindMultPos(this.viewForm, arrForm.Count * arrForm[0].Length);
            }
        }


        string tem = "";
        string temTex;
        int pos = 0;
        string arr;
        public string PrintArr(List<float[]> a) {
            if (a == null) return arr;
            if (a.Count == 0) return "0";
            arr = Polynomial.PrintPoly(a[0]);
            pos = 1;
            if (a.Count - 1 > 1) tem = "y^" + (a.Count - 1);
            if (a.Count - 1 == 1) tem = "y";
            if (a.Count - 1 < 1) tem = "";
            for (int j = pos; j < arr.Length; j++) {
                if ((arr[j] == '-') || (arr[j] == '+')) {
                    arr = arr.Insert(j, tem);
                    j += tem.Length;
                }
            }
            if ((arr.Length>0)&&((Char.IsDigit(arr, arr.Length - 1)||(arr[arr.Length - 1] == 'x')))) {
                if ((arr[arr.Length - 1] == '1')&&(tem!=""))
                    arr.Remove(arr.Length - 1, 1);
                arr += tem;
            }
            for (int i = 1; i < a.Count; i++) {//!!!! А ЕСЛИ С + ПЕРВОЕ ЧИСЛО
                pos = arr.Length + 1;
                temTex = Polynomial.PrintPoly(a[i]);
                if ((temTex != "0") && (arr == "0")) arr = "";
                if ((temTex == "0") && (arr.Length != 0)) temTex = "";
                if ((temTex.Length>0) &&((Char.IsDigit(temTex, 0)) || (temTex[0] == 'x') || (temTex[0] == 'y'))&&(arr.Length!=0))
                    arr += "+";
                arr = arr + temTex;
                if (a.Count - i - 1 > 1) tem = "y^" + (a.Count - i - 1);
                if (a.Count - i - 1 == 1) tem = "y";
                if (a.Count - i - 1 < 1) tem = "";
                for (int j = pos; j < arr.Length; j++) {
                    if ((arr[j] == '-') || (arr[j] == '+')) {
                        arr = arr.Insert(j, tem);
                        j += tem.Length;
                    }
                }
                if ((temTex.Length > 0) && (Char.IsDigit(arr, arr.Length - 1) || (arr[arr.Length - 1] == 'x'))) {
                    if (arr[arr.Length - 1] == '1')
                        arr.Remove(arr.Length - 1, 1);
                    arr += tem;
                }
            }
            if (arr.Length == 0) arr = "0";
            return arr;
        }

        
        public string StrMatForm(List<float[]> a) {
            string arr = "";
            if (a==null) return arr;
            for (int i = 0; i < a.Count; i++) {
                for (int j = 0; j < a[i].Length; j++)
                    arr = arr + "\t" + a[i][j];
                arr = arr + "\n";
            }
            return arr;
        }

        // Первая строка представляется в виде [ , , , ]
        public string StrMatForm2(List<float[]> a)
        {
            string arr = "[ ";
            if ((a == null) || (a.Count != 1)) return "[ ]";
            for (int j = 0; j < a[0].Length - 1; j++)
                arr += a[0][j] + "; ";
            arr += a[0][a[0].Length - 1];
            arr += " ]";
            return arr;
        }

        string[] temArr;
        int len;
        public List<float[]> strToArr(string str) {
            arrForm.Clear();
            temArr = str.Split(' ');
            for (int i = 0; i < temArr.Length; i++) {
                arrForm.Add(temArr[i].Split(';').Select(float.Parse).ToArray());
            }
            if(arrForm.Count>0)
                len = arrForm[0].Length;
            for (int i = 1; i < arrForm.Count; i++)
                if (arrForm[i].Length != len)
                    return null;
            return arrForm;
        }
        int j;
        public int[] FindDegPos(string str, int[] pos)
        {
            j = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str.Length <= k) break;
                if ((str[i] == '^') && (j < pos.Length))
                {
                    pos[j] = i;
                    j++;
                }
            }
            return pos;
        }
        public int[] FindDegPos(string str, int nPos)
        {
            int[] pos = new int[nPos];
            j = 0;
            for (int i = 0; i <= str.Length; i++)
            {
                if (str.Length < k) break;
                if ((str.Length>i) &&(str[i] == '^') && (j < pos.Length))
                {
                    pos[j] = i;
                    j++;
                }
            }
            return pos;
        }
        public int[] FindMultPos(string str, int nPos)
        {
            int[] pos = new int[nPos];
            j = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str.Length <= k) break;
                if ((str[i] == '*') && (j < pos.Length))
                {
                    pos[j] = i;
                    j++;
                }
            }
            return pos;
        }

        int k;
        public int[] FindLenDeg(string str, int[] pos)
        {
            int[] lenDeg = new int[pos.Length];
            j = 0;
            foreach (int i in pos)
            {
                k = i + 1;
                if (str.Length <= k) return lenDeg;
                while ((lenDeg.Length>j)&&(str.Length>k) &&((('0' <= str[k]) && (str[k] <= '9')) || ('.' == str[k])) && (j < pos.Length))
                {
                    lenDeg[j]++;
                    k++;
                }
                j++;
            }
            lenDeg = Lab.CutNull(lenDeg);
            return lenDeg;
        }
    }
}
