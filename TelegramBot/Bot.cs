using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace TelegramBot
{
    /// <summary>
    /// Телеграмм бот
    /// </summary>
    internal class Bot
    {
        #region Поля

         private static ITelegramBotClient _bot;   // Телеграм бот 

        #endregion

        #region Классы

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Bot()
        {
            _bot = new TelegramBotClient(@"C:\Test\token.txt");
        }
        #endregion
    }
}
