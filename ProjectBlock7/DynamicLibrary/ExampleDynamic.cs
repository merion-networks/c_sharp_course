using IronPython.Hosting;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;
using Excel = Microsoft.Office.Interop.Excel;


namespace DynamicLibrary
{
    public class ExampleDynamic
    {

        public void ExampleCreateExcel()
        {
            dynamic excelApp = new Excel.Application();
            excelApp.Visible = true;
            dynamic workBook = excelApp.Workbooks.Add();
            dynamic sheet = workBook.ActiveSheet;

            sheet.Cells[1, 1] = "Название";
            sheet.Cells[1, 2] = "Значение";

            workBook.SaveAs("C:\\Users\\79191\\source\\repos\\MerionAcademy\\ProjectBlock7\\ProjectBlock7\\bin\\Debug\\net8.0\\exammple.xlxs");
            excelApp.Quit();
        }


        public void ExampleUsePython()
        {
            var engine = Python.CreateEngine();
            dynamic py = engine.ExecuteFile("script.py");


            dynamic result = py.Calculate(5,10);

            Console.WriteLine($"Результат - {result}");
        }

        public void ExampleJSON()
        {
            string jsonString = "{ \"name\": \"John\", \"age\": 30 }";

            dynamic person = JsonConvert.DeserializeObject<dynamic>(jsonString) ?? "Не получили объект!";


            if (person is string)
            {
                Console.WriteLine(person);
            }
            else
            {
                Console.WriteLine($"Имя: {person?.name}, Возраст: {person?.age}");
            }
        }

        public ExampleDynamic()
        {
            dynamic variable = "Приривет, Академия!";

            int length = variable.Length;

            //  var somthing = variable.DoWork();

            object obj = "Привет";
            length = ((string)obj).Length;
           
        }
    }
}
