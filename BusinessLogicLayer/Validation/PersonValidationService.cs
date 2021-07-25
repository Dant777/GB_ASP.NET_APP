using BusinessLogicLayer.Validation.Interfaces;
using DataLayer.Entities;
using FluentValidation;

namespace BusinessLogicLayer.Validation
{
    public sealed class PersonValidationService: FluentValidationService<Person>, IPersonValidationService
    {
        
        public PersonValidationService()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("Имя не должно быть пустым")
                .WithErrorCode("BRL-100.1");
            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Фамилия не должна быть пустым")
                .WithErrorCode("BRL-100.2");
            RuleFor(x => x.Company)
                .NotEmpty()
                .WithMessage("Компания не должно быть пустым")
                .WithErrorCode("BRL-100.3");
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Пустой или некорректная почта")
                .WithErrorCode("BRL-100.4");
            RuleFor(x => x.Age)
                .NotEmpty()
                .Must(IsCorrectPersonAge)
                .WithMessage("Невведен возраст или некорректный возраст")
                .WithErrorCode("BRL-100.5");

        }

        private bool IsCorrectPersonAge(int age)
        {
            if (age > 1 &&  age < 140)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
