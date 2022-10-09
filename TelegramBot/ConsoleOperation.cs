using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot
{
    /// <summary>
    /// Работа с консолью
    /// </summary>
    internal class ConsoleOperation
    {
        #region Методы

        /// <summary>
        /// Вывод в консоль
        /// </summary>
        /// <param name="str">Строка</param>
        public static void ConsoleOutput(string str)
        {
            Console.WriteLine(str);
        }
        #endregion
    }
}
