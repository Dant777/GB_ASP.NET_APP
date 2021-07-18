using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;

namespace DataLayer.Request
{
    public class ClinicRequest
    {
        public string Name { get; set; }
        public ICollection<Person> Persons { get; set; }
    }
}
