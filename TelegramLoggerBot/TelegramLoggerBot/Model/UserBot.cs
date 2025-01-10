using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramLoggerBot.Model
{
    public class UserBot
    {
        public int Id { get; set; }
        public long ChatId { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }

    }
}
