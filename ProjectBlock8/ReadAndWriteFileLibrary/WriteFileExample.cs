using Newtonsoft.Json;
using ReadAndWriteFileLibrary.Model;
using System.IO.Compression;

namespace ReadAndWriteFileLibrary
{
    public class WriteFileExample
    {
        public void CompressFile(string sourceFilePath, string compressFilePath)
        {
            try
            {
                using (FileStream fileStream = new FileStream(sourceFilePath, FileMode.Open))
                {
                    using (FileStream destinationStream = new FileStream(compressFilePath, FileMode.Create))
                    {
                        using (GZipStream gZipStream = new GZipStream(destinationStream, CompressionMode.Compress))
                        {
                            fileStream.CopyTo(gZipStream);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void WriteBinaryFile(string filePath, byte[] data)
        {
            try
            {
                using FileStream fileStream = new FileStream(filePath, FileMode.Create);
                {
                    using BinaryWriter writer = new BinaryWriter(fileStream);
                    {
                        writer.Write(data);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void ExportDataToCsv(List<Customer> customers)
        {
            try
            {
                string csvPath = Path.Combine("Files", "customers.csv");
                using (StreamWriter sw = new StreamWriter(csvPath))
                {
                    sw.WriteLine("ID,Name,Emeil");

                    foreach (Customer customer in customers)
                    {
                        var line = $"{customer.Id},{customer.Name},{customer.Email}";
                        sw.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void SaveSettings(Settings settings)
        {
            try
            {
                string settingsPath = Path.Combine("Files", "settings.json");
                string json = JsonConvert.SerializeObject(settings);
                File.WriteAllText(settingsPath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ExampleMetrod()
        {
            try
            {
                string filePath = "Files\\fileData.txt";
                string contentFile = "Новые значения для работы с файлом!\n";
                File.WriteAllText(filePath, contentFile);

                string[] strings = { "Строка 1", "Строка 2", "Строка 3" };
                File.AppendAllLines(filePath, strings);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
