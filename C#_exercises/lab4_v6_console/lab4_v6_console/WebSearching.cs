using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Net;

namespace lab4_v6_console
{
    public class WebSearching
    {
        private string webURL = "https://www.susu.ru/ru/structure";
        private WebClient wbClnt;
        private List<WebPage> pages;
        //public delegate void Dlg(WebPage page, int Count);
        //public event Dlg WebScanning;
        public event Action<WebPage, int> WebScanning;

        public WebSearching()
        {
            wbClnt = new WebClient();
            wbClnt.Encoding = System.Text.Encoding.UTF8;
            WebScanning = null;
        }

        public bool Scanning(string URL, int maxCountOfLinks, int maxLevel)
        {
            string page, title;
            pages = new List<WebPage>();
            try
            {
                webURL = URL;
                page = wbClnt.DownloadString(URL);
                title = Regex.Match(page, @"<title>[\w\S ]+<\/title>").ToString().Replace("<title>", "").Replace("</title>", "");
                title = title.Length > title.Substring(0, Math.Min(100, title.Length)).Length ? title.Substring(0, Math.Min(100, title.Length)) + "..." : title.Substring(0, Math.Min(100, title.Length));
                var hrefs = (from href in Regex.Matches(page, @"href=""[\/\w-\.:]+""").Cast<Match>()
                             let url = href.Value.Replace("href=", "").Trim('"')
                             let loc = url.StartsWith("/")
                             select new
                             {
                                 Ref = loc ? $"{Regex.Match(URL, @"https:\/\/[\w.]*")}{url}" : url,
                                 isLocal = loc,
                                 level = loc ? url.Count(x => x == '/') : 0,

                             }).ToList();

                WebPage web = new WebPage(title, webURL, webURL.Replace("https://", "").Count(x => x == '/'));
                web.AddEmails(GetEmailsByURL(webURL));
                pages.Add(web);
                WebScanning?.Invoke(web, 1);

                hrefs = (from pg in hrefs
                         orderby pg.Ref
                         select pg).ToList();
                int num = 1;
                for (int i = 1; i < hrefs.Count; i++)
                {
                    if (!hrefs[i - 1].isLocal || hrefs[i - 1].level > maxLevel) continue;
                    WebPage wbpg = new WebPage(GetTitleByURL(hrefs[i].Ref), hrefs[i].Ref, hrefs[i].level);
                    if (pages.Contains(wbpg)) continue;
                    if (num > maxCountOfLinks) break;
                    wbpg.AddEmails(GetEmailsByURL(hrefs[i].Ref));
                    pages.Add(wbpg);
                    WebScanning?.Invoke(wbpg, num + 1);
                    num++;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private string GetTitleByURL(string URL)
        {
            try
            {
                string pg = wbClnt.DownloadString(URL);
                string s = Regex.Match(pg, @"<title>[\w\S ]+<\/title>").ToString().Replace("<title>", "").Replace("</title>", "");
                string res = s.Substring(0, Math.Min(100, s.Length));
                return res.Length < s.Length ? res + "..." : res;
            }
            catch
            {
                return "";
            }
        }

        private List<string> GetEmailsByURL(string URL)
        {
            try
            {
                string pg = wbClnt.DownloadString(URL);
                var emails = (from email in Regex.Matches(pg, @"([-\w]+\[dot\])*[-\w]+\[at\][-\w]+(\[dot\][-\w]+)+").Cast<Match>()
                              let emlTmp = email.Value.Replace("[at]", "@").Replace("[dot]", ".")
                              select new
                              {
                                  eml = emlTmp
                              }).ToList();
                List<string> res = new List<string>();
                for (int i = 0; i < emails.Count - 1; i++)
                    res.Add(emails[i].eml + "\n");
                res.Add(emails[emails.Count - 1].eml);
                return res;
            }
            catch
            {
                return null;
            }
        }
    }
}
