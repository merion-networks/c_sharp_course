using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SerializerLibrary
{

    public class AppSettings
    {
        public string Theme { get; set; }
        public int FontSize { get; set; }
    }


    public class ExampleSaveSettings
    {
        private AppSettings settings = new AppSettings() { FontSize = 16, Theme = "Dark"};

        public ExampleSaveSettings() {

            string jsonString = JsonSerializer.Serialize(settings);
            File.WriteAllText("appsettings.json", jsonString);


            string jsonNewString = File.ReadAllText("appsettings.json");

            AppSettings newSettings = JsonSerializer.Deserialize<AppSettings>(jsonNewString);

        }
    }
}
