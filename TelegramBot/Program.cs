﻿/*
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
        static void Main(string[] args)
        {
            TelegramBot.Menu();
        }
    }
}
