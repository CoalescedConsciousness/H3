using Microsoft.SqlServer.Management.Sdk.Sfc;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml;
using News.Models;
using News.Helpers;
using EFGetStarted;

public class Program
{
    // Contains a list of articles outside of DB
    public static List<object> NewsList = new List<object>();
    
    // Enables logging on/off
    public static bool DoPrint;

    // List of URLs to get news from
    public static List<string> NewsSites = new List<string>{
        "https://www.dr.dk/nyheder/service/feeds/senestenyt",
        "https://www.dr.dk/nyheder/service/feeds/udland"
    };

    static void Main(string[] args)
    {

        GetNews();
        PrintNews();
        NewsHelpers.LoadFirstArticle();
        NewsHelpers.LoadLatestArticle();

    }
    #region DB


    /// <summary>
    /// Inserts newsitems into DB
    /// </summary>
    static void InsertNewsItems()
    {
        using (var context = new NewsContext())
        {
            foreach (Item item in NewsList)
            {
                context.NewsItems.Add(new Item
                {
                    Title = item.Title,
                    Link = item.Link,
                    PubDate = item.PubDate,
                });
            }
            context.SaveChanges();
        }
    }
    #endregion

    #region CRUD
    /// <summary>
    /// Prints fields for each news item in the static list
    /// </summary>
    static void PrintNews()
    {
        if (!DoPrint) return;

        foreach (Item item in NewsList)
        {
            
            Console.WriteLine("//");
            Console.WriteLine($"Title: {item.Title}\n - Link: {item.Link}\n - Date: {item.PubDate}");
        }
    }

    /// <summary>
    /// Gets news articles from one or more feeds
    /// </summary>
    static void GetNews()
    {
        //var url = $"https://www.dr.dk/nyheder/service/feeds/senestenyt";
        foreach (string url in NewsSites)
        {
            // title, link, pubDate
            XDocument doc = XDocument.Load(url);
            var newsItems = new XElement("newsItems");
            foreach (var item in doc.Descendants("item"))
            {

                StringReader sr = new StringReader(item.ToString());
                XmlSerializer serial = new XmlSerializer(typeof(Item));
                XmlTextReader reader = new XmlTextReader(sr);
                object obj = serial.Deserialize(reader);
                NewsList.Add(obj);
            };

        }
        InsertNewsItems(); 
    }
    #endregion

 
}