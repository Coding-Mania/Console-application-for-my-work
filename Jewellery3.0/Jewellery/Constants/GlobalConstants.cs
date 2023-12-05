namespace GoldJewelry.Constants
{
    public static class GlobalConstants
    {
        public const string HtmlFilePath = @"..\Jewelry";

        public const string HtmlFileFullPath = @"..\Jewelry\Jewelry - {0}.{1}.{2}.html";

        public const string CssFileFullPath = @"..\Jewelry\styles.css";

        public const string CssContent = "table,\r\nth,\r\ntd {\r\nborder: 1px solid;\r\nwidth: 70%;\r\nborder-collapse: collapse;\r\ntext-align:center;\r\nheight: 35px;\r\n}\r\n\r\nh1 {\r\n    margin-top: 50px;\r\n    color:rgb(140, 171, 119);\r\n    text-align: center;\r\n}\r\n\r\n.table {\r\n\r\n    table-layout: fixed;\r\n}\r\n\r\n.center {\r\n    margin-left: auto;\r\n    margin-right: auto;\r\n}\r\n\r\ntr:nth-child(even) {\r\n    background-color: rgb(122, 215, 215);\r\n}\r\n\r\ntr:nth-child(odd) {\r\n    background-color: rgb(170, 188, 163);\r\n}\r\n\r\nth, .lastrow{\r\n    background-color: rgb(244, 182, 170);\r\n}\r\n\r\nhtml{\r\n    background-color: azure;\r\n}\r\n\r\ntr:hover {\r\n    background-color: yellow;\r\n  }";

        public const string TableHead = " <table class=\"table center\">\r\n<tr>\r\n<th>Артикул</th>\r\n<th>Грамаж</th>\r\n<th>Главница закръглена! {0}лв.</th>\r\n\t<th>Цена продава закръглена! {1}лв.</th>\r\n</tr>";

        public const string Html = "<html>\r\n<head>\r\n<link rel=\"stylesheet\" href=\"styles.css\">\r\n</head>\r\n<body><h1>Таблица</h1>";

        public const string EndHtml = "</table></body>\r\n</html>";

        public const string FoldersPath = @"..\Jewelry\Folders\{0} - {1}";

        public const string FoldersPathExtend = " - {0}р-р";

        public const string FolderMessage = "Create folders? Y/N: ";

        public const string PricePerGramMessage = "Enter price per gram: ";

        public const string SellPricePerGramMessage = "Enter sell price per gram: ";

        public const string JewelDetail = "<tr>\r\n<td>{0}</td>\r\n<td>{1}гр.</td>\r\n<td>{2}лв.</td>\r\n<td>{3}лв</td>\r\n<td><input type=\"checkbox\"></td></tr>";

        public const string JewelDetailWithSize = "<tr>\r\n<td>{0} ({1})размер</td>\r\n<td>{2}гр.</td>\r\n<td>{3}лв.</td>\r\n<td>{4}лв</td>\r\n<td><input type=\"checkbox\"></td></tr>";

        public const string GeneralInformation = "<tr><td colspan=\"2\" style=\"font-weight:bold\">Общ грамаж: {0}/гр.</td><td colspan=\"2\" style=\"font-weight:bold\">Обща главница: {1}лв.</td></tr>";

        public const string LastRow = "<tr><td class=\"lastrow\" colspan=\"4\" style=\"font-weight:bold\">Всички суми са закръглени до най-близкото кръгло число!</td></tr>";

        public const string BreakingFirstValue = "end";

        public const string BreakingSecondValue = "край";
    }
}
