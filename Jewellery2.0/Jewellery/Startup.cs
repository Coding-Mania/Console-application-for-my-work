namespace GoldJewelry
{
    using System;
    using System.Collections.Generic;

    using Core;
    using Core.Contracts;
    using IO;
    using IO.Contracts;
    using Microsoft.Extensions.DependencyInjection;
    using Models;
    using Models.Contracts;
    using Models.Factory;
    using Models.Factory.Contracts;
    using Repository;
    using Repository.Contracts;

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
            serviceCollection.AddSingleton<IWriter, FileWriter>();
            serviceCollection.AddTransient<IWriter, ConsoleWriter>();
            serviceCollection.AddTransient<IFolderGenerator, FolderGenerator>();
            serviceCollection.AddTransient<IJewelry, Jewelry>();
            serviceCollection.AddTransient<IJewelryFactory, JewelryFactory>();
            serviceCollection.AddSingleton<ICollection<IJewelry>>(new List<IJewelry>());
            serviceCollection.AddTransient<IJewelryRepository, JewelryRepository>();
            serviceCollection.AddTransient<IEngine, Engine>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
