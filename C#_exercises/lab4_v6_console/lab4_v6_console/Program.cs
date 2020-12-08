using System;
using CsvHelper;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace lab4_v6_console
{
    class Program
    {
        private static string webURI = "https://www.susu.ru";
        private static int maxCountOfPages = 100;
        private static int maxLevel = 10;
        private static WebSearching searching;
        private static List<WebPage> pages;

        private static string path = "C:\\Users\\Public\\Documents\\web_scanning.csv";

        static void Main(string[] args)
        {
            Console.WriteLine("Введите ссылку:");
            try
            {
                webURI = Console.ReadLine();
                Console.WriteLine("Введите максимальное количество страниц для сканирования:");
                maxCountOfPages = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите значение максимального уровня вложенности:");
                maxLevel = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Ошибка!!!");
                return;
            }
            pages = new List<WebPage>();
            searching = new WebSearching();
            Console.OutputEncoding = Encoding.Unicode;
            searching.WebScanning += (page, count) =>
            {
                pages.Add(page);
                try
                {
                    string outStr = count.ToString() + ") ";
                    for (int i = 0; i < page.level; i++) outStr += "|--";
                    outStr += $"{page.name} | {page.level}";
                    Console.WriteLine(outStr);
                }
                catch{}
            };

            if (webURI.Length <= 0 || !searching.Scanning(webURI, maxCountOfPages, maxLevel))
            {
                Console.WriteLine("Ошибка!!!");
                return;
            }
            Console.Clear();
            ShowTable();

            // запись в csv файл
            WriteCSV();

            pages = null;
        }

        private static void WriteCSV()
        {
            if (path == null || path.Length <= 0) return;
            StreamWriter streamWriter = null;
            try
            {
                using (streamWriter = new StreamWriter(path))
                {
                    using (CsvWriter csvWriter = new CsvWriter(streamWriter))
                    {
                        csvWriter.Configuration.Delimiter = ",";
                        List<Page> lst = new List<Page>();
                        foreach (WebPage p in pages)
                            if (p != null) lst.Add(WebPageToPage(p));
                        csvWriter.WriteRecords(lst);
                    }
                }
            }
            catch
            {
                if (streamWriter != null) streamWriter.Close();
            }
        }

        private static void ShowTable()
        {
            if (pages == null) return;
            List<string> table = new List<string>();

            int wigthOfFirstColumn = 0, wigthOfSecondColumn = 0, wigthOfThirdColumn = 0;

            // выравнивание первой колонки

            int maxWigth = (pages.Count - 1).ToString().Length;

            for (int i = 0; i < pages.Count; i++)
            {
                string temp = (i + 1).ToString();
                for (; temp.Length < maxWigth; temp += " ") ;
                temp += " | ";
                wigthOfFirstColumn = temp.Length - 2;
                for (int j = 0; j < pages[i].level; j++) temp += "|--";
                temp += pages[i].name + " ";
                table.Add(temp);
            }

            maxWigth = 0;
            foreach (string s in table)
                if (s.Length > maxWigth) maxWigth = s.Length;

            for (int i = 0; i < table.Count; i++)
            {
                for (; maxWigth > table[i].Length; table[i] += " ") ;
                wigthOfSecondColumn = table[i].Length;
                table[i] += "| " + pages[i].level.ToString();
            }

            //выравнивание второй колонки
            maxWigth = 0;
            foreach (string s in table)
                if (s.Length > maxWigth) maxWigth = s.Length;

            for (int i = 0; i < table.Count; i++)
            {
                for (; maxWigth > table[i].Length; table[i] += " ") ;
                wigthOfThirdColumn = table[i].Length + 1;
                table[i] += " | ";
            }

            //добавление третьей колонки
            maxWigth = table[0].Length;
            string tmp = "";
            for (; tmp.Length < maxWigth; tmp += " ") ;
            for (int i = 0; i < table.Count; i++)
            {
                List<string> emails = pages[i].GetEmails();
                if (emails == null) continue;
                for (int j = 0; j < emails.Count - 1; j++)
                    table[i] += emails[j] + tmp;
                table[i] += emails[emails.Count - 1];
            }

            string namesOfColumns = "";
            for (; namesOfColumns.Length < wigthOfFirstColumn / 2 - 1; namesOfColumns += " ") ;
            namesOfColumns += "№";
            for (; namesOfColumns.Length < wigthOfFirstColumn; namesOfColumns += " ") ;
            namesOfColumns += "|";
            for (; namesOfColumns.Length < wigthOfSecondColumn / 2 - 8; namesOfColumns += " ") ;
            namesOfColumns += "название";
            for (; namesOfColumns.Length < wigthOfSecondColumn; namesOfColumns += " ") ;
            namesOfColumns += "|";
            for (; namesOfColumns.Length < wigthOfThirdColumn / 2 - 3; namesOfColumns += " ") ;
            namesOfColumns += "lvl";
            for (; namesOfColumns.Length < wigthOfThirdColumn; namesOfColumns += " ") ;
            namesOfColumns += "| emails";


            Console.WriteLine(namesOfColumns);
            foreach (string s in table) Console.WriteLine(s);
        }

        private static Page WebPageToPage(WebPage p)
        {
            if (p == null) return null;
            Page res = new Page { name = p.name == null? "" : p.name, level = p.level.ToString() == null? "0" : p.level.ToString(), URL = p.URL == null? "" : p.URL };
            List<string> emls = p.GetEmails();
            if (emls != null) foreach (string s in emls) res.emails += s + " ";
            else res.emails = "";
            return res;
        }

        public class Page
        {
            public string name { get; set; }
            public string level { get; set; }
            public string URL { get; set; }
            public string emails { get; set; }
        }
    }
}
