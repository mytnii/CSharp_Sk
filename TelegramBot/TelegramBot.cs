using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Telegram.Bot;
using System.Text;

namespace TelegramBot
{
    internal class TelegramBot
    {
        #region Поля
        private string _token;         // Ключ доступа
        private string _startUrl;      // Стартовый URL    
        private int _update_id;
        

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчянию
        /// </summary>
        public TelegramBot()
        {
            this._token = File.ReadAllText(@"C:\Test\token.txt");
            this._startUrl = $@"https://api.telegram.org/bot{_token}/";
            this._update_id = 0;
        }
        #endregion

        #region Методы

        /// <summary>
        /// Чтение данных согласно методу
        /// </summary>
        /// <param name="webClient">Web поток</param>
        /// <param name="metod">Название метода</param>
        /// <returns></returns>
        public  string TelegramBotMetod(ref WebClient webClient, ref string metod)
        {
            string url = $"{this._startUrl}{metod}?offset={this._update_id}";
            string r = webClient.DownloadString(url);
            return r;
        }

        /// <summary>
        /// Парсинг данных
        /// </summary>
        /// <param name="str">Строка с данными</param>
        /// <returns></returns>
        public  JToken[] DataParsing(string str)
        {
            var msgs = JObject.Parse(str)["result"].ToArray();

            return msgs;
        }
        #endregion
    }
}
