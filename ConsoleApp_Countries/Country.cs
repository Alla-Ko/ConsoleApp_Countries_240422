using System.Data.Linq.Mapping;

namespace ConsoleApp_Countries
{
    [Table(Name = "Countries")]
    internal class Country
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column]
        public string Name { get; set; }

        [Column]
        public string Capital { get; set; }

        [Column]
        public string Continent { get; set; }

        [Column]
        public int Area { get; set; }

        [Column]
        public int Inhabitants { get; set; }

        public override string ToString()
        {
            return $"{Name}, \x1b[34mСтолиця:\x1b[37m {Capital}, \x1b[34mЧастина світу:\x1b[37m {Continent}, \x1b[34mПлоща:\x1b[37m {Area}, \x1b[34mНаселення:\x1b[37m {Inhabitants}";
        }
    }
}
