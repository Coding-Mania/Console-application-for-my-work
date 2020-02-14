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

        public Engine(IReader reader, IWriter fileWriter, IWriter consoleWriter, IFolderGenerator folderGenerator, IJewelryFactory jewelryFactory, ICollection<IJewelry> jewelries)
        {
            this.reader = reader;
            this.fileWriter = fileWriter;
            this.consoleWriter = consoleWriter;
            this.folderGenerator = folderGenerator;
            this.jewelryFactory = jewelryFactory;
            this.jewelries = jewelries;
        }

        public void Run()
        {
            this.consoleWriter.Write(GlobalConstants.FolderMessage);

            string folderAnser = this.reader.ReadLine().ToLower();

            (this.consoleWriter as IClearable).Clear();

            bool wantFolders = (folderAnser == "y" || folderAnser == "у") ? true : false;

            this.consoleWriter.Write(GlobalConstants.PricePerGramMessage);
            decimal pricePerGram = decimal.Parse(this.reader.ReadLine());

            this.consoleWriter.Write(GlobalConstants.SellPricePerGramMessage);
            decimal sellPrice = decimal.Parse(this.reader.ReadLine());

            this.consoleWriter.Write(GlobalConstants.OnlineShopPricePerGramMessage);
            decimal onlinePrice = decimal.Parse(this.reader.ReadLine());

            this.fileWriter.WriteLine(GlobalConstants.Header);

            string dividingLine = new string(GlobalConstants.DividingLineChar, GlobalConstants.Header.Length);
            this.fileWriter.WriteLine(dividingLine);

            while (true)
            {
                string input = this.reader.ReadLine();

                if (GlobalConstants.BreakingValues.Contains(input.ToLower()))
                {
                    break;
                }

                this.fileWriter.WriteLine(dividingLine);

                string[] args = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string type = args[0];
                double weight = double.Parse(args[1]);

                IJewelry jewel = this.jewelryFactory.GetJewelry(type, weight);
                this.jewelries.Add(jewel);

                string size = (args.Length == 3) ? args[2] : null;

                if (wantFolders)
                {
                    string foldersPath = string.Format(GlobalConstants.FoldersPath, type, weight);

                    if (size != null && size.All((char c) => char.IsDigit(c)))
                    {
                        foldersPath += string.Format(GlobalConstants.FoldersPathExtend, size);
                    }

                    this.folderGenerator.GenerateFolder(foldersPath);
                }

                decimal price = (decimal)jewel.Weight * pricePerGram;

                decimal sellSum = Math.Round((decimal)jewel.Weight * sellPrice);
                decimal onlineSell = Math.Round((decimal)jewel.Weight * onlinePrice);

                if (size != null && size.All((char c) => char.IsDigit(c)))
                {
                    string jewelInfo = string.Format(GlobalConstants.JewelsInfoExtend, jewel.Type, jewel.Weight, size, pricePerGram, price, sellPrice, sellSum, onlinePrice, onlineSell);
                    this.fileWriter.WriteLine(jewelInfo);
                }
                else
                {
                    string jewelInfo = string.Format(GlobalConstants.JewelsInfo, jewel.Type, jewel.Weight, pricePerGram, price, sellPrice, sellSum, onlinePrice, onlineSell);
                    this.fileWriter.WriteLine(jewelInfo);
                }
            }

            this.fileWriter.WriteLine(dividingLine);
            decimal totalWeight = this.jewelries.Sum(j => (decimal)j.Weight);
            decimal totalSum = totalWeight * pricePerGram;

            string footer = string.Format(GlobalConstants.Footer, totalWeight, pricePerGram, totalSum);

            this.fileWriter.WriteLine(footer);
            (this.fileWriter as IClearable).Clear();
        }
    }
}
