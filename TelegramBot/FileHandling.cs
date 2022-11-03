using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot
{
    internal class FileHandling
    {
        /// <summary>
        /// Запись в файл
        /// </summary>
        /// <param name="fileName">Название скачаного файла</param>
        /// <returns></returns>
        #region Методы
        public static void Filling(string fileName)
        {
            FileStream fileStram = new FileStream("uploadedFiles.txt", FileMode.Append);

            StreamWriter streamWriter = new StreamWriter(fileStram);

            streamWriter.WriteLine($"{fileName}#");

            streamWriter.Close();
        }

        public static async Task FileReading(ITelegramBotClient botClient, Update message)
        {
            FileStream filestream = new FileStream("uploadedFiles.txt", FileMode.Open);
            StreamReader streamReader = new StreamReader(filestream);
            string line = "";
            while (streamReader.ReadLine != null)
            {
                line = streamReader.ReadToEnd();
                await botClient.SendTextMessageAsync(message.Message.Chat, line);
            }
        }
        #endregion
    }
}
