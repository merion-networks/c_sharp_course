using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlock6
{
    public class SynchronicClass
    {

        void LoadData()
        {
            var data = GetDataServer();

            UpdateUI(data);
        }

        private void UpdateUI(string data)
        {
            Thread.Sleep(2000);
        }

        private string GetDataServer()
        {
            Console.WriteLine("Подготовка данных.");
            Thread.Sleep(10000);
            return "Данные получены";
        }

        public void Example()
        {
            LoadData();
        }
    }
}
