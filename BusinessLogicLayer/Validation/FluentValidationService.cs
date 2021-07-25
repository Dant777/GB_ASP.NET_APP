using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Validation.Interfaces;
using BusinessLogicLayer.Validation.Operations;
using FluentValidation;
using FluentValidation.Results;

namespace BusinessLogicLayer.Validation
{
    public abstract class FluentValidationService<TEntity> : AbstractValidator<TEntity>, IValidationService<TEntity>
    {
        public IReadOnlyList<IOperationFailure> ValidateEntity(TEntity item)
        {
            ValidationResult result = Validate(item);

            if (result is null || result.Errors.Count == 0)
            {
                return ArraySegment<IOperationFailure>.Empty;
            }

            List<IOperationFailure> failures = new List<IOperationFailure>(result.Errors.Count);

            foreach (ValidationFailure error in result.Errors)
            {
                OperationFailure failure = new OperationFailure(error.PropertyName, error.ErrorMessage, error.ErrorCode);

                failures.Add(failure);

            }

            return failures;
        }
    }
}
