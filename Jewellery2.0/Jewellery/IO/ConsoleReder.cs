namespace GoldJewelry.IO
{
    using System;

    using Contracts;

    public class ConsoleReder : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
