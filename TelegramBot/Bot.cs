using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramBot
{
    /// <summary>
    /// Телеграмм бот
    /// </summary>
    internal class Bot
    {
        #region Поля

         private  static ITelegramBotClient _bot;   // Телеграм бот 

        #endregion

        #region Свойства
        public ITelegramBotClient TBot
        {
            get { return _bot; }
        }
        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Bot()
        {
            _bot = new TelegramBotClient(System.IO.File.ReadAllText(@"C:\Test\token.txt"));
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
            // Обработка сообщений
            if(update.Type == UpdateType.Message)
            {
                //Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
                var message = update.Message;

                // Обработка сообщений

                if (message.Text != null)
                {
                    switch (message.Text.ToLower())
                    {
                        case "/start":
                            await botClient.SendTextMessageAsync(message.Chat, $"Добро пожаловать {message.From.FirstName}");
                            break;
                        default:
                            await botClient.SendTextMessageAsync(message.Chat, "Немогу обработать данное сообщение");
                            break;
                    } 
                }
                else if(message.Document != null)
                {
                    DownloadFile(botClient, message.Document.FileId, message.Document.FileName);

                    await botClient.SendTextMessageAsync(message.Chat, "Документ скачан");
                }
            }

        }

        /// <summary>
        /// Скачивание файла
        /// </summary>
        /// <param name="botClient">Телеграм бот</param>
        /// <param name="message">ID файла</param>
        /// <returns></returns>
        public static async Task DownloadFile(ITelegramBotClient botClient, String fileID, string fileName)
        {
            var file = await botClient.GetFileAsync(fileID);
            FileStream fileStream = new FileStream( fileName, FileMode.Create);
            await botClient.DownloadFileAsync(file.FilePath, fileStream);
            fileStream.Close();

            fileStream.Dispose();
        }

        /// <summary>
        /// Обработка ошибок
        /// </summary>
        /// <param name="botClient">Телеграм бот</param>
        /// <param name="exception">Обновление</param>
        /// <param name="cancellationToken">Отмена задачи</param>
        /// <returns></returns>
        public static async Task HandleErrorAsync
            (
            ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken
            )
        {
            ConsoleOperation.ConsoleOutput(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }
        #endregion
    }
}
