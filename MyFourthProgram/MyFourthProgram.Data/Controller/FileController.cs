using MyFourthProgram.Data.Model;
using System.Globalization;


namespace MyFourthProgram.Data.Controller
{
    public class FileController
    {
        public List<Product> ReadProductsFromFile()
        {
            List<Product> products = new List<Product>();

            Console.Write("Введите путь к файлу с данными о продуктах: ");
            string? filePath = Console.ReadLine();
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Файл {filePath} не найден.");
            }
            try
            {
                using (StreamReader streamReader = new StreamReader(filePath))
                {
                    string headerLine = streamReader.ReadLine();

                    string line;

                    while ((line = streamReader.ReadLine()) != null)
                    {
                        string[] parts = SplitCsvLine(line);
                        string[] partsSplit = line.Split(",");


                        if (parts.Length >= 6)
                        {
                            Product product = new Product()
                            {
                                Id = int.Parse(parts[0]),
                                Name = parts[1],
                                Category = parts[2],
                                Price = decimal.Parse(parts[3], CultureInfo.InvariantCulture),
                                Quantity = int.Parse(parts[4]),
                                ManufactureDate = DateTime.Parse(parts[5]),
                            };

                            products.Add(product);
                        }
                        else
                        {
                            throw new Exception("Данные не полные");  
                        }
                    }

                    Console.WriteLine("Данные успешно прочитаны.\n");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
                throw;
            }


            return products;
        }

        private string[] SplitCsvLine(string line)
        {
            var result = new List<string>();
            bool inQuotes = false;

            string value = string.Empty;

            foreach (var c in line)
            {
                if (c == '"' && inQuotes)
                {
                    inQuotes = false;
                }
                else if (c == '"' && !inQuotes)
                {
                    inQuotes = true;
                }
                else if (c == ',' && !inQuotes)
                {
                    result.Add(value);
                    value = string.Empty;
                }
                else
                {
                    value += c;
                }
            }
            result.Add(value);

            return result.ToArray();
        }

        public void WriteProductsToFile(IEnumerable<Product> sortedProducts)
        {
            Console.Write("\nВведите путь и имя выходного файла: ");
            string outputPath = Console.ReadLine();

            try
            {
                using (StreamWriter sw = new StreamWriter(outputPath, false, System.Text.Encoding.UTF8))
                {
                    sw.WriteLine($"{nameof(Product.Id)}, {nameof(Product.Name)}, {nameof(Product.Category)}, {nameof(Product.Price)}, {nameof(Product.Quantity)}, {nameof(Product.ManufactureDate)}");

                    foreach (Product product in sortedProducts)
                    {
                        sw.WriteLine(product.ToString());
                    }
                }

                Console.WriteLine("Данные успешно записаны в файл.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при записи в файл: {ex.Message}");
            }

        }


    }
}
