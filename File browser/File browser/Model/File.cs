namespace File_browser.Model
{
    public class File
    {
        public string FileName { get; set; }
        public string Path { get; set; }

        public override string ToString()
        {
            return FileName;
        }
    }
}
