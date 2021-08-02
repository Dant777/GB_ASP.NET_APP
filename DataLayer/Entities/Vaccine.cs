using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities.Interfaces;

namespace DataLayer.Entities
{
    public class Vaccine : IVaccine
    {
        public Vaccine(string name, float cost)
        {
            Name = name;
            Cost = cost;
        }

        public int Id { get; set; }
        public string Name { get; }
        public float Cost { get; }
        public bool Paid { get; private set; }
        public bool Vaccineded { get; private set; }

        public void Pay()
        {
            Paid = true;
        }

        public void SetVaccine()
        {
            Vaccineded = true;
        }
    }

}
