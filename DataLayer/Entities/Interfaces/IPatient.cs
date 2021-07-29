using System.Collections.Generic;

namespace DataLayer.Entities.Interfaces
{
    public interface IPatient
    {
        public int Id { get; set; }
        public string FirstName { get;  }
        public string LastName { get; }
        public string Email { get;  }
        public string Company { get;  }
        public int Age { get;  }
        public ICollection<Hospital> Hospitals { get; }
        public PatientCard PatientCard { get; }
    }
}
