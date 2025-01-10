using NLog;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using TelegramLoggerBot.Model;
using Microsoft.Data.Sqlite;
using TelegramLoggerBot.Helpers;

namespace TelegramLoggerBot
{
    [Target("TelegramTarget")]
    public class TelegramTarget : TargetWithLayout
    {
        private readonly ITelegramBotClient telegramBotClient;
        public DbHelper DbHelper { get; }
        public TelegramTarget(ITelegramBotClient telegramBotClient, DbHelper dbHelper)
        {
            this.telegramBotClient = telegramBotClient;
            DbHelper = dbHelper;
        }


        protected override void Write(LogEventInfo logEvent)
        {
            try
            {
                var logMessage = this.Layout.Render(logEvent);
                var usersBot = DbHelper.GetAllUsersBot();
                foreach (var userBot in usersBot)
                {
                    telegramBotClient.SendMessage(
                        chatId: userBot.ChatId,
                        text: $"<pre>{logMessage}</pre>",
                        parseMode: ParseMode.Html,
                        cancellationToken: CancellationToken.None
                        ).GetAwaiter().GetResult();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
