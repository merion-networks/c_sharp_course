using Microsoft.Data.Sqlite;
using NLog;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using TelegramLoggerBot.Helpers;
using TelegramLoggerBot.Model;
using Telegram.Bot.Types.ReplyMarkups;
using static System.Net.Mime.MediaTypeNames;
using NLog.Fluent;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Threading;
using Update = Telegram.Bot.Types.Update;
using Telegram.Bot.Types.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TelegramLoggerBot
{
    public class BotService
    {

        private DbHelper dbHelper;

        protected DbHelper DbHelper
        {
            get
            {
                if (dbHelper == null)
                {
                    return dbHelper = new DbHelper();
                }
                return dbHelper;
            }
        }

        private static Logger logger;
        private readonly ITelegramBotClient telegramBotClient;
        private static readonly Encoding Utf8Encoder = UTF8Encoding.GetEncoding("UTF-8", new EncoderReplacementFallback(string.Empty), new DecoderExceptionFallback());

        private int countLog;


        public BotService(string token)
        {
            telegramBotClient = new TelegramBotClient(StringHelper.Base64Decode(token));
            ConfigureNLog();
            logger.Info("Бот успешно инициализирован.");
        }



        private void ConfigureNLog()
        {
            // Настройка NLog
            var config = new NLog.Config.LoggingConfiguration();
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = $"logs/log-{DateTime.Now.ToString("dd/MM/yyyy")}.log" };
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");
            // Telegram цель (изначально отключена, пока dbPath не будет установлен)
            var telegramTarget = new TelegramTarget(telegramBotClient, DbHelper)
            {
                Name = "telegram",
                Layout = "${longdate}|${level:uppercase=true}|${logger}|${message}"
            };

            // Добавляем цели в конфигурацию
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logfile);
            config.AddRule(LogLevel.Info, LogLevel.Fatal, telegramTarget);
            // Применяем конфигурацию
            LogManager.Configuration = config;
            logger = LogManager.GetCurrentClassLogger();
        }

        public async Task StartAsync(CancellationToken cancellationToken = default)
        {
            var me = await telegramBotClient.GetMe(cancellationToken);
            Console.WriteLine($"Запущен бот @{me.Username}");
            logger.Info($"Запущен бот @{me.Username}");

            telegramBotClient.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions: null,
                cancellationToken: cancellationToken);

            Console.WriteLine($"Начато получение сообщений");
            logger.Info($"Начато получение сообщений");
        }

        private async Task HandleErrorAsync(ITelegramBotClient client, Exception exception, HandleErrorSource source, CancellationToken cancellationToken)
        {
            logger.Error(exception, "Произошла ошибка в Telegram боте.");
            var errorMessage = $"Произошла ошибка:\n{exception.Message}\n{exception.StackTrace}";

            var usersBot = DbHelper.GetAllUsersBot();
            foreach (var user in usersBot)
            {
                await telegramBotClient.SendMessage(
                          chatId: user.ChatId,
                          text: errorMessage,
                          cancellationToken: cancellationToken
                          );
            }


            await Task.CompletedTask;
        }

        private async Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
        {
            try
            {

                switch (update.Type)
                {
                    case UpdateType.Message:

                        if (update?.Message is not null)
                        {
                            var message = update.Message;
                            Console.WriteLine($"Получено сообщение от {message.From.Username}: {message.Text}");
                            logger.Info($"Получено сообщение от {message.From.Username}: {message.Text}");
                            if (message.Text.StartsWith("/"))
                            {
                                await HandleCommandAsync(telegramBotClient, message, cancellationToken, UpdateType.Message);
                            }
                            else
                            {
                                await telegramBotClient.SendMessage(
                                    chatId: message.Chat.Id,
                                    text: "Извините, я не понимаю эту команду. Введите /help для списка доступных команд.",
                                    cancellationToken: cancellationToken
                                    );
                            }
                        }                      
                        break;
                    case UpdateType.CallbackQuery:
                        Console.WriteLine($"Получено сообщение от {update.CallbackQuery.From.Username}: {update.CallbackQuery.Data}");
                        logger.Info($"Получено сообщение от {update.CallbackQuery.From.Username}: {update.CallbackQuery.Data}");
                        if (update.CallbackQuery.Data.StartsWith("/"))
                        {
                            await HandleCommandAsync(telegramBotClient, update.CallbackQuery.Message, cancellationToken, UpdateType.CallbackQuery, update.CallbackQuery.Data);
                        }
                        break;


                    default:
                        logger.Error("Ошибка в работе бота! Не работает получение сообщения. Не обработанный тип запроса!");
                        break;


                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, "Ошибка в работе бота!");
            }
        }


        
        private async Task HandleCommandAsync(ITelegramBotClient telegramBotClient, Message message, CancellationToken cancellationToken, UpdateType callbackQuery, string CallbackQueryData = null)
        {

            var command = callbackQuery == UpdateType.Message ? message.Text.Split(' ')[0] : CallbackQueryData;

            if (command.Split(' ').Length > 1 && command.Contains("/log")) { countLog = int.Parse(command.Split(' ')[1]); }


            switch (command)
            {
                case "/start":
                    await HandleStartCommandAsync(message, cancellationToken);
                    break;
                case "/help":
                    await HandleHelpCommandAsync(message, cancellationToken);
                    break;
                case "/log":
                    await HandleLogCommandAsync(message, cancellationToken);

                    break;
                case "/logerror":
                    byte[] bytesEroro = Encoding.Default.GetBytes(GetLatestLog(10, LogLevel.Error));
                    var logErrors = Utf8Encoder.GetString(bytesEroro);
                    await telegramBotClient.SendMessage(
                        chatId: message.Chat.Id,
                        text: logErrors,
                        cancellationToken: cancellationToken
                        );
                    break;
                case "/loginfo":
                    byte[] bytes = Encoding.Default.GetBytes(GetLatestLog(10, LogLevel.Info));
                    var logInfo = Utf8Encoder.GetString(bytes);
                    await telegramBotClient.SendMessage(
                        chatId: message.Chat.Id,
                        text: logInfo,
                        cancellationToken: cancellationToken
                        );
                    break;
                case "/logsubscribe":
                    await SubscribeToLogsAsync(message.Chat.Id, callbackQuery == UpdateType.Message ? message.From.Username : message.Chat.Username, cancellationToken: cancellationToken);
                    break;
                case "/logunsubscribe":
                    await UnSubscribeToLogsAsync(message.Chat.Id, callbackQuery == UpdateType.Message ? message.From.Username : message.Chat.Username, cancellationToken: cancellationToken);
                    break;
                default:
                    await telegramBotClient.SendMessage(
                            chatId: message.Chat.Id,
                            text: "Неизвестная команда. Введите /help для списка доступных команд.",
                            cancellationToken: cancellationToken
                            );
                    break;
            }
        }

        private async Task HandleLogCommandAsync(Message message, CancellationToken cancellationToken)
        {
            var buttons = new InlineKeyboardMarkup(new[]
         {
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Критичные записи", "/logerror"),
                    InlineKeyboardButton.WithCallbackData("Информационный записи", "/loginfo")
                }
            });
            byte[] bytes = Encoding.Default.GetBytes(GetLatestLog(10));
            var logs = Utf8Encoder.GetString(bytes);
            await telegramBotClient.SendMessage(
                chatId: message.Chat.Id,
                text: logs,
                replyMarkup: buttons,
                cancellationToken: cancellationToken
                );
        }

        private async Task HandleHelpCommandAsync(Message message, CancellationToken cancellationToken)
        {

            var helpText = "Выберите одну из следующих команд:";


            var row = new[]
                 {
                    InlineKeyboardButton.WithCallbackData("Критичные записи", "/logerror"),
                    InlineKeyboardButton.WithCallbackData("Информационный записи", "/loginfo")
                };
            var row2 = new[]
                {
                    InlineKeyboardButton.WithCallbackData("Подписаться на логи", "/logsubscribe"),
                    InlineKeyboardButton.WithCallbackData("Отписаться от логов", "/logunsubscribe")
                };

            var buttons = new InlineKeyboardButton[][] { row, row2 };


            InlineKeyboardMarkup inline = new InlineKeyboardMarkup(buttons);





            await SendMessage(
                       chatId: message.Chat.Id,
                       text: helpText,
                       replyMarkup: inline,
                       cancellationToken: cancellationToken
                       );


        }

        private async Task HandleStartCommandAsync(Message message, CancellationToken cancellationToken)
        {
            var welcomeText = "Добро пожаловать! Я бот, готовый помочь вам.";
            await SendMessageWithButtonsAsync(message.Chat.Id, welcomeText, cancellationToken);
        }

        private async Task SendMessageWithButtonsAsync(long chatId, string text, CancellationToken cancellationToken)
        {
            var buttons = new InlineKeyboardMarkup(new[]
            {
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Помощь", "/help"),
                    InlineKeyboardButton.WithCallbackData("Получить логи", "/log")
                }
            });

            await SendMessage(
                       chatId: chatId,
                       text: text,
                       replyMarkup: buttons,
                       cancellationToken: cancellationToken
                       );
        }
        private async Task SubscribeToLogsAsync(long chatId, string username, CancellationToken cancellationToken)
        {
            var userId = DbHelper.GetUserBotByChatId(chatId, username);

            if (userId == null)
            {
                var newUser = new UserBot()
                {
                    ChatId = chatId,
                    Name = username ?? "User",
                    Role = "Subscriber"
                };

                DbHelper.AddUserBot(newUser);

                AddTeledramLogTarget();
                await SendMessage(
                    chatId: chatId,
                    replyMarkup: null,
                    text: "Вы успешно подписались на получение логов.",
                    cancellationToken: cancellationToken
                  );
                logger.Info($"Пользователь {username} подписался на логи.");


            }
            else
            {
                await SendMessage(
                     chatId: chatId,
                     replyMarkup: null,
                     text: "Подписка на логи уже активирована.",
                     cancellationToken: cancellationToken);
            }
        }

        private void AddTeledramLogTarget()
        {
            var config = LogManager.Configuration;

            if (!config.AllTargets.Any(t => t.Name == "telegram"))
            {
                // Настраиваем TelegramTarget с полученным adminChatId
                var telegramTarget = new TelegramTarget(telegramBotClient, dbHelper)
                {
                    Layout = "${longdate}|${level:uppercase=true}|${logger}|${message}"
                };

                config.AddRule(LogLevel.Info, LogLevel.Fatal, telegramTarget);
                LogManager.ReconfigExistingLoggers();
            }

        }

        private void RemoveTeledramLogTarget()
        {
            var config = LogManager.Configuration;
            var telegramTarget = config.FindTargetByName("telegram");

            if (telegramTarget != null)
            {
                config.RemoveTarget("telegram");
                var rulesToRemove = config.LoggingRules.Where(r => r.Targets.Contains(telegramTarget)).ToList();

                foreach (var rule in rulesToRemove)
                {
                    config.LoggingRules.Remove(rule);
                }

                LogManager.ReconfigExistingLoggers();
            }

        }

        private async Task UnSubscribeToLogsAsync(long chatId, string username, CancellationToken cancellationToken)
        {
            var user = DbHelper.GetUserBotByChatId(chatId, username);
            if (user != null)
            {
                RemoveTeledramLogTarget();
                DbHelper.RemoveUserBot(chatId);
                await SendMessage(chatId, "Вы отписались от получения логов.", cancellationToken, null);
            }
            else
            {
                await SendMessage(
                     chatId: chatId,
                     replyMarkup: null,
                     text: "Вы не подписаны на логи.",
                     cancellationToken: cancellationToken);
            }
        }
        private async Task SendMessage(long chatId, string text, CancellationToken cancellationToken, InlineKeyboardMarkup replyMarkup)
        {
            try
            {
                await telegramBotClient.SendMessage(
                          chatId: chatId,
                          text: text,
                          replyMarkup: replyMarkup,
                          cancellationToken: cancellationToken
                          );
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Не удалось отправить сообщение.");
            }

        }



        private string GetLatestLog(int count, LogLevel level = null)
        {


            string tempFilePath = Path.GetTempFileName();
            try
            {
                string logFilePath = FileHelper.GetLatestFile("logs");
                if (System.IO.File.Exists(logFilePath))
                {
                    System.IO.File.Copy(logFilePath, tempFilePath, overwrite: true);
                    var lines = System.IO.File.ReadLines(tempFilePath, Encoding.UTF8)
                        .Where(line => level == null || line.Contains($"|{level.Name.ToUpper()}|"))
                        .Reverse()
                        .Take(count)
                        .Reverse();

                    byte[] bytes = Encoding.Default.GetBytes(string.Join(Environment.NewLine, lines));
                    var logs = Utf8Encoder.GetString(bytes);
                    return logs;
                }
                else
                {
                    return "Файл логов не найден.";
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка при чтении логов.");
                return "Ошибка при получении логов.";
            }
            finally
            {
                if (System.IO.File.Exists(tempFilePath))
                {
                    System.IO.File.Delete(tempFilePath);
                }
            }
        }
    }
}
