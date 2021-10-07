using BusinessLogicLayer.Validation.Interfaces;
using DataLayer.Entities;

namespace BusinessLogicLayer.Services
{
    public interface IPersonBusinessLogicService
    {
        IOperationResult<Person> Create(Person user);
    }
}
