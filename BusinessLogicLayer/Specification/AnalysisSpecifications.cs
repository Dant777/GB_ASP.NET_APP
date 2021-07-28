using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities.Interfaces;

namespace BusinessLogicLayer.Specification
{
    public static class AnalysisSpecifications
    {
        public static bool HasAlreadyAdded(this IEnumerable<IAnalysis> collection, IAnalysis analysis)
        {
            return collection.Any(a => a.Code == analysis.Code);
        }

        public static float PendingPaymentAmount(this IEnumerable<IAnalysis> collection)
        {
            return collection.PadingPaiment().Sum(a => a.Cost);
        }

        public static IEnumerable<IAnalysis> PadingPaiment(this IEnumerable<IAnalysis> collection)
        {
            return collection.Where(a => !a.Paid);
        }
    }
}
