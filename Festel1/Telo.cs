using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festel1
{
    class Telo
    {
        public static int count;
        public static int[] key = new int[255];
        public static int[] di = new int[255];
        

        /// <summary>
        /// Конструктор.
        /// int _count - кол-во раундов.
        /// string _key - ключи.
        /// </summary>
        /// <param name="_count"></param>
        public Telo(int _count, string _key)
        {
            di = Func.zapis_di().Select(x => int.Parse(x)).ToArray();//Конверт string[] di в int[] di.
            count = _count;
            key = _key.Split(' ').Select(x => int.Parse(x)).ToArray();
        }

        /// <summary>
        /// Возвращает di. (int[])
        /// </summary>
        /// <returns></returns>
        public static int[] return_di()
        {
            return di;
        }

        /// <summary>
        /// Возвращает количество раундов. (int)
        /// </summary>
        /// <returns></returns>
        public static int return_count()
        {
            return count;
        }

        /// <summary>
        /// Возвращает длину di (int). 
        /// </summary>
        /// <returns></returns>
        public static int di_lenght()
        {
            return di.Length;
        }

        /// <summary>
        /// Возвращает ключи. xD (string[])
        /// </summary>
        /// <returns></returns>
        public static string[] return_key()
        {
            return key;
        }
    }
}
