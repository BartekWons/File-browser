using File_browser.Model.Reader.Extensions;
using System.IO;

namespace File_browser.Model.Reader
{
    public static class FileReaderFactory
    {
        private static readonly Dictionary<string, Func<FileReader>> _readerFactories = new Dictionary<string, Func<FileReader>>(StringComparer.OrdinalIgnoreCase)
        {
            {".pdf", () => new PdfReader() },
            {".txt", () => new Extensions.TextReader() },
            {".docx", () => new DocxReader() },
        };

        public static FileReader CreateFileReader(string filePath)
        {
            string extension = Path.GetExtension(filePath);
            if (_readerFactories.ContainsKey(extension))
            {
                var reader = _readerFactories[extension]();
                reader.Path = filePath;
                reader.FileName = Path.GetFileName(filePath);
                return reader;
            }
            return null;
        }
    }
}
