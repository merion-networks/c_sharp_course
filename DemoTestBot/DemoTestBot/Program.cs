using NLog;
using TelegramLoggerBot;
using TelegramLoggerBot.Helpers;

Logger logger = LogManager.GetCurrentClassLogger();

var botToken = "NzIwMDkxMTk1NzpBQUYxUXV0eVMtVklfa1cyVlJPcHNGdzhGbmFLS3NxcFFmdw==";
var botService = new BotService(botToken);
await botService.StartAsync();
Console.ReadKey();

for (int i = 0; i < 10; i++)
{
    logger.Info(i.ToString());
}

Console.WriteLine("Бот запущен. Нажмите любую кнопку для выхода.");
Console.ReadKey();
