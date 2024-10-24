using DeligateLibrary;

DelegateClass delegateClass = new DelegateClass();

EventsClass eventsClass = new EventsClass();
eventsClass.ProcessComplited += delegateClass.ShowMessage;

eventsClass.OnProcessComplited("Программа завершена!");
await delegateClass.ExampleDelegateAsync();

FileDownloader downloader = new FileDownloader();
downloader.DownloadComplited += Downloder_DownloadComplited;
downloader.Download("http://example.com/file.zip");

void Downloder_DownloadComplited(object? sender, FileDownloaderEventArgs e)
{
    Console.WriteLine($"Загрузка файла {e.FileName} с статусом {e.Message}");
}