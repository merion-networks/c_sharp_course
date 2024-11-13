namespace ExtensionMethodsLibrary.Helpers
{
    public static class FileInfoExtensions
    {
        public static void CopyToDirectory(this FileInfo fileInfo, string destinationDirectory, bool overwrite = false)
        {
            try
            {
                string destinationPath = Path.Combine(destinationDirectory, fileInfo.Name);

                fileInfo.CopyTo(destinationPath, overwrite);

            }
            catch (Exception ex)
            {
                throw new Exception($"Исключение в методе расширения: {ex.Message}");
            }
        }
    }
}