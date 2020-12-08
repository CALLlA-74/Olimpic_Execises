using System;
using System.Collections.Generic;

namespace lab4_v6_console
{
    public class WebPage : IEquatable<WebPage>
    {
        public readonly string name;
        public readonly int level;
        public readonly string URL;
        private List<string> emails = null;

        public WebPage(string name, string URL, int level)
        {
            this.name = name;
            this.level = level;
            this.URL = URL;
        }

        public void AddEmails(List<string> emails)
        {
            this.emails = emails;
        }

        public List<string> GetEmails()
        {
            return emails;
        }

        public bool Equals(WebPage page)
        {
            if (URL.Equals(page.URL)) return true;
            return false;
        }
    }
}
