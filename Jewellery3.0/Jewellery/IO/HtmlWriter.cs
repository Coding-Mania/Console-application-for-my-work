namespace GoldJewelry.IO
{
    using System;
    using System.IO;

    using Constants;
    using Contracts;

    public class HtmlWriter : IWriter, IClearable
    {
        private readonly StreamWriter streamWriter;

        public HtmlWriter()
        {
            if (!Directory.Exists(GlobalConstants.HtmlFilePath))
            {
                Directory.CreateDirectory(GlobalConstants.HtmlFilePath);
            }

            this.streamWriter = new StreamWriter(this.GetPath());
        }

        public void Clear()
        {
            this.streamWriter.Flush();
            this.streamWriter.Close();
        }

        public void Write(string value)
        {
            this.streamWriter.Write(value);
        }

        public void WriteLine(string value)
        {
            this.streamWriter.WriteLine(value);
        }

        private string GetPath()
        {
            var time = DateTime.Now;

            var path = string.Format(GlobalConstants.HtmlFileFullPath, time.Day, time.Month, time.Year);

            return path;
        }
    }
}
