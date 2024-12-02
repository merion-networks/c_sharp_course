using System.ComponentModel;

namespace MySixthProgram.UI.Models
{
    public class OperationModel : INotifyPropertyChanged
    {
        private int progress;
        private string status;

        public string Name { get; set; }

        public int Progress
        {
            get => progress;
            set
            {
                progress = value;
                OnPropertyChanged(nameof(Progress));
            }
        }

        public string Status {
            get => status;
            set
            {
                status = value;
                OnPropertyChanged(nameof(Status));
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
