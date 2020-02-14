namespace GoldJewelry
{
    using System.Collections.Generic;

    using Core;
    using Core.Contracts;
    using IO;
    using IO.Contracts;
    using Models.Contracts;
    using Models.Factory;
    using Models.Factory.Contracts;

    public static class Startup
    {
        public static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter consoleWriter = new ConsoleWriter();
            IWriter fileWriter = new FileWriter();
            IFolderGenerator folderGenerator = new FolderGenerator();
            IJewelryFactory jewelryFactory = new JewelryFactory();
            ICollection<IJewelry> jewelries = new List<IJewelry>();

            IEngine engine = new Engine(reader, fileWriter, consoleWriter, folderGenerator, jewelryFactory, jewelries);

            engine.Run();
        }
    }
}
