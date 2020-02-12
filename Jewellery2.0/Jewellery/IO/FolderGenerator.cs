namespace GoldJewelry.IO
{
    using System.IO;

    public class FolderGenerator
    {
        private int counter;

        public FolderGenerator()
        {
            this.counter = 0;
        }

        public void GenerateFolder(string path)
        {
            if (Directory.Exists(path))
            {
                path += $"({++counter})";
            }

            Directory.CreateDirectory(path);
        }
    }
}
