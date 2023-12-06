namespace GoldJewelry.Constants
{
    public static class GlobalConstants
    {
        public const string HtmlFilePath = @"..\Jewelry";

        public const string HtmlFileFullPath = @"..\Jewelry\Jewelry - {0}.{1}.{2}.html";

        public const string CssFileFullPath = @"..\Jewelry\styles.css";

        public const string CssContent = "table,\r\nth,\r\ntd {\r\n    border: 1px solid;\r\n    width: 70%;\r\n    border-collapse: collapse;\r\n    text-align: center;\r\n    height: 35px;\r\n}\r\n\r\nh1 {\r\n    margin-top: 50px;\r\n    color: rgb(246, 246, 246);\r\n    text-align: center;\r\n}\r\n\r\n.table {\r\n\r\n    table-layout: fixed;\r\n}\r\n\r\n.center {\r\n    margin-left: auto;\r\n    margin-right: auto;\r\n}\r\n\r\ntr:nth-child(even) {\r\n    background-color: rgb(236, 234, 234);\r\n}\r\n\r\ntr:nth-child(odd) {\r\n    background-color: rgb(207, 207, 207);\r\n}\r\n\r\nth,\r\n.lastrow {\r\n    background-color: rgb(244, 182, 170);\r\n}\r\n\r\nbody {\r\n    background-image: url('index.jpg');\r\n}\r\n\r\ntr:hover {\r\n    background-color: rgba(166,233,33,255);\r\n} \r\ntd:first-child, th:first-child\r\n{ \r\n    width: 30px;\r\n}\r\n";

        public const string TableHead = " <table class=\"table center\">\r\n<tr><th>№</th>\r\n<th>Артикул</th>\r\n<th>Грамаж</th>\r\n<th>Главница закръглена! {0}лв.</th>\r\n\t<th>Цена продава закръглена! {1}лв.</th>\r\n</tr>";

        public const string Html = "<html>\r\n<head>\r\n<link rel=\"stylesheet\" href=\"styles.css\">\r\n</head>\r\n<body><h1>Таблица</h1>";

        public const string EndHtml = "</table></body>\r\n</html>";

        public const string FoldersPath = @"..\Jewelry\Folders\{0} - {1}";

        public const string FoldersPathExtend = " - {0}р-р";

        public const string FolderMessage = "Create folders? Y/N: ";

        public const string PricePerGramMessage = "Enter price per gram: ";

        public const string SellPricePerGramMessage = "Enter sell price per gram: ";

        public const string JewelDetail = "<tr>\r\n<td>{0}<input type=\"checkbox\"></td>\r\n<td>{1}</td>\r\n<td>{2}гр.</td>\r\n<td>{3}лв.</td>\r\n<td>{4}лв</td>\r\n</tr>";

        public const string JewelDetailWithSize = "<tr>\r\n<td>{0}<input type=\"checkbox\"></td>\r\n<td>{1} ({2})размер</td>\r\n<td>{3}гр.</td>\r\n<td>{4}лв.</td>\r\n<td>{5}лв</td>\r\n<td><input type=\"checkbox\"></td></tr>";

        public const string GeneralInformation = "<tr><td colspan=\"3\" style=\"font-weight:bold\">Общ грамаж: {0}/гр.</td><td colspan=\"2\" style=\"font-weight:bold\">Обща главница: {1}лв.</td></tr>";

        public const string LastRow = "<tr><td class=\"lastrow\" colspan=\"5\" style=\"font-weight:bold\">Всички суми са закръглени до най-близкото кръгло число!</td></tr>";

        public const string BreakingFirstValue = "end";

        public const string BreakingSecondValue = "край";
    }
}
