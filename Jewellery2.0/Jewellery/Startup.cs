namespace GoldJewelry
{
    using System;

    using Constants;
    using Core;
    using Core.Contracts;
    using IO;
    using IO.Contracts;

    public static class Startup
    {
        public static void Main()
        {
            var time = DateTime.Now;

            var path = string.Format(GlobalConstants.TextFileFullPath, time.Day, time.Month, time.Year);

            IReader reader = new ConsoleReder();
            IWriter consoleWriter = new ConsoleWriter();
            IWriter fileWriter = new FileWriter(path);
            IFolderGenerator folderGenerator = new FolderGenerator();

            IEngine engine = new Engine(reader, fileWriter, consoleWriter, folderGenerator);

            engine.Run();
        }
    }
}
