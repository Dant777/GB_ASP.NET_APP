using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Hospital
    {
        
        
        private readonly ICollection<Person> _persons;


        public Hospital(string name)
        {

            Name = name;

            _persons = new List<Person>();
        }

        public int Id { get; set; }

        public string Name { get; private set; }

        public ICollection<Person> Persons => _persons;

        public void SetName(string name)
        {
            Name = name;
        }
    }
}
