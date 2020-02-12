namespace GoldJewelry.IO
{
    using Contracts;

    public class FileWriter : IWriter
    {
        public FileWriter(string path)
        {
            this.Path = path;
        }

        public void Write()
        {

        }

        public string Path { get; private set; }
    }
}
