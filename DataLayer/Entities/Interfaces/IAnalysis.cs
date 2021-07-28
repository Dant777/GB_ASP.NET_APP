using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.Interfaces
{
    public interface IAnalysis
    {
        public int Code { get; }
        public bool Paid { get; }
        public float Cost { get; }
        public void Pay();
    }
}
