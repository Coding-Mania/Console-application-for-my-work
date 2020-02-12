namespace GoldJewelry.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Constants;
    using Contracts;
    using IO.Contracts;
    using Messages;
    using Models;
    using Models.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter fileWriter;
        private readonly IWriter consoleWriter;
        private readonly IFolderGenerator folderGenerator;


        public Engine(IReader reader, IWriter fileWriter, IWriter consoleWriter, IFolderGenerator folderGenerator)
        {
            this.reader = reader;
            this.fileWriter = fileWriter;
            this.consoleWriter = consoleWriter;
            this.folderGenerator = folderGenerator;
        }

        public void Run()
        {

            this.consoleWriter.Write(Messages.FolderMessage);

            string folderAnser = this.reader.ReadLine().ToLower();

            (this.consoleWriter as IClearable).Clear();

            bool wantFolders = (folderAnser == "y" || folderAnser == "у") ? true : false;

            this.consoleWriter.Write(Messages.PricePerGramMessage);
            decimal pricePerGram = decimal.Parse(this.reader.ReadLine());

            this.consoleWriter.Write(Messages.SellPricePerGramMessage);
            decimal sellPrice = decimal.Parse(this.reader.ReadLine());

            this.consoleWriter.Write(Messages.OnlineShopPricePerGramMessage);
            decimal onlinePrice = decimal.Parse(this.reader.ReadLine());


            List<IJewelry> jewels = new List<IJewelry>();

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

                IJewelry jewel = new Jewelry(type, weight);
                jewels.Add(jewel);

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
                    string jewelInfo = string.Format(GlobalConstants.JewesInfoExtend, jewel.Type, jewel.Weight, size, pricePerGram, price, sellPrice, sellSum, onlinePrice, onlineSell);
                    this.fileWriter.WriteLine(jewelInfo);
                }
                else
                {
                    string jewelInfo = string.Format(GlobalConstants.JewesInfo, jewel.Type, jewel.Weight, pricePerGram, price, sellPrice, sellSum, onlinePrice, onlineSell);
                    this.fileWriter.WriteLine(jewelInfo);

                }
            }

            this.fileWriter.WriteLine(dividingLine);
            double totalWeight = jewels.Sum((IJewelry j) => j.Weight);
            decimal totalSum = (decimal)totalWeight * pricePerGram;

            string footer = string.Format(GlobalConstants.Footer, totalWeight, pricePerGram, totalSum);

            this.fileWriter.WriteLine(footer);
            (this.fileWriter as IClearable).Clear();
        }
    }
}
