using FluentValidation;
using ShipManagement.Domain.Entities;

namespace ShipManagement.Application.Validators
{
    public class ShipValidator : AbstractValidator<Ship>
    {
        public ShipValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(x => x.Length).GreaterThan(4).WithMessage("Length cannot be less than 5").LessThan(601).WithMessage("Length cannot be greater than 600");
            RuleFor(x => x.Width).GreaterThan(0).WithMessage("Width cannot be less than 1").LessThan(101).WithMessage("Width cannot be greater than 100");
            RuleFor(x => x.Code).Matches("^(([a-zA-Z]{4})-([0-9]{4})-([a-zA-Z][0-9]))$").WithMessage("Code must follow the format: AAAA-1111-A1");
        }
    }
}
