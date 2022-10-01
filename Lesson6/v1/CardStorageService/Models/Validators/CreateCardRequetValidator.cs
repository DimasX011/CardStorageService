using CardStorageService.Models.Requests;
using FluentValidation;
using System.Linq.Expressions;

namespace CardStorageService.Models.Validators
{
    public class CreateCardRequetValidator : AbstractValidator<CreateCardRequest>
    {
        public CreateCardRequetValidator()
        {
           

            RuleFor(x => x.CVV2).NotNull().Length(3).NotEqual("\"string");

            RuleFor(x => x.CardNo)
                    .NotEmpty().CreditCard().NotEqual("\"string");

            RuleFor(x => x.ExpDate).NotEmpty();

            RuleFor(x => x.Name).NotNull().MinimumLength(3).MaximumLength(100).NotEqual("\"string");

            RuleFor(x => x.ClientId).NotEmpty();

        }
    }
}
