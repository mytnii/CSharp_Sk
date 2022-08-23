/*
 * Создайте бота для одной из следующих платформ:

Twitch,
Discord,
Telegram.


Бот обладает следующим набором функций:

Принимает сообщения и команды от пользователя.
Сохраняет аудиосообщения, картинки и произвольные файлы.
Позволяет пользователю просмотреть список загруженных файлов.
Позволяет скачать выбранный файл.


Команды можно делать разные, но среди них должна присутствовать команда /start.



Вы можете сделать бота на любую тематику. 
Например, ваш бот может искать видео на YouTube, 
выводить курс криптовалют, отображать данные о погоде и так далее.
 */

using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Text;
using System.Linq;
using Telegram.Bot;
using System.Net.Http;

namespace TelegramBot
{
    class Program
    {
        static TelegramBotClient bot;
        static void Main(string[] args)
        {
            string token = File.ReadAllText(@"C:\Test\token.txt");
            string tokenYandex = File.ReadAllText(@"C:\Test\yandex_ru.txt");

            Console.WriteLine(token);

            WebClient webClient = new WebClient() { Encoding = Encoding.UTF8 };

            int update_id = 0;
            string startUrl = $@"https://api.telegram.org/bot{token}/";
            string yandexStartUrl = 
                @"https://dictionary.yandex.net/api/v1/dicservice.json/";

            Console.WriteLine(startUrl);

            while (true)
            {
                string url = $"{startUrl}getUpdates?offset={update_id}";
                var r = webClient.DownloadString(url);

                var msgs = JObject.Parse(r)["result"].ToArray();

                

                foreach (dynamic msg in msgs)
                {
                    Console.WriteLine(msg);
                    update_id = Convert.ToInt32(msg.update_id) + 1;

                    string userMessage = msg.message.text;
                    string userId = msg.message.chat.id;
                    string userFirstName = msg.message.from.first_name;

                    string text = $"{userFirstName} {userId} {userMessage}";
                    string responseText;

                    if (msg.message.document != null)
                    {
                        Console.WriteLine(text);

                        responseText = "Не шли мне текстовые файлы";
                        url = $"{startUrl}sendMessage?chat_id={userId}&text={responseText}";
                        webClient.DownloadString(url);

                    }
                    else if (msg.message.forward_from_chat != null)
                    {
                        responseText = "Зачем ты мне это переслал";
                        url = $"{startUrl}sendMessage?chat_id={userId}&text={responseText}";
                        webClient.DownloadString(url);
                    }
                    else if (userMessage == "/Привет")
                    {
                        responseText = $"Привет {userFirstName}, Что - то хотели";
                        url = $"{startUrl}sendMessage?chat_id={userId}&text={responseText}";
                        webClient.DownloadString(url);
                        while (true)
                        {
                            url = $"{startUrl}getUpdates?offset={update_id}";
                            r =webClient.DownloadString(url);
                            Console.WriteLine(r);
                            Console.ReadLine();

                            msgs = JObject.Parse(r)["result"].ToArray();

                            foreach (dynamic ms in msgs)
                            {
                                userMessage = ms.message.text;
                                userId = ms.message.chat.id;
                                userFirstName = ms.message.from.first_name;

                                if(userMessage == "/Перевод")
                                {
                                    url = $"{yandexStartUrl}getLangs?key={tokenYandex}";
                                    r = webClient.DownloadString(url);

                                    responseText = $"{r}";
                                    url = $"{startUrl}sendMessage?chat_id={userId}&text={responseText}";
                                    webClient.DownloadString(url);

                                    msgs = JObject.Parse(r)[","].ToArray() ;

                                    Console.WriteLine(msgs);

                                    Console.ReadLine();
                                }
                            }
                        }
                    }
                    else
                    {
                        //responseText = userMessage;
                        //Console.WriteLine(responseText);
                        //url = $"{startUrl}sendMessage?chat_id={userId}&text={responseText}";
                        //webClient.DownloadString(url);
                    }
                }


                Thread.Sleep(100);
            }

        }

    }
}
