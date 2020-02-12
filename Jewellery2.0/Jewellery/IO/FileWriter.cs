namespace GoldJewelry.IO
{
    using System.IO;

    using Constants;
    using Contracts;

    public class FileWriter : IWriter, IClearable
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

        public void Clear()
        {
            this.streamWriter.Flush();
            this.streamWriter.Close();
        }

        public void Write(string value)
        {
            using (streamWriter)
            {
                this.streamWriter.Write(value);
            }
        }

        public void WriteLine(string value)
        {
            this.streamWriter.WriteLine(value);
        }
    }
}
