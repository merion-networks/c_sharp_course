using Microsoft.Data.Sqlite;
using TelegramLoggerBot.Model;

namespace TelegramLoggerBot.Helpers
{
    public class DbHelper
    {
        private string dbPath = "UsersBot.db";

        public DbHelper()
        {
            InitializeDatabase();
        }
        private void InitializeDatabase()
        {
            if (!System.IO.File.Exists(dbPath))
            {
                System.IO.File.WriteAllBytes(dbPath, new byte[0]);
            }

            using (var connection = new SqliteConnection($"Data Source={dbPath}"))
            {
                connection.Open();
                string sql = "CREATE TABLE IF NOT EXISTS UsersBot(" +
                    "Id INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "ChatId INTEGER NOT NULL," +
                    "Name TEXT," +
                    "Role TEXT)";

                using (var command = new SqliteCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        public List<UserBot> GetAllUsersBot()
        {
            var usersBot = new List<UserBot>();
            using (var connection = new SqliteConnection($"Data Source={dbPath};"))
            {
                connection.Open();
                string sql = "SELECT Id, ChatId, Name, Role FROM UsersBot";
                using (var command = new SqliteCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var userBot = new UserBot()
                            {
                                Id = reader.GetInt32(0),
                                ChatId = reader.GetInt64(1),
                                Name = reader.GetString(2),
                                Role = reader.GetString(3)
                            };
                            usersBot.Add(userBot);

                        }

                    }
                }
            }

            return usersBot;
        }
        public void RemoveUserBot(long chatId)
        {
            using (var connection = new SqliteConnection($"Data Source={dbPath};"))
            {
                connection.Open();
                string sql = "DELETE FROM UsersBot WHERE ChatId = @ChatId";
                using (var command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ChatId", chatId);
                    command.ExecuteNonQuery();
                }
            }
        }
        public object GetUserBotByChatId(long chatId, string username)
        {
            // Проверяем, что chatId больше нуля
            if (chatId <= 0)
            {
                throw new ArgumentException("Недопустимый идентификатор чата.");
            }

            using (var connection = new SqliteConnection($"Data Source={dbPath};"))
            {
                connection.Open();
                string sql = "SELECT Id, ChatId, Name, Role FROM UsersBot WHERE ChatId = @ChatId AND Name = @Name";
                using (var command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ChatId", chatId); 
                    command.Parameters.AddWithValue("@Name", username); 
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var userBot = new UserBot
                            {
                                Id = reader.GetInt32(0),
                                ChatId = reader.GetInt64(1),
                                Name = reader.GetString(2),
                                Role = reader.GetString(3)
                            };
                            return userBot;
                        }
                    }
                }
            }
            return null;
        }
        

        internal void AddUserBot(UserBot newUser)
        {
            using (var connection = new SqliteConnection($"Data Source={dbPath};"))
            {
                connection.Open();
                string sql = "INSERT INTO UsersBot (ChatId, Name, Role) VALUES (@ChatId, @Name, @Role)";
                using (var command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ChatId", newUser.ChatId);
                    command.Parameters.AddWithValue("@Name", newUser.Name ?? "");
                    command.Parameters.AddWithValue("@Role", newUser.Role ?? "");
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
