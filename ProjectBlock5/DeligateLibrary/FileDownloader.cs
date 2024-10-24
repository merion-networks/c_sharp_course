namespace DeligateLibrary
{
    public class FileDownloader
    {
        public event EventHandler<FileDownloaderEventArgs> DownloadComplited;

        public void Download(string url)
        {
            //Логика загрузки
            string fileName = "example.txt"; //Получено из логики загрузки или можно так Path.GetFileName(url);
            OnDownloadComplite(fileName);
        }

        protected virtual void OnDownloadComplite(string fileName)
        {
            DownloadComplited?.Invoke(this, new FileDownloaderEventArgs("Сообщение", fileName));
        }
    }
}
