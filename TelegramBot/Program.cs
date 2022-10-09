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

using Newtonsoft.Json;
using System;
using System.Net;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramBot
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем Телеграм бота
            Bot bot = new Bot();

            // Вывводим на консоль имя запущенного бота
            ConsoleOperation.ConsoleOutput($"Запущен бот {bot.TBot.GetMeAsync().Result.FirstName}");

            //Создаем обект управления и посылки уведомлений об отмене
            var cts = new CancellationTokenSource();

            // Получаем токен и передаем его в задачу, которая может быть отменена
            var cancellationToken = cts.Token;

            //Создаем параметры приема
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { },  // Получаем все обновления
            };

            // Получаем и обрабатываем сообщения
            bot.TBot.StartReceiving
                (
                Bot.HandleUpdateAsync,
                Bot.HandleErrorAsync,
                receiverOptions,
                cancellationToken
                );

            Console.ReadLine();
        }
    }
}
