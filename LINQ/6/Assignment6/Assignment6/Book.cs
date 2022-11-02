using System.Xml.Linq;

namespace Assignment6
{
    // Opret en Book klasse med nogle properties med forskellige datatyper.Opret et antal objekter af Book klassen
    // med nogle forskellige værdier og lad en List<T> collection holde sammen på dem.
    // Lav en Save() og Load() metode, der serialiserer objekter ned til et JSON-array og gemmer dem i en fil.
    // Derefter skal der laves en deserialization og objekterne udskrives.
    public class Book
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public bool Available { get; set; }

        public void Save()
        {

        }
    }
}
