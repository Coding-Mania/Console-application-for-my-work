namespace GoldJewelry
{
    using Core;
    using Core.Contracts;
    using GoldJewelry.Models.Factory;
    using GoldJewelry.Models.Factory.Contracts;
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
            IJewelryFactory jewelryFactory = new JewelryFactory();

            IEngine engine = new Engine(reader, fileWriter, consoleWriter, folderGenerator, jewelryFactory);

            engine.Run();
        }
    }
}
