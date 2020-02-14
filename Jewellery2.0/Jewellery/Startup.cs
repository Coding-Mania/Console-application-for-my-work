namespace GoldJewelry
{
    using Core;
    using Core.Contracts;
    using GoldJewelry.Models.Contracts;
    using GoldJewelry.Models.Factory;
    using GoldJewelry.Models.Factory.Contracts;
    using IO;
    using IO.Contracts;
    using System.Collections.Generic;

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
