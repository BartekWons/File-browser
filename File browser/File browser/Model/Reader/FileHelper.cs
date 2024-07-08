using System.IO;

namespace File_browser.Model.Reader
{
    public static class FileHelper
    {
        public static List<FileReader> GetAllFiles(string directoryPath)
        {
            if (directoryPath == null || directoryPath.Equals(""))
            {
                throw new FormatException("Path is null or empty");
            }

            if (!Directory.Exists(directoryPath))
            {
                throw new DirectoryNotFoundException("Choosen path is not a directory");
            }

            string[] filesArr = Directory.GetFiles(directoryPath, "*.*", SearchOption.AllDirectories);

            HashSet<string> allowedExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { ".pdf", ".txt", ".docx", ".csv", ".doc" };

            var filteredFiles = filesArr.Where(file => allowedExtensions.Contains(System.IO.Path.GetExtension(file)));

            var finalFiles = new List<FileReader>();

            foreach (var file in filteredFiles)
            {
                var tmp = FileReaderFactory.CreateFileReader(file);
                if (tmp != null)
                    finalFiles.Add(tmp);
            }
            return finalFiles;
        }
    }
}
