namespace GoldJewelry.Core
{
    using Constants;
    using Contracts;
    using IO.Contracts;
    using Messages;
    using Models;
    using Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter fileWriter;
        private readonly IWriter consoleWriter;
        private readonly FolderGenerator folderGenerator;


        public Engine(IReader reader, IWriter fileWriter, IWriter consoleWriter)
        {
            this.reader = reader;
            this.fileWriter = fileWriter;
            this.consoleWriter = consoleWriter;
        }

        public void Run()
        {
            CultureInfo culture = CultureInfo.CurrentCulture;

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

            var counter = 0;

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
                double weight = double.Parse(args[1], culture);

                IJewelry jewel = new Jewelry(type, weight);
                jewels.Add(jewel);

                string size = (args.Length == 3) ? args[2] : null;

                if (wantFolders)
                {
                    string foldersPath = $@"..\Jewelry\Folders\{type} - {weight}";

                    if (size != null && size.All((char c) => char.IsDigit(c)))
                    {
                        foldersPath += $" - {size}р-р";
                    }

                    if (Directory.Exists(foldersPath))
                    {
                        foldersPath += $"({++counter})";
                    }

                    Directory.CreateDirectory(foldersPath);
                }

                decimal price = (decimal)jewel.Weight * pricePerGram;

                decimal sellSum = Math.Round((decimal)jewel.Weight * sellPrice);
                decimal onlineSell = Math.Round((decimal)jewel.Weight * onlinePrice);

                if (size != null && size.All((char c) => char.IsDigit(c)))
                {
                    this.fileWriter.WriteLine($"{jewel.Type} - {jewel.Weight}g({size}р) * {pricePerGram}лв. = {price:f2}лв.|{sellPrice}лв. = {sellSum:f2}лв.|{onlinePrice}лв. = {onlineSell:f2}лв.|");
                }
                else
                {
                    this.fileWriter.WriteLine($"{jewel.Type} - {jewel.Weight}g * {pricePerGram}лв. = {price:f2}лв.|{sellPrice}лв. = {sellSum:f2}лв.|{onlinePrice}лв. = {onlineSell:f2}лв.|");
                }
            }

            this.fileWriter.WriteLine(dividingLine);
            double totalWeight = jewels.Sum((IJewelry j) => j.Weight);
            decimal totalSum = (decimal)totalWeight * pricePerGram;
            string footer = $"Total weight: {totalWeight}g * {pricePerGram}лв. = {totalSum:f2}лв.";

            this.fileWriter.WriteLine(footer);
            (this.fileWriter as IClearable).Clear();

        }
    }
}
