using System.Collections.Generic;

namespace DataLayer.Entities
{
    public class Clinic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Person> Persons { get; set; }
    }
}