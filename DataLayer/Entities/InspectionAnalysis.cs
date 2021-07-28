using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities.Interfaces;

namespace DataLayer.Entities
{
    public class InspectionAnalysis : IAnalysis
    {
        public InspectionAnalysis(int code, bool paid, float cost)
        {
            Code = code;
            Paid = paid;
            Cost = cost;
        }

        public int Code { get; }
        public bool Paid { get; private set; }
        public float Cost { get;  }

        public void Pay()
        {
            Paid = true;
        }
    }

}
