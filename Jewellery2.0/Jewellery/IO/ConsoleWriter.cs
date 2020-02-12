namespace GoldJewelry.IO
{
    using System;

    using Contracts;

    public class ConsoleWriter : IWriter, IClearable
    {
        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void Write(string value)
        {
            Console.Write(value);
        }
    }
}
