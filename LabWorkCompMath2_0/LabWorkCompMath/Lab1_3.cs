    using System.Windows.Forms;
namespace LabWorkCompMath
{
    class Lab1_3 : Lab {

        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // Эти поля необходимы для быстрой отладки
        // Заполнив их 1 раз, можно сэкономить время на вводе данных
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public Lab1_3() : this(null) { }

        public Lab1_3(Button relatedButton) : base(relatedButton) {
            labelName       = "3.	Провести замену переменных в полиноме";
            labelDataName1  = "коэффициенты полинома:";
            labelDataName2  = "замена х=(y+a), число а:";
            // Число данных
            numData     = 2;
            // Число тестов
            numTests    = 3; 
            // Эти данные будут вводиться во входную строку, имитируя ручной ввод
            // Номер теста_номер входной строки
            test1_1     = "1;-8;5;2;-7";
            test2_1     = "1;-3;-12;52;-48";
            test3_1     = "1;13;57;83;-34;-120;0";
            test1_2     = "2";
            test2_2     = "3";
            test3_2     = "-1";
        }

        // В данном случае не выношу переменные, так как важность понятности программы превышает 
        // затраты памяти, кроме того в С# работает автоматическая сборка мусора!
        // Также появится возможность использовать эту функцию без создания объекта! (относится ко всем пунктам)
        
        // ГЛАВНЫЙ АЛГОРИТМ
        public float[] GornerReplace(float[] a, float a0) {
            int k = a.Length;
            float[] b = new float[k];
            float[] out1 = new float[k];
            
            b[0] = a[0];// !!! Этот элемент равен этому часлу на протяжении всего цикла!!!
            for (int i = k; i > 0; i--) {
                for (int j = 1; j < i; j++)
                    b[j] = a[j] + b[j - 1] * a0;
                out1[i-1] = b[i-1];
                a = b;
            }
            return out1;
        }

        // Результат конкретно этого пункта
        float[] out1_1;
        string sign = "+";

        // Перевод результата в выходные данные
        public override string OutData1() {
            sign = "+";
            if (inputData2[0] < 0) sign = "";
            out1_1 = GornerReplace(inputData1, inputData2[0]);
            outData1 = $"Введен полином: \n" +
                    $"f(x)={PrintPoly(inputData1)}" +
                    $"\nВ введенном полиноме проведем замену х =( y{sign}{inputData2[0]} ) : \n" +
                    $"f( y{sign}{inputData2[0]} ) = \n{PrintPoly(out1_1)}";
            return outData1;
        }
    }
}
