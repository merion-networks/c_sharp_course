namespace FileLibrary
{
    public class FileClass
    {

        public void ExampleFile()
        {
            //File
            //FileInfo;

            File.WriteAllText("example.txt", "Привет академия!");

            string content = File.ReadAllText("example.txt");

            Console.WriteLine(content);
        }


        public async void ExampleFileAsync()
        {
            //File
            //FileInfo;

            await File.WriteAllTextAsync("example.txt", "Привет академия!");

            string content = await File.ReadAllTextAsync("example.txt");

            Console.WriteLine(content);
        }

        public void ExampleFileInfo()
        {
            FileInfo fileInfo = new FileInfo("example.txt");
            long size = fileInfo.Length;
            DateTime dateTime = fileInfo.CreationTime;

            Console.WriteLine($"Размер - {size} , создан - {dateTime}");
        }

        public void ExampleDirectory()
        {
            Directory.CreateDirectory("NewFolder");

            string[] files = Directory.GetFiles("NewFolder");

            for (int i = 0; i < files.Count(); i++)
                Console.WriteLine(files[i]);

            DirectoryInfo directoryInfo = new DirectoryInfo("NewFolder");
            FileInfo[] filesInfo = directoryInfo.GetFiles();

            for (int i = 0; i < filesInfo.Count(); i++)
            {
                var file = filesInfo[i].Name;
                Console.WriteLine(file);
            }               
        }

        public void ExamplePath()
        {
            string fullPath = Path.Combine("Folder", "SubFolder", "file.txt");
            string extension = Path.GetExtension(fullPath);
        }

        public FileClass()
        {
            ExampleFile();
            ExampleFileInfo();
            ExampleDirectory();
            ExamplePath();
        }
    }
}
