using GoldJewelry.Constants;
using GoldJewelry.IO.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GoldJewelry.IO
{
    internal class CssWriter : IWriter, IClearable
    {
        private readonly StreamWriter streamWriter;
        public CssWriter()
        {
            this.streamWriter = new StreamWriter(GlobalConstants.CssFileFullPath);
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
    }
         
}