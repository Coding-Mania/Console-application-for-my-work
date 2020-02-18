namespace GoldJewelry.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Constants;
    using Contracts;
    using Models.Factory.Contracts;
    using IO.Contracts;
    using Models.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter fileWriter;
        private readonly IWriter consoleWriter;
        private readonly IFolderGenerator folderGenerator;
        private readonly IJewelryFactory jewelryFactory;
        private readonly ICollection<IJewelry> jewelries;

        public Engine(IReader reader, IEnumerable<IWriter> writers, IFolderGenerator folderGenerator, IJewelryFactory jewelryFactory, ICollection<IJewelry> jewelries)
        {
            this.reader = reader;
            this.fileWriter = writers.ElementAt(0);
            this.consoleWriter = writers.ElementAt(1);
            this.folderGenerator = folderGenerator;
            this.jewelryFactory = jewelryFactory;
            this.jewelries = jewelries;
        }

        public void Run()
        {
            this.consoleWriter.Write(GlobalConstants.FolderMessage);

            var folderAnser = this.reader.ReadLine().ToLower();

            (this.consoleWriter as IClearable).Clear();

            var wantFolders = (folderAnser == "y" || folderAnser == "у") ? true : false;

            this.consoleWriter.Write(GlobalConstants.PricePerGramMessage);
            var pricePerGram = decimal.Parse(this.reader.ReadLine());

            this.consoleWriter.Write(GlobalConstants.SellPricePerGramMessage);
            var sellPrice = decimal.Parse(this.reader.ReadLine());

            this.consoleWriter.Write(GlobalConstants.OnlineShopPricePerGramMessage);
            var onlinePrice = decimal.Parse(this.reader.ReadLine());

            this.fileWriter.WriteLine(GlobalConstants.Header);

            var dividingLine = new string(GlobalConstants.DividingLineChar, GlobalConstants.Header.Length);
            this.fileWriter.WriteLine(dividingLine);

            while (true)
            {
                var input = this.reader.ReadLine();

                if (GlobalConstants.BreakingFirstValue == input.ToLower() || GlobalConstants.BreakingSecondValue == input.ToLower())
                {
                    break;
                }

                this.fileWriter.WriteLine(dividingLine);

                var args = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var type = args[0];
                var weight = double.Parse(args[1]);

                var jewel = this.jewelryFactory.GetJewelry(type, weight);
                this.jewelries.Add(jewel);

                var size = (args.Length == 3) ? args[2] : null;

                if (wantFolders)
                {
                    var foldersPath = string.Format(GlobalConstants.FoldersPath, type, weight);

                    if (size != null && size.All((char c) => char.IsDigit(c)))
                    {
                        foldersPath += string.Format(GlobalConstants.FoldersPathExtend, size);
                    }

                    this.folderGenerator.GenerateFolder(foldersPath);
                }

                var price = (decimal)jewel.Weight * pricePerGram;

                var sellSum = Math.Round((decimal)jewel.Weight * sellPrice);
                var onlineSell = Math.Round((decimal)jewel.Weight * onlinePrice);

                if (size != null && size.All((char c) => char.IsDigit(c)))
                {
                    var jewelInfo = string.Format(GlobalConstants.JewelsInfoExtend, jewel.Type, jewel.Weight, size, pricePerGram, price, sellPrice, sellSum, onlinePrice, onlineSell);
                    this.fileWriter.WriteLine(jewelInfo);
                }
                else
                {
                    var jewelInfo = string.Format(GlobalConstants.JewelsInfo, jewel.Type, jewel.Weight, pricePerGram, price, sellPrice, sellSum, onlinePrice, onlineSell);
                    this.fileWriter.WriteLine(jewelInfo);
                }
            }

            this.fileWriter.WriteLine(dividingLine);
            var totalWeight = this.jewelries.Sum(j => (decimal)j.Weight);
            var totalSum = totalWeight * pricePerGram;

            var footer = string.Format(GlobalConstants.Footer, totalWeight, pricePerGram, totalSum);

            this.fileWriter.WriteLine(footer);
            (this.fileWriter as IClearable).Clear();
        }
    }
}
