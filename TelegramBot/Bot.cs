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
                    
                    string[] str = message.Text.Split(new char[] { '@' });
                    switch (str[0].ToLower())
                    {
                        case "/start":
                            await botClient.SendTextMessageAsync(message.Chat, $"Добро пожаловать {message.From.FirstName}");
                                await botClient.SendTextMessageAsync
                                        (
                                        message.Chat, "/help - информация по существующим командам"
                                        );
                                break;
                        case "/help":
                            await botClient.SendTextMessageAsync(message.Chat, $"/file_list - отобразить список файлов");
                            break;
                        case "/file_list":
                            await botClient.SendTextMessageAsync(message.Chat, FileHandling.FileReading());
                            break;
                        default:
                            string fileList = FileHandling.FileReading();
                            string[] fl = fileList.Split(new char[] { ' ' }).ToArray();
                            for(int i = 0; i < fl.Length; i++)
                            {
                                Console.WriteLine(fl[i]);
                            }
                            await botClient.SendTextMessageAsync(message.Chat, "Немогу обработать данное сообщение");
                            break;
                    } 
                }

                // Скачивание документов
                else if(message.Document != null)
                {
                    await DownloadFile(botClient, message.Document.FileId, message.Document.FileName);

                    FileHandling.Filling(message.Document.FileName);

                    await botClient.SendTextMessageAsync(message.Chat, "Документ скачан");
                }

                // Скачивание фото
                else if(message.Photo != null)
                {
                   await DownloadFile
                        (
                        botClient, message.Photo[message.Photo.Length - 1].FileId,
                        message.Photo[message.Photo.Length - 1].FileUniqueId + ".jpg"
                        );

                    FileHandling.Filling(message.Photo[message.Photo.Length - 1].FileUniqueId + ".jpg");

                    Console.WriteLine(message.Photo[message.Photo.Length - 1].FileUniqueId + ".jpg");

                    await botClient.SendTextMessageAsync(message.Chat, "Фото скачано");
                }

                // Скачивание видео
                else if (message.Video != null)
                {
                    await DownloadFile(botClient, message.Video.FileId,message.Video.FileName);

                    FileHandling.Filling(message.Video.FileName);

                    await botClient.SendTextMessageAsync(message.Chat, "Видео скачано");
                }

                // Скачивание аудио
                else if (message.Audio != null)
                {
                    await DownloadFile(botClient, message.Audio.FileId, message.Audio.FileName);

                    FileHandling.Filling (message.Audio.FileName);

                    await botClient.SendTextMessageAsync(message.Chat, "Аудио скачано");
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
