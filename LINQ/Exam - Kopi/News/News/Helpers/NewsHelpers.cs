using EFGetStarted;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using News;
using News.Models;

namespace News.Helpers
{
    public class NewsHelpers
    {
        public static void PrintItem(Item item)
        {
            Console.WriteLine($"> {item.Title}\n - {item.Link}\n - {item.PubDate}");
        }
        public static void LoadFirstArticle()
        {
            Console.WriteLine("\n.......Loading first News item in DB");
            using (var con = new NewsContext())
            {
                var item = con.NewsItems.First();
                PrintItem(item);
            }
        }
        public static void LoadLatestArticle()
        {
            Console.WriteLine("\n.........Loading latest News item");
            using (var con = new NewsContext())
            {
                var item = con.NewsItems
                    .OrderBy(x => x.PubDate)
                    .FirstOrDefault();
                PrintItem(item);
            }
        }
    }
}
