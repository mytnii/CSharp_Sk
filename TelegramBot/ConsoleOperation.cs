using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot
{
    internal class ConsoleOperation
    {
        #region Методы

        /// <summary>
        /// Вывод в консоль
        /// </summary>
        /// <param name="str">Строка</param>
        public static void ConsoleOutput(ref string str)
        {
            Console.WriteLine(str);
        }
        #endregion
    }
}
