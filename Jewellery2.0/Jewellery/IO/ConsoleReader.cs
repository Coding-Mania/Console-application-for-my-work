namespace GoldJewelry.IO
{
    using System;
    using System.Text;

    using Contracts;

    public class ConsoleReader : IReader
    {
        public ConsoleReader()
        {
            Console.InputEncoding = Encoding.Unicode;
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
