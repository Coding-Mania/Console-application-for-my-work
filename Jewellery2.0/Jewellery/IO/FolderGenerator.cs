namespace GoldJewelry.IO
{
    using System.IO;

    using Contracts;

    public class FolderGenerator : IFolderGenerator
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
