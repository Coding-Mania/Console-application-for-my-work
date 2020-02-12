namespace GoldJewelry.IO
{
    using System.IO;

    using Constants;
    using Contracts;

    public class FileWriter : IWriter
    {
        private readonly StreamWriter streamWriter;

        public FileWriter(string path)
        {
            if (!Directory.Exists(GlobalConstants.TextFilePath))
            {
                Directory.CreateDirectory(GlobalConstants.TextFilePath);
            }

            this.streamWriter = new StreamWriter(path);
        }

        public void WriteLine(string value)
        {
            using (streamWriter)
            {
                streamWriter.WriteLine(value);
            }
        }
    }
}
