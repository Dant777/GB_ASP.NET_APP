using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Validation.Interfaces;

namespace BusinessLogicLayer.Validation.Operations
{
    public class OperationResult<TResult> : IOperationResult<TResult>
    {
        public OperationResult()
        {
            
        }
        public OperationResult(TResult result)
        {
            Result = result;
            Succeed = true;
        }

        public OperationResult(IReadOnlyList<IOperationFailure> failures)
        {
            Failures = failures;
            Succeed = false;
        }
        public TResult Result { get; }
        public IReadOnlyList<IOperationFailure> Failures { get; }
        public bool Succeed { get; }
    }
}
