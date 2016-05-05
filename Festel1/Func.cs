using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using Microsoft.Office.Interop.Word;


namespace Festel1
{
    class Func
    {
        public static OpenFileDialog openFileDialog1 = new OpenFileDialog();
        public static int H, L, F, Q;
        public static string diDouble;
        public static string[] diStr;
        public static Microsoft.Office.Interop.Word.Application prog = new Microsoft.Office.Interop.Word.Application();
        public static Microsoft.Office.Interop.Word.Document wrd = prog.Documents.Add();

        public static void check()
        {
            if (Telo.return_count() > Telo.return_key_lenght())
            {
                MessageBox.Show("Низя так делать. (Раунды > Кол-во ключей)");
                Environment.Exit(0);
            }
            else
            {
                word();
            }
        }

        /// <summary>
        /// Параметры ворда.
        /// </summary>
        public static void word()
        {
            wrd.Activate();
            wrd.Content.Font.Size = 16.0F;
            wrd.Content.Font.Name = "Monotype Corsiva";
            wrd.Content.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;
            wrd.Content.LanguageID = WdLanguageID.wdRussian;
        }

        /// <summary>
        /// Закрываем документ.
        /// </summary>
        public static void end_word()
        {
            ((_Document)wrd).Save();
            ((_Document)wrd).Close();
            ((_Application)prog).Quit();
        }

        public static void word_write_start(int _di, int _H, int _L)
        {
            int[] key = Telo.return_key();
            wrd.Paragraphs.Last.Range.Text = "Типа шифрование";
            wrd.Paragraphs.Add();
            wrd.Paragraphs.Last.Range.Text = "Ключи - " + string.Join(" ", key).ToString();
            wrd.Paragraphs.Add();
            wrd.Paragraphs.Last.Range.Text = "DI = " + Convert.ToString(_di);
            wrd.Paragraphs.Add();
            wrd.Paragraphs.Last.Range.Text = "DI (2) = " + Convert.ToString(_di, 2);
            wrd.Paragraphs.Add();
            wrd.Paragraphs.Last.Range.Text = "H = " + _H + ", " + Convert.ToString(_H, 2);
            wrd.Paragraphs.Add();
            wrd.Paragraphs.Last.Range.Text = "L = " + _L + ", " + Convert.ToString(_L, 2);
        }

        public static void word_write_rounds(int _H, int _L, int iter, int _F)
        {
            wrd.Paragraphs.Add();
            wrd.Paragraphs.Last.Range.Text = "\tРаунд " + (iter + 1) + ":";
            wrd.Paragraphs.Add();
            wrd.Paragraphs.Last.Range.Text = "\tF" + (iter + 1).ToString() + " = " + _F + ", " + Convert.ToString(_F, 2);
            wrd.Paragraphs.Add();
            wrd.Paragraphs.Last.Range.Text = "\tL" + (iter + 1).ToString() + " = " + _L + ", " + Convert.ToString(_L, 2);
            wrd.Paragraphs.Add();
            wrd.Paragraphs.Last.Range.Text = "\tH" + (iter + 1).ToString() + " = " + _H + ", " + Convert.ToString(_H, 2);
            wrd.Paragraphs.Add();
        }

        public static void word_write_final(int _H, int _L)
        {
            wrd.Paragraphs.Add();
            wrd.Paragraphs.Last.Range.Text = "Итоговое H = " + _H + ", " + Convert.ToString(_H, 2);
            wrd.Paragraphs.Add();
            wrd.Paragraphs.Last.Range.Text = "Итоговое L = " + _L + ", " + Convert.ToString(_L, 2);
            wrd.Paragraphs.Add();
            wrd.Paragraphs.Add();
            wrd.Paragraphs.Add();
        }

        /// <summary>
        /// Берем все строки из файла и записываем в di.
        /// </summary>
        /// <returns></returns>
        public static string[] zapis_di()
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string ext = Path.GetExtension(openFileDialog1.FileName);
                {
                    diStr = File.ReadAllLines(openFileDialog1.FileName);
                }
            }
            else Environment.Exit(0);
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
            Func.word();
            int[] key = Telo.return_key();
            for (int i = 0; i < Telo.return_count(); i++)
            {
                Q = L;
                F = ((L + (i + 1)) * key[i]) % 256;
                L = F ^ H;
                H = Q;
                Func.word_write_rounds(H, L, i, F);
            }
        }

        /// <summary>
        /// Весь алгоритм шифрования.
        /// </summary>
        public static void algoritm()
        {
            Func.check();
            int[] di = Telo.return_di();
            int[] key = Telo.return_key();
            for (int countDi = 0; countDi < Telo.di_lenght(); countDi++)
            {
                diDouble = Convert.ToString(di[countDi], 2);
                while (diDouble.Length < 16)
                    diDouble = "0" + diDouble;
                H = Convert.ToInt32(diDouble.Substring(8), 2);
                L = Convert.ToInt32(diDouble.Remove(8), 2);
                Func.word_write_start(di[countDi], H, L);
                Func.rounds();
                Func.swap();
                Func.word_write_final(H, L);
            }
            Func.end_word();
            MessageBox.Show("Документ успешно сформирован");
        }
    }
}
