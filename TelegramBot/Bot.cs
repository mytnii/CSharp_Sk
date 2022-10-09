using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

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

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Bot()
        {
            _bot = new TelegramBotClient(@"C:\Test\token.txt");
        }
        #endregion

        #region Методы

        /// <summary>
        /// Обработка обновлений
        /// </summary>
        /// <param name="botClient">Телеграм бот</param>
        /// <param name="update">Обновление</param>
        /// <param name="cancellationToken">Отмена задачи</param>
        /// <returns></returns>
        public static async Task HandleUpdateAsync
            (
            ITelegramBotClient botClient, Update update,CancellationToken cancellationToken
            )
        {
            if(update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                var message = update.Message;

                switch (message.Text.ToLower())
                {
                    case "/start":
                        await botClient.SendTextMessageAsync(message.Chat, $"Добро пожаловать");
                        break;
                    default:
                        break;
                }

            }
        }
        #endregion
    }
}
