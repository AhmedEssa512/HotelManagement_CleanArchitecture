using FluentValidation;
using HotelZZ.Application.Common.Files.Validators;

namespace HotelZZ.Application.Features.Hotels.Commands.CreateHotel
{
    public class CreateHotelCommandValidator : AbstractValidator<CreateHotelCommand>
    {
        public CreateHotelCommandValidator()
        {
            RuleFor(h => h.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters");

             RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required")
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required")
                .MaximumLength(200).WithMessage("Address must not exceed 200 characters");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City is required")
                .MaximumLength(50).WithMessage("City must not exceed 50 characters");

            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("Country is required")
                .MaximumLength(50).WithMessage("Country must not exceed 50 characters");

            RuleFor(x => x.Image)
            .SetValidator(new ImageValidator())
            .When(x => x.Image is not null);
        }
        
    }
}