namespace ReadAndWriteFileLibrary.Model
{
    public class Settings
    {
        public string ThemeName { get; set; }
        public string ThemePath { get; set; }
        public int FontSize {  get; set; }
        public bool ShowNotification {  get; set; }
        public bool ShowIcon { get; set; }
        public string Language { get; set; }
        public DateTime LastBackupDate { get; set; }
    }
}
