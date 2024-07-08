using System.Diagnostics;
using System.IO;

namespace File_browser.Model
{
    public class File
    {
        public string FileName { get; set; }
        public string Path { get; set; }

        public void GetPaths(string path, List<string> returnedPaths)
        {
            if (Directory.Exists(path))
            {
                Debug.WriteLine("Is directory");
            }
            returnedPaths.Add(path);
        }

        public override string ToString()
        {
            return FileName;
        }

        public virtual bool Equals(File other)
        {
            return Path.Equals(other.Path);
        }
    }
}
