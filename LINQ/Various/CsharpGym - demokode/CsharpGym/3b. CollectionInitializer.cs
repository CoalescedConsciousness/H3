// Collection Initializer erstatter et antal .Add() linier.
// Eksemplet benytter også Object Initializer til de enkelte ProcessData objekter.

using System.Collections.Generic;

namespace LINQexercises
{
    class CollectionInitializer
    {
        static void Main(string[] args)
        {
            var processes = new List<ProcessData> 
            {
                new ProcessData {Id = 123, Name = "devenv", Memory = 123456},
                new ProcessData {Id = 234, Name = "firefox", Memory = 654321}
            };
        }
    }

    class ProcessData
    {
        public int Id { get; set; }
        public long Memory { get; set; }
        public string Name { get; set; }
    }
}
