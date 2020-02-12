namespace GoldJewelry
{
    using Core;
    using Core.Contracts;
    using GoldJewelry.Constants;
    using GoldJewelry.IO;
    using GoldJewelry.IO.Contracts;
    using System;

    public static class Startup
    {
        public static void Main()
        {
            var time = DateTime.Now;

            var path = string.Format(GlobalConstants.TextFileFullPath, time.Day, time.Month, time.Year);

            IReader reader = new ConsoleReder();
            IWriter consoleWriter = new ConsoleWriter();
            IWriter fileWriter = new FileWriter(path);

            IEngine engine = new Engine(reader, fileWriter, consoleWriter);

            engine.Run();
        }
    }
}
