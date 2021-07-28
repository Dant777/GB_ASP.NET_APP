using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicLayer.Specification;
using DataLayer.Entities.Interfaces;

namespace BusinessLogicLayer.AggregationRoot
{
    public class PatientCard
    {
        private IList<IAnalysis> _analyses;

        public PatientCard(IPatient patient)
        {
            Patient = patient;
        }

        public IPatient Patient { get; }

        public void SetAnalysis(IAnalysis analysis)
        {
            if (_analyses.HasAlreadyAdded(analysis))
            {
                throw new ArgumentException();
            }
            _analyses.Add(analysis);
        }

        public bool HasPadingPayment()
        {
            return _analyses.PendingPaymentAmount() > 0;
        }

        public void SetPedingPaymentAsPaid()
        {
            foreach (var pending in _analyses.PadingPaiment())
            {
                pending.Pay();
            }
        }
    }
}
