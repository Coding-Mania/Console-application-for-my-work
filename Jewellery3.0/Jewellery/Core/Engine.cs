namespace GoldJewelry.Core
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    using Constants;
    using Contracts;
    using IO.Contracts;
    using Models.Factory.Contracts;
    using Repository.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter fileWriter;
        private readonly IWriter cssWriter;
        private readonly IWriter consoleWriter;
        private readonly IFolderGenerator folderGenerator;
        private readonly IJewelryFactory jewelryFactory;
        private readonly IJewelryRepository jewelries;

        public Engine(IReader reader, IEnumerable<IWriter> writers, IFolderGenerator folderGenerator, IJewelryFactory jewelryFactory, IJewelryRepository jewelries)
        {
            this.reader = reader;
            this.fileWriter = writers.ElementAt(0);
            this.consoleWriter = writers.ElementAt(1);
            this.cssWriter = writers.ElementAt(2);
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

            this.fileWriter.WriteLine(GlobalConstants.Html);

            this.fileWriter
                .WriteLine(String.Format(GlobalConstants.TableHead, pricePerGram, sellPrice));

            while (true)
            {
                var input = this.reader.ReadLine();

                if (GlobalConstants.BreakingFirstValue == input.ToLower() || GlobalConstants.BreakingSecondValue == input.ToLower())
                {
                    break;
                }

                try
                {
                    var args = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    var type = args[0];
                    var weight = double.Parse(args[1]);

                    var price = Math.Round((decimal)double.Parse(args[1]) * pricePerGram, 2);
                    var size = (args.Length == 3) ? args[2] : null;

                    var jewel = this.jewelryFactory.GetJewelry(type, weight, price, size);
                    this.jewelries.Add(jewel);


                    if (wantFolders)
                    {
                        var foldersPath = string.Format(GlobalConstants.FoldersPath, type, weight);

                        if (size != null && size.All((char c) => char.IsDigit(c)))
                        {
                            foldersPath += string.Format(GlobalConstants.FoldersPathExtend, size);
                        }

                        this.folderGenerator.GenerateFolder(foldersPath);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Please enter valid data!!!");
                    Console.WriteLine(ex.Message);
                }
            }

            var counter = 1;

            foreach (var jewel in this.jewelries.GetJewelries())
            {
                var jewelSellPrice = Math.Round((decimal)jewel.Weight * sellPrice);

                if (jewel.Size != null)
                {
                    this.fileWriter.WriteLine(String.Format(GlobalConstants.JewelDetailWithSize, counter++, jewel.Type, jewel.Size, jewel.Weight, jewel.Price, jewelSellPrice));
                }
                else
                {
                    this.fileWriter.WriteLine(String.Format(GlobalConstants.JewelDetail, counter++, jewel.Type, jewel.Weight, jewel.Price, jewelSellPrice));
                }
            }

            this.fileWriter.WriteLine(String.Format(GlobalConstants.GeneralInformation, this.jewelries.TotalWeight, this.jewelries.TotalSum));
            this.fileWriter.WriteLine(GlobalConstants.LastRow);
            this.fileWriter.WriteLine(GlobalConstants.EndHtml);
            this.cssWriter.WriteLine(GlobalConstants.CssContent);

            (this.fileWriter as IClearable).Clear();
            (this.cssWriter as IClearable).Clear();
        }
    }
}
