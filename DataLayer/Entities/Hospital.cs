using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities.Interfaces;

namespace DataLayer.Entities
{
    public class Hospital
    {

        private readonly ICollection<Person> _persons;
        private readonly ICollection<PatientCard> _patientCards;

        public Hospital(string name)
        {

            Name = name;

            _persons = new List<Person>();
            _patientCards = new List<PatientCard>();
        }

        public int Id { get; set; }

        public string Name { get; private set; }

        public ICollection<Person> Persons => _persons;
        public ICollection<PatientCard> PatientCard => _patientCards;

        public void SetName(string name)
        {
            Name = name;
        }

        public void AddCard(Person person)
        {
            var patient = _persons.FirstOrDefault(x => x.FirstName == person.FirstName);
            if (patient == null)
            {
                return;
            }
            _patientCards.Add(new PatientCard());
        }

        public void PaymentVaccine(IVaccine vaccine, Person person, float money)
        {
             
            if (!_persons.Any(x => x.FirstName == person.FirstName))
            {
                return;
            }

            var cart = _patientCards.FirstOrDefault(x => x.Patient.FirstName == person.FirstName);

            if (money < vaccine.Cost)
            {
                return;
            }

            bool result = cart.RegisterVaccine(vaccine);
            if (result)
            {
                
                cart.SetAsPaid(vaccine);
            }
            else
            {
                var vac = cart.Vaccines.FirstOrDefault(x => x.Name == vaccine.Name);
                if (!vac.Paid)
                {
                    cart.SetAsPaid(vaccine);
                }
                
            }
        }

        public void SetVaccine(IVaccine vaccine, Person person)
        {
            if (!_persons.Any(x => x.FirstName == person.FirstName))
            {
                return;
            }

            var cart = _patientCards.FirstOrDefault(x => x.Patient.FirstName == person.FirstName);
            var vac = cart.Vaccines.FirstOrDefault(x => x.Name == vaccine.Name);
          
            cart.SetVaccine(vaccine);
            
        }
    }
}
