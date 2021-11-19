using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWorkCompMath
{
    public class Lab
    {
        public string labelName;
        public string labelDataName1 = "";
        public string labelDataName2 = "";
        public string labelDataName3 = "";
        public int numData;
        public int numTests;
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

        //delegate void Algorithm(float[] d1, float[] d2, float[] d3);
        //Algorithm algorithm = null;

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
    }
}
