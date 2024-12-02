using MyFourthProgram.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFourthProgram.Data.Controller
{
    public class DataController
    {
        public IEnumerable<Product> SortProducts(IEnumerable<Product> filteredProduct)
        {
            IEnumerable<Product> sortedProducts = filteredProduct;

            Console.WriteLine("\nВыберите поле для сортировки:");
            Console.WriteLine("1 - Категория");
            Console.WriteLine("2 - Цена");
            Console.WriteLine("3 - Количество");
            Console.WriteLine("4 - Дата производства");
            Console.Write("Ваш выбор: ");
            string choice = Console.ReadLine();

            Console.WriteLine("\nВыберите порядок для сортировки (1 - по возрастанию, 2 - по убыванию):");
            string orderChoice = Console.ReadLine();
            while (!(orderChoice.Equals("1") || orderChoice.Equals("2")))
            {
                Console.WriteLine("Разрешено вводить только (1 - по возрастанию, 2 - по убыванию)! Повторить ввод: ");
                orderChoice = Console.ReadLine();
            }

            bool ascending = orderChoice == "1";

            switch (choice)
            {
                case "1":
                    sortedProducts = ascending ? sortedProducts.OrderBy(p => p.Category) : sortedProducts.OrderByDescending(p => p.Category);
                    ShowProduct(sortedProducts);
                    break;
                case "2":
                    sortedProducts = ascending ? sortedProducts.OrderBy(p => p.Price) : sortedProducts.OrderByDescending(p => p.Price);
                    ShowProduct(sortedProducts);
                    break;
                case "3":
                    sortedProducts = ascending ? sortedProducts.OrderBy(p => p.Quantity) : sortedProducts.OrderByDescending(p => p.Quantity);
                    ShowProduct(sortedProducts);
                    break;
                case "4":
                    sortedProducts = ascending ? sortedProducts.OrderBy(p => p.ManufactureDate) : sortedProducts.OrderByDescending(p => p.ManufactureDate);
                    ShowProduct(sortedProducts);
                    break;
                default:
                    Console.WriteLine("Не корректный выбор!");
                    break;
            }


            return filteredProduct;
        }

        public IEnumerable<Product> FilteredProducts(List<Product> products)
        {
            IEnumerable<Product> filteredProducts = products;

            Console.WriteLine("Хотите ли вы отфильтровать данные? (да/нет): ");
            var responce = Console.ReadLine().ToLower();

            while (responce == "да")
            {
                Console.WriteLine("\nВыберите поле для фильтрации:");
                Console.WriteLine("1 - Категория");
                Console.WriteLine("2 - Цена");
                Console.WriteLine("3 - Количество");
                Console.WriteLine("4 - Дата производства");
                Console.Write("Ваш выбор: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Введите категорию: ");
                        string category = Console.ReadLine();
                        filteredProducts = filteredProducts.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
                        ShowProduct(filteredProducts);
                        break;
                    case "2":
                        Console.WriteLine("Введите минимальную цену: ");
                        decimal minPrice = decimal.Parse(Console.ReadLine());

                        Console.WriteLine("Введите максимальную цену: ");
                        decimal maxPrice = decimal.Parse(Console.ReadLine());
                        filteredProducts = filteredProducts.Where(p => p.Price >= minPrice && p.Price <= maxPrice);
                        ShowProduct(filteredProducts);
                        break;
                    case "3":
                        Console.WriteLine("Введите минимально количество: ");
                        int minQuantity = int.Parse(Console.ReadLine());
                        filteredProducts = filteredProducts.Where(p => p.Quantity >= minQuantity);
                        ShowProduct(filteredProducts);
                        break;
                    case "4":
                        Console.WriteLine("Введите дату производства (дд.мм.гггг): ");
                        DateTime data = DateTime.Parse(Console.ReadLine());
                        filteredProducts = filteredProducts.Where(p => p.ManufactureDate.Equals(data));
                        ShowProduct(filteredProducts);
                        break;
                    default:
                        Console.WriteLine("Не корректный выбор!");
                        break;

                }

                Console.WriteLine("Хотите ли вы добавить еще критерий фильтрации данные? (да/нет): ");
                responce = Console.ReadLine().ToLower();
                while (!(responce.Equals("да") || responce.Equals("нет")))
                {
                    Console.WriteLine("Разрешено вводить только (да/нет)! Повторить ввод: ");
                    responce = Console.ReadLine().ToLower();
                }

            }

            return filteredProducts;
        }

        public void ShowProduct(IEnumerable<Product> products)
        {
            Console.WriteLine("==== Результат ===");
            Console.WriteLine($"{nameof(Product.Id)}, {nameof(Product.Name)}, {nameof(Product.Category)}, {nameof(Product.Price)}, {nameof(Product.Quantity)}, {nameof(Product.ManufactureDate)}");
            foreach (Product product in products)
            {
                Console.WriteLine(product.ToString());
            }
        }
    }
}
