namespace GoldJewelry.Core
{
    using System;
    using System.Collections.Generic;
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
        private readonly IWriter consoleWriter;
        private readonly IFolderGenerator folderGenerator;
        private readonly IJewelryFactory jewelryFactory;
        private readonly IJewelryRepository jewelries;

        public Engine(IReader reader, IEnumerable<IWriter> writers, IFolderGenerator folderGenerator, IJewelryFactory jewelryFactory, IJewelryRepository jewelries)
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

            this.fileWriter.WriteLine(GlobalConstants.Html);
            this.fileWriter.WriteLine(GlobalConstants.TableHead);

            while (true)
            {
                var input = this.reader.ReadLine();

                if (GlobalConstants.BreakingFirstValue == input.ToLower() || GlobalConstants.BreakingSecondValue == input.ToLower())
                {
                    break;
                }

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

                var price = Math.Round((decimal)jewel.Weight * pricePerGram);

                var sellSum = Math.Round((decimal)jewel.Weight * sellPrice);

                this.fileWriter.WriteLine($"<tr>\r\n<td>{jewel.Type}</td>\r\n<td>{jewel.Weight}гр.</td>\r\n<td>* {pricePerGram} = {price}лв.</td>\r\n<td>* {sellPrice} = {sellSum}лв</td>\r\n<td><input type=\"checkbox\"></td></tr>");
            }

            var totalSum = Math.Round(this.jewelries.TotalWeight * pricePerGram);

            this.fileWriter.WriteLine($"<tr><td colspan=\"4\" style=\"font-weight:bold\">Общ грамаж: {this.jewelries.TotalWeight}/гр. * {pricePerGram} = {totalSum}лв.</td></tr>");
            this.fileWriter.WriteLine($"<tr><td colspan=\"4\" style=\"font-weight:bold\">Всички суми са закръглени до най-близкото кръгло число!</td></tr>");
            this.fileWriter.WriteLine(GlobalConstants.EndHtml);

            (this.fileWriter as IClearable).Clear();
        }
    }
}
