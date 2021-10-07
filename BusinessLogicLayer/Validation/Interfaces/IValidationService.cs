using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Validation.Interfaces
{
    public interface IValidationService<TEntity>
    {

        IReadOnlyList<IOperationFailure> ValidateEntity(TEntity item);

    }
}
