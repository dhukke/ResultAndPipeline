using FluentValidation;
using ResultPipeline.Commands;

namespace ResultPipeline.Validations
{
    public class CreateFoodValidator : AbstractValidator<CreateFoodCommand>
    {
        public CreateFoodValidator()
        {
            RuleFor(v => v.Name)
                .MaximumLength(200)
                .WithErrorCode("01")
                .NotEmpty()
                .WithErrorCode("02");
        }
    }
}
