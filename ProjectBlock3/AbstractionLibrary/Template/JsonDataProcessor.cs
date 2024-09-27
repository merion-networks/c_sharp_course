using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionLibrary.Template
{
    public class JsonDataProcessor : DataProcessor
    {
        protected override void ProcessData(string data)
        {
            // Реализация обработки JSON данных
        }

        protected override void ReadData(string data)
        {
            // Реализация чтения JSON данных
        }

        protected override void WriteData(string data)
        {
            // Реализация записи JSON данных
        }
    }
}
