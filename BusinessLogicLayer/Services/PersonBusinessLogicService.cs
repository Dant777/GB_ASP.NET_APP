using System.Collections.Generic;
using System.Linq;
using BusinessLogicLayer.Validation.Interfaces;
using BusinessLogicLayer.Validation.Operations;
using DataLayer.Entities;

namespace BusinessLogicLayer.Services
{
    public sealed class PersonBusinessLogicService : IPersonBusinessLogicService
    {
        private readonly IPersonValidationService _validationService;

        public PersonBusinessLogicService()
        {
            
        }
        public PersonBusinessLogicService(IPersonValidationService validationService)
        {
            _validationService = validationService;
        }

        public IOperationResult<Person> Create(Person user)
        {
            IReadOnlyList<IOperationFailure> failures = _validationService.ValidateEntity(user);

            if (failures.Count > 0)
            {
                var errors = failures
                    .Select(e => new OperationFailure(e.PropertyName, e.Description, e.Code)).ToArray();
                return new OperationResult<Person>(errors);
            }
            else
            {
                return new OperationResult<Person>(user);
            }
        }
    }

}
