using Microsoft.Win32;
using MyFourthProgram.Data.Controller;
using MyFourthProgram.Data.Enum;
using MyFourthProgram.Data.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace MyFourthProgram.UI.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        /// <summary>
        ///  Коллекция продуктов
        /// </summary>
        public ObservableCollection<Product> Products { get; set; }

        /// <summary>
        /// Представление для фильтрации и сортировки
        /// </summary>
        public ICollectionView ProductsView { get; private set; }

        ///Фильтрация
        private string? filterCategory;


        public string FilterCategory
        {
            get { return filterCategory ?? ""; }
            set { filterCategory = value; OnPropertyChanged(nameof(FilterCategory)); ProductsView.Refresh(); }
        }

        private decimal? minPrice;
        public decimal? MinPrice
        {
            get { return minPrice; }
            set { minPrice = value; OnPropertyChanged(nameof(MinPrice)); ProductsView.Refresh(); }
        }

        private decimal? maxPrice;
        public decimal? MaxPrice
        {
            get { return maxPrice; }
            set { maxPrice = value; OnPropertyChanged(nameof(MaxPrice)); ProductsView.Refresh(); }
        }

        private int? minQuantity;
        public int? MinQuantity
        {
            get { return minQuantity; }
            set { minQuantity = value; OnPropertyChanged(nameof(MinQuantity)); ProductsView.Refresh(); }
        }

        private DateTime? manufactureDate;
        public DateTime? ManufactureDate
        {
            get { return manufactureDate; }
            set { manufactureDate = value; OnPropertyChanged(nameof(ManufactureDate)); ProductsView.Refresh(); }
        }


        public IEnumerable<SortFieldEnum> SortFieldValues
        {
            get => Enum.GetValues(typeof(SortFieldEnum)).Cast<SortFieldEnum>();
        }

        private SortFieldEnum? sortField;
        public SortFieldEnum? SortField
        {
            get => sortField;
            set
            {
                sortField = value;
                OnPropertyChanged(nameof(SortField)); ApplySorting();
            }
        }

        public IEnumerable<ListSortDirection> SortDirectionValues
        {
            get => Enum.GetValues(typeof(ListSortDirection)).Cast<ListSortDirection>();
        }

        private ListSortDirection sortDirection;
        public ListSortDirection SortDirection
        {
            get => sortDirection;
            set
            {
                sortDirection = value; OnPropertyChanged(nameof(SortDirection)); ApplySorting();
            }
        }


        private void ApplySorting()
        {
            using (ProductsView.DeferRefresh())
            {
                ProductsView.SortDescriptions.Clear();
                if (SortField != null)
                {
                    ProductsView.SortDescriptions.Add(new SortDescription(SortField.ToString(), SortDirection));
                }
            }
        }

        /// <summary>
        /// Команды кнопок
        /// </summary>
        public ICommand LoadCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }


        public MainViewModel()
        {
            Products = new ObservableCollection<Product>();
            ProductsView = CollectionViewSource.GetDefaultView(Products);
            ProductsView.Filter = FilterProducts;

            LoadCommand = new RelayCommand(LoadData);
            SaveCommand = new RelayCommand(SaveData);

            sortDirection = ListSortDirection.Ascending;
        }

        private bool FilterProducts(object obj)
        {
            var product = obj as Product;
            if (product == null)
            {
                return false;
            }

            bool result = true;

            if (!string.IsNullOrEmpty(FilterCategory))
            {
                result &= product.Category != null && product.Category.IndexOf(FilterCategory, StringComparison.OrdinalIgnoreCase) >= 0;
            }

            if (MinPrice.HasValue)
            {
                result &= product.Price >= MinPrice.Value;
            }
            if (MaxPrice.HasValue)
            {
                result &= product.Price <= MaxPrice.Value;
            }
            if (MinQuantity.HasValue)
            {
                result &= product.Quantity >= MinQuantity.Value;
            }
            if (ManufactureDate.HasValue)
            {
                result &= product.ManufactureDate.Date >= ManufactureDate.Value.Date;
            }

            return result;
        }

        private void LoadData(object parameter)
        {
            try
            {
                // Открываем диалог для выбора файла
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "CSV Files (*.csv)|*.csv|XLS Files (*.xls)|*.xls|All Files (*.*)|*.*";
                if (dlg.ShowDialog() == true)
                {
                    string fileName = dlg.FileName;
                    ReadProductsFromFile(fileName);
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Ошибка при чтении файла: {ex.Message}");
            }
        }

        private void SaveData(object parameter)
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "CSV Files (*.csv)|*.csv|XLS Files (*.xls)|*.xls|All Files (*.*)|*.*";
                if (dlg.ShowDialog() == true)
                {
                    string fileName = dlg.FileName;
                    WriteProductsToFile(fileName);
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Ошибка при чтении файла: {ex.Message}");
            }
        }


        private void ReadProductsFromFile(string filePath)
        {

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Файл {filePath} не найден.");
            }
            try
            {
                ObservableCollection<Product> newProducts = new ObservableCollection<Product>();


                using (StreamReader streamReader = new StreamReader(filePath))
                {
                    string headerLine = streamReader.ReadLine();

                    string line;

                    while ((line = streamReader.ReadLine()) != null)
                    {
                        string[] parts = SplitCsvLine(line);


                        if (parts.Length >= 6)
                        {
                            Product product = new Product()
                            {
                                Id = int.Parse(parts[0]),
                                Name = parts[1],
                                Category = parts[2],
                                Price = decimal.TryParse(parts[3], out decimal result) ? result : 0.0M,
                                Quantity = int.Parse(parts[4]),
                                ManufactureDate = DateTime.Parse(parts[5]),
                            };

                            newProducts.Add(product);
                        }
                        else
                        {
                            throw new Exception("Данные не полные");
                        }
                    }

                    Products.Clear();
                    foreach (var product in newProducts)
                    {
                        Products.Add(product);
                    }

                    // Сбрасываем фильтры и сортировку
                    FilterCategory = null;
                    MinPrice = null;
                    MaxPrice = null;
                    MinQuantity = null;
                    ManufactureDate = null;

                    SortField = SortFieldEnum.Name;
                    SortDirection = ListSortDirection.Ascending;
                    ProductsView.Refresh();

                    System.Windows.MessageBox.Show("Данные успешно прочитаны.\n");

                }
            }
            catch (Exception ex)
            {
                throw;
            }
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

        private void WriteProductsToFile(string outputPath)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(outputPath, false, System.Text.Encoding.UTF8))
                {
                    sw.WriteLine($"{nameof(Product.Id)}, {nameof(Product.Name)}, {nameof(Product.Category)}, {nameof(Product.Price)}, {nameof(Product.Quantity)}, {nameof(Product.ManufactureDate)}");

                    foreach (Product product in ProductsView)
                    {
                        sw.WriteLine(product.ToString());
                    }
                }

                System.Windows.MessageBox.Show("Данные успешно сохранены.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при записи в файл: {ex.Message}");
            }

        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
