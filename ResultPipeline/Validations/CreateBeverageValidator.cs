using FluentValidation;
using ResultPipeline.Commands;

namespace ResultPipeline.Validations
{
    public class CreateBeverageValidator : AbstractValidator<CreateBeverageCommand>
    {
        public CreateBeverageValidator()
        {
            RuleFor(v => v.Name)
                .MaximumLength(200)
                .WithErrorCode("01")
                .NotEmpty()
                .WithErrorCode("02");
        }
    }
}
