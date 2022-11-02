using Microsoft.SqlServer.Management.Sdk.Sfc;
using System.Xml.Linq;
using System.Xml.Serialization;
using Xml2CSharp;
using System.Xml;

public class Program
{
    public static List<object> NewsList = new List<object>();

    static void Main(string[] args)
    {
        GetNews();
        
        foreach (Item item in NewsList)
        {
            Console.WriteLine("//");
            Console.WriteLine($"Title: {item.Title}\n - Link: {item.Link}\n - Date: {item.PubDate}");
        }
    }
    static void GetNews()
    {
        var url = $"https://www.dr.dk/nyheder/service/feeds/senestenyt";

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
}