// Et objekt kan initialiseres uden en constructor, men alene via sine properties
// Derved undgår vi at skulle lave constructors, specielt hvis der skal være
// mulighed for at initialisere med forskelligt antal parametre.

namespace LINQexercises
{
    class ObjectInitializer
    {
        static void Main(string[] args)
        {
            var data = new ProcessData
            {
                Id = 123,
                Name = "MyProcess",
                Memory = 123456
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
