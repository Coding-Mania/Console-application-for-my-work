namespace GoldJewelry.IO
{
    using System;
    using System.Text;
    using Contracts;

    public class ConsoleReder : IReader
    {
        public ConsoleReder()
        {
            Console.InputEncoding = Encoding.Unicode;
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
