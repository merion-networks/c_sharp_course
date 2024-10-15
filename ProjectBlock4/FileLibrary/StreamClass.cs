using System.Net.Sockets;
using System.Security;
using System.Text;

namespace FileLibrary
{
    public class StreamClass
    {

        public void ExampleStreamReader()
        {
            using (StreamReader streamReader = new StreamReader("example.txt"))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }

        }

        public void ExampleStreamWriter()
        {
            using (StreamWriter streamWriter = new StreamWriter("example.txt"))
            {
                streamWriter.WriteLine("Первая строка");
                streamWriter.WriteLine("Вторая строка");
            }

        }

        public async void ExampleFileStreamAsync()
        {
            using (FileStream fs = new FileStream("example.txt", FileMode.Open, FileAccess.Read))
            {
                byte[] bytes = new byte[fs.Length];
                await fs.ReadAsync(bytes, 0, (int)fs.Length);
            }
        }

        public async Task<string> ReadFileAsync(string filename)
        {
            using (StreamReader streamReader = new StreamReader(filename))
            {
                return await streamReader.ReadToEndAsync();
            }
        }


        public void ExampleBufferedStream()
        {
            try
            {
                using (FileStream fileStream = new FileStream("example.txt", FileMode.OpenOrCreate))
                using (BufferedStream bufferedStream = new BufferedStream(fileStream, bufferSize: 8192))
                {
                    byte[] bufferBytes = new byte[2048];
                    int bytesRead = 0;
                    long totalBytesRead = 0;
                    while ((bytesRead = bufferedStream.Read(bufferBytes, 0, bufferBytes.Length)) > 0)
                    {
                        totalBytesRead += bytesRead;
                        ProcessData(bufferBytes, bytesRead);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Ошибка в I/O - {ex.Message}");
            }
            catch(UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (SecurityException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ProcessData(byte[] bufferBytes, int bytesRead)
        {
            //Выполняем какуюнибудь обработку или анализ данных
            int display = Math.Min(bytesRead, 10);
            Console.WriteLine("Данные");
            for (int i = 0; i < display; i++)
            {
                Console.Write($"{bufferBytes[i]:X2} - ");
            }
            Console.WriteLine();
        }

        public void Example()
        {
            using (FileStream fs = new FileStream("example.txt", FileMode.OpenOrCreate))
            {
                //Операции чтения запись
            }

            using (MemoryStream ms = new MemoryStream())
            {
                //Запись данных в память
            }


            using (NetworkStream ns = new NetworkStream(new Socket(AddressFamily.Packet, SocketType.Stream, ProtocolType.Tcp)))
            {
                //Используется с TcpClient и TcpListener
            }
        }
        public StreamClass() { }
    }
}
