using Assignment6;
using System;
using System.IO;
using System.Text.Json;

public class Program
{
    public static void Main()
    {
        var savefile = "savefile.json";
        var Book1 = new Book
        {
            Title = "Test book 1",
            PageCount = 100,
            Available = true,
        };
        Save(Book1, savefile);
        Book loadedBook = Load(savefile);
        Console.WriteLine("---");
        Console.WriteLine("Loaded:");
        Console.WriteLine(loadedBook.ToString());

        static void Save(Book b, string savefile)
        {
            var opt = new JsonSerializerOptions { WriteIndented = true };
            string toJson = JsonSerializer.Serialize(b, opt);

            File.WriteAllText(savefile, toJson);
            Console.WriteLine($"Saved: \n\n {toJson}");
        }
        static Book Load(string loadfile)
        {
            
            using (Stream stream = new FileStream(loadfile, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                string contents = "";
                using (StreamReader reader = new StreamReader(stream))
                {
                    contents = reader.ReadToEnd();
                };
                Book b = JsonSerializer.Deserialize<Book>(contents);
                return b;
            };


        }
    }
}
