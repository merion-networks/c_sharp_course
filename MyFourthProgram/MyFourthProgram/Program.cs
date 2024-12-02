using MyFourthProgram.Data.Controller;
using MyFourthProgram.Data.Model;
using System;
using System.Xml.Linq;

Console.WriteLine("=== Программа для работы с продуктами ===\n");

try
{
    FileController fileController = new FileController();
    DataController dataController = new DataController();
    List<Product> products = fileController.ReadProductsFromFile();

    if (products == null || products.Count == 0)
    {
        Console.WriteLine("Нет данных для обработки.");
    }
    else
    {

        dataController.ShowProduct(products);
        //Фильрация данных

        var filteredProduct = dataController.FilteredProducts(products);

        if (filteredProduct == null || !filteredProduct.Any())
        {
            Console.WriteLine("По заданным критериям нет результата.");
        }
        else
        {
            //Сортировка данных
            var sortedProducts = dataController.SortProducts(filteredProduct);

            //Запись данных в файл
            fileController.WriteProductsToFile(sortedProducts);

            Console.WriteLine("\nОбработка данных завершена. Нажмите любую клавишу для выхода.");
            Console.ReadKey();
        }

    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}





