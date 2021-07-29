using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.Interfaces
{
    public interface IVaccine
    {
        public int Id { get; set; }
        public string Name { get; }
        public bool Paid { get; }
        public float Cost { get; }
        public bool Vaccineded { get; }
        public void Pay();
        public void SetVaccine();
    }
}
