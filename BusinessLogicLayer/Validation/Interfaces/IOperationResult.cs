using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Validation.Interfaces
{
    public interface IOperationResult<TResult>
    {
        TResult Result { get; }

        IReadOnlyList<IOperationFailure> Failures { get; }

        bool Succeed { get; }
    }
}
