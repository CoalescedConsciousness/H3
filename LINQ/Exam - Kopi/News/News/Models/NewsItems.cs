using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace News.Models
{
    [XmlRoot(ElementName = "item")]
    public class Item
    {
        public int ItemId { get; set; }
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        [XmlElement(ElementName = "link")]
        public string Link { get; set; }
      
        [XmlElement(ElementName = "pubDate")]
        public string PubDate { get; set; }
    }

}
