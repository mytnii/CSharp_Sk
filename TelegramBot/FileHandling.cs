using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static async Task FillingAsync(string fileName)
        {
            FileStream fileStram = new FileStream("uploadedFiles.txt", FileMode.Append);
            await fileStram.WriteAsync(Encoding.UTF8.GetBytes(fileName));

            fileStram.Close();
        }
     
        #endregion
    }
}
