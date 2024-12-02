using System.ComponentModel;

namespace MyFourthProgram.Data.Model
{
    public class Product : INotifyPropertyChanged
    {
        private int id;
        private string name;
        private string category;
        private decimal price;
        private int quantity;
        private DateTime manufactureDate;

        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }

        public string Category
        {
            get { return category; }
            set { category = value; OnPropertyChanged("Category"); }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; OnPropertyChanged("Price"); }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; OnPropertyChanged("Quantity"); }
        }

        public DateTime ManufactureDate
        {
            get { return manufactureDate; }
            set { manufactureDate = value; OnPropertyChanged("ManufactureDate"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }



        public override string ToString()
        {
            return $"{Id}, {Name}, {Category}, {Price}, {Quantity}, {ManufactureDate.ToShortDateString()}";
        }
    }
}
