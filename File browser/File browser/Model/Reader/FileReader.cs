namespace File_browser.Model.Reader
{
    public abstract class FileReader
    {
        public string FileName { get; set; }
        public string Path { get; set; }
        public int MatchingWords { get; set; }

        public abstract string ReadData();

        public override string ToString()
        {
            return FileName;
        }

        public override bool Equals(object? obj)
        {
            if (obj is FileReader other)
            {
                return String.Equals(this.Path, other.Path, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.Path?.GetHashCode(StringComparison.OrdinalIgnoreCase) ?? 0;
        }
    }
}
