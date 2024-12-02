using ProjectBlock8.ExampleCustumException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlock8.ExampleException
{
    public class ExampleFileException
    {

        public void ExampleMetod()
        {
            try
            {
                
                string filePath = "data.txt";
                throw new FileProcessingException(filePath, "Произошла выдуманая ошибка");
                string fileContent = File.ReadAllText(filePath);

                Console.WriteLine(fileContent);
            }
            catch (FileProcessingException ex)
            {
                Console.WriteLine("Ошибка: В процессе файла!");
                Console.WriteLine($"{ex.FilePath}, {ex.Message}");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Ошибка: Файл не найден!");
                Console.WriteLine(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Ошибка: Нет доступа к файлу!");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка при чтении файла!");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Блок finally выполнен. Операция чтения файла завершена.");
            }
        }
    }
}
