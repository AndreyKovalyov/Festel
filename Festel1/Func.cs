using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;


namespace Festel1
{
    class Func
    {
        public static OpenFileDialog openFileDialog1 = new OpenFileDialog();
        public static int H, L, F, Q;
        public static string diDouble;

        public static string[] diStr = new string[255];
        public static int[] di = Telo.return_di();


        /// <summary>
        /// Берем все строки из файла и записываем в di.
        /// </summary>
        /// <returns></returns>
        public static string[] zapis_di()
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt";
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                string ext = Path.GetExtension(openFileDialog1.FileName);
                {
                    diStr = File.ReadAllLines(openFileDialog1.FileName);
                }
            }
            return diStr;
        }

        /// <summary>
        /// Часть алгоритма - перестановка.
        /// </summary>
        public static void swap()
        {
            Q = H;
            H = L;
            L = Q;
        }

        /// <summary>
        /// Тело раундов.
        /// </summary>
        public static void rounds()
        {
            int[] key = new int[] { 6, 7, 13, 22, 66 };
            for (int i = 0; i < Telo.return_count(); i++)
            {
                Q = L;
                F = ((L + (i + 1)) * key[i]) % 256;
                L = F ^ H;
                H = Q;
            }
        }

        /// <summary>
        /// Весь алгоритм шифрования.
        /// </summary>
        public static void algoritm()
        {
            for (int countDi = 0; countDi < Telo.di_lenght(); countDi++)
            {
                diDouble = Convert.ToString(di[countDi], 2);
                while (diDouble.Length < 16)
                    diDouble = "0" + diDouble;
                H = Convert.ToInt32(diDouble.Substring(8), 2);
                L = Convert.ToInt32(diDouble.Remove(8), 2);
                Func.rounds();
                Func.swap();
            }
        }
    }
}
