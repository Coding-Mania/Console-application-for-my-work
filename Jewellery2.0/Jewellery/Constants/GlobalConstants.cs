﻿namespace GoldJewelry.Constants
{
    public static class GlobalConstants
    {
        public const string TextFilePath = @"..\Jewelry";

        public const string TextFileFullPath = @"..\Jewelry\Jewelry - {0}.{1}.{2}.txt";

        public const string Header = "|  Артикул  |  Грам  |  Главница  |  Цена продава  |  Онлайн  |";

        public const string Footer = "Total weight: {0}g * {1}лв. = {2:f2}лв.";

        public const string JewesInfo = "{0} - {1}g * {2}лв. = {3:f2}лв.|{4}лв. = {5:f2}лв.|{6}лв. = {7:f2}лв.|";

        public const char DividingLineChar = '-';

        public static string[] BreakingValues = { "end", "край" };
    }
}