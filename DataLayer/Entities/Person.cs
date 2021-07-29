using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities.Interfaces;

namespace DataLayer.Entities
{
    public class Person : IPatient
    {
        private readonly ICollection<Hospital> _hospitals;

        public Person()
        {
            
        }
        public Person(string firstName, string lastName, string email, string company, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Company = company;
            Age = age;

            _hospitals = new List<Hospital>();
        }
        public Person(string firstName, string lastName, string email, string company, int age, PatientCard patientCard)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Company = company;
            Age = age;
            PatientCard = patientCard;
            _hospitals = new List<Hospital>();
        }
        public int Id { get; set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Company { get; private set; }
        public int Age { get; private set; }
        public ICollection<Hospital> Hospitals { get => _hospitals;}
        public PatientCard PatientCard { get; set; }

        public void SetFirstName(PatientCard patientCard)
        {
            PatientCard = patientCard;
        }
        public void SetFirstName(string firstName)
        {
            FirstName = firstName;
        }
        public void SetLastName(string lastName)
        {
            LastName = lastName;
        }
        public void SetEmail(string email)
        {
            Email = email;
        }
        public void SetCompany(string company)
        {
            Company = company;
        }
        public void SetAge(int age)
        {
            Age = age;
        }
  
    }
}
