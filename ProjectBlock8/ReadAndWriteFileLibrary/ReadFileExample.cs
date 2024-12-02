using Newtonsoft.Json;
using ReadAndWriteFileLibrary.Model;
using System.IO.Compression;

namespace ReadAndWriteFileLibrary
{
    public class ReadFileExample
    {

        public void DecompressFile(string sourceFilePath, string decompressFilePath)
        {
            try
            {
                using (FileStream fileStream = new FileStream(sourceFilePath, FileMode.Open))
                {
                    using (FileStream destinationStream = new FileStream(decompressFilePath, FileMode.Create))
                    {
                        using (GZipStream gZipStream = new GZipStream(fileStream, CompressionMode.Decompress))
                        {
                            gZipStream.CopyTo(destinationStream);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public byte[] ReadBinaryFile(string filePath)
        {
            try
            {
                using FileStream fileStream = new FileStream(filePath, FileMode.Open);
                {
                    using BinaryReader reader = new BinaryReader(fileStream);
                    {
                      return reader.ReadBytes((int)fileStream.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public Settings LoadSettings()
        {
            try
            {
                string settingsFilePath = Path.Combine("Files", "settings.json");
                if (File.Exists(settingsFilePath))
                {
                    string json = File.ReadAllText(settingsFilePath);
                    return JsonConvert.DeserializeObject<Settings>(json) ?? new Settings();
                }

                return new Settings();
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        public void ExampleMetrod()
        {
            try
            {
                string filePath = "Files\\fileData.txt";
                string contentFile = File.ReadAllText(filePath);
                string[] lines = File.ReadAllLines(filePath);

                Console.WriteLine(contentFile);

                Console.WriteLine("lines");
                foreach (var line in lines)
                {
                    Console.WriteLine(line);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
