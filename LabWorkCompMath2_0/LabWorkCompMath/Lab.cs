using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabWorkCompMath {

    // В этом классе находятся общие для всех работ данные / функции для отсутствия копирования частей кода
    public class Lab {
        public Lab( ) { }
        public Lab(Button relatedButton) {
            this.relatedButton = relatedButton; 
         }
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // Эти поля необходимы для быстрой отладки
        // Заполнив их 1 раз, можно сэкономить время на вводе данных
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public Button relatedButton;
        public string labelName;
        public string labelDataName1 = "";
        public string labelDataName2 = "";
        public string labelDataName3 = "";
        public int    numData;
        public int    numTests;
        // Номер эксперимента _ поле data
        public string test1_1 = "";
        public string test1_2 = "";
        public string test1_3 = "";
        public string test2_1 = "";
        public string test2_2 = "";
        public string test2_3 = "";
        public string test3_1 = "";
        public string test3_2 = "";
        public string test3_3 = "";
        public string test4_1 = "";
        public string test4_2 = "";
        public string test4_3 = "";
        public string test5_1 = "";
        public string test5_2 = "";
        public string test5_3 = "";
        public float[] inputData1 = { 0 };
        public float[] inputData2 = { 0 };
        public float[] inputData3 = { 0 };

        // Обработка входных данных string -> float[]
        public virtual float[] InputData1(string str){
            inputData1 = str.Split(';').Select(float.Parse).ToArray();
            return inputData1;
        }
        public virtual float[] InputData2(string str){
            inputData2 = str.Split(';').Select(float.Parse).ToArray();
            return inputData2;
        }
        public virtual float[] InputData3(string str){
            inputData3 = str.Split(';').Select(float.Parse).ToArray();
            return inputData3;
        }

        // Вывод данных -> string
        public string outData1;
        public virtual string OutData1(){
            //algorithm(inputData1, inputData2, inputData3);
            outData1 = '[' + string.Join(" ", inputData1) + ']' +',' + ' ' + '[' + string.Join(" ", inputData2) + ']';
            return outData1;
        }

        // Печать полинома
        // float -> полином типа string
        // !!! Переменные внутри функции позволяют использовать ее  без создания члена класса
        // конечно, занимается некоторая память в куче. Но в С# существует уборка мусора
        // И данная функция используется редко и таким образом не способна захломить кучу
        public string PrintPoly(float[] a) {
            string poly = "";
            int n = 2;
            
            // Анализ первых членов
            if  (a.Length > 0) poly =$"{a[a.Length - 1]}" ;
            if ((a.Length > 1) && (a[a.Length - 1] == 0)){
                if ((a.Length > 1)&&(a[a.Length - 2]>0)) poly = $"{a[a.Length-2]}*x" +  $"{poly}";
                if ((a.Length > 1)&&(a[a.Length - 2]<0)) poly = $" {a[a.Length-2]}*x" +  $"{poly}";
            }
            else{
                if (a[a.Length - 1] > 0) poly = "+" + $"{poly}"; 
                if ((a.Length > 1) && (a[a.Length - 2] > 0)) poly = $"{a[a.Length - 2]}*x" +  $"{poly}";
                if ((a.Length > 1) && (a[a.Length - 2] < 0)) poly = $" {a[a.Length - 2]}*x" + $"{poly}";
            }

            for (int j = a.Length - 3; j >= 0; j--) {
                if ((a[j + 1] > 0)&&(a[j]!=0)) poly = "+" + $"{poly}"; 
                if (a[j] == 1) { poly = $"x^{n}" +  $"{poly}"; n++; continue; }
                if (a[j] > 0) poly = $"{a[j]}*x^{n}" +  $"{poly}";
                if (a[j] < 0) poly = $"{a[j]}*x^{n}" +  $"{poly}";
                n++;
            }
            poly = $"{poly}"+"\n";
            return poly;
        }
    }
}
