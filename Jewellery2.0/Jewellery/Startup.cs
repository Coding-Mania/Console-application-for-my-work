namespace GoldJewelry
{
    using System;

    using Core;
    using Core.Contracts;
    using GoldJewelry.Models;
    using GoldJewelry.Models.Contracts;
    using IO;
    using IO.Contracts;
    using Microsoft.Extensions.DependencyInjection;

    public static class Startup
    {
        public static void Main()
        {
            var serviceProvider = ConfigureServices();

            IEngine engine = serviceProvider.GetService<IEngine>();

            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient<IReader, ConsoleReader>();
            serviceCollection.AddTransient<IWriter, FileWriter>();
            serviceCollection.AddTransient<IWriter, ConsoleWriter>();
            serviceCollection.AddTransient<IFolderGenerator, FolderGenerator>();
            serviceCollection.AddTransient<IJewelry, Jewelry>();
            serviceCollection.AddTransient<IEngine, Engine>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
