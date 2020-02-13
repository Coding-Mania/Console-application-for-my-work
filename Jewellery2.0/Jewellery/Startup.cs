namespace GoldJewelry
{
    using Core;
    using Core.Contracts;
    using IO;
    using IO.Contracts;

    public static class Startup
    {
        public static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter consoleWriter = new ConsoleWriter();
            IWriter fileWriter = new FileWriter();
            IFolderGenerator folderGenerator = new FolderGenerator();

            IEngine engine = new Engine(reader, fileWriter, consoleWriter, folderGenerator);

            engine.Run();
        }
    }
}
