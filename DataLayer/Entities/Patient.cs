using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities.Interfaces;

namespace DataLayer.Entities
{
    public class Patient : IPatient
    {
        public Patient()
        {
            
        }
        public int Id { get; set; }
        public string Name { get; }
    }
}
