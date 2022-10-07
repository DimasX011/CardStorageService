using CardStorageService.Models.Requests;
using FluentValidation;

namespace CardStorageService.Models.Validators
{
    public class CreateClientRequestValidator : AbstractValidator<CreateClientRequest>
    {
        public CreateClientRequestValidator()
        {
            RuleFor(x => x.FirstName).NotNull().Length(3, 50).NotEqual("string");

            RuleFor(x => x.Patronymic).NotNull().Length(3, 75).NotEqual("string");
            RuleFor(x => x.Surname).NotNull().Length(3, 50).NotEqual("string");
        }
    }
}
