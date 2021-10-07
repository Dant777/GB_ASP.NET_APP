using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer.Entities.Interfaces;

namespace DataLayer.Entities
{
    public class PatientCard
    {
        private IList<IVaccine> _vaccines;

        public PatientCard()
        {
                
        }
        public PatientCard(IPatient patient)
        {
            Patient = patient;
            _vaccines = new List<IVaccine>();
        }

        public int  Id { get; set; }
        public IPatient Patient { get; }
        public IList<IVaccine> Vaccines
        {
            get => _vaccines;
        }
        public bool RegisterVaccine(IVaccine vaccine)
        {
            if (_vaccines.Any(a => a.Name == vaccine.Name))
            {
                return false;
            }
            _vaccines.Add(vaccine);
            return true;
        }
        public void SetAsPaid(IVaccine vaccine)
        {
            var vac = _vaccines.FirstOrDefault(x => x.Name == vaccine.Name);
            if (vac != null)
            {
                vac.Pay();
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void SetVaccine(IVaccine vaccine)
        {
            var vac = _vaccines.FirstOrDefault(x => x.Name == vaccine.Name);
            if (!vac.Paid)
            {
                throw new ArgumentException();
            }

            if (vac.Vaccineded)
            {
                throw new ArgumentException();
            }
            vac.SetVaccine();
        }

    }
}
