using FluentValidation;
using HotelZZ.Application.Common.Files.Validators;
using HotelZZ.Application.Features.Rooms.Commands.CreateRoom;

namespace HotelZZ.Application.Features.rooms.Commands.CreateRoom
{
    public class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
    {
        public CreateRoomCommandValidator()
        {
            RuleFor(x => x.RoomNumber)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.Capacity)
                .GreaterThan(0);

            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(500);

            RuleFor(x => x.PricePerNight)
                .GreaterThan(0);

            RuleFor(x => x.HotelId)
                .GreaterThan(0);

            RuleFor(x => x.RoomTypeId)
                .GreaterThan(0);

            When(x => x.AmenityIds is not null && x.AmenityIds.Count > 0, () =>
            {
                RuleFor(x => x.AmenityIds!)
                    .Must(ids => ids.Distinct().Count() == ids.Count)
                    .WithMessage("Amenity IDs must be unique.");

                RuleForEach(x => x.AmenityIds!)
                    .GreaterThan(0)
                    .WithMessage("Amenity ID must be greater than 0.");
            });

            When(x => x.Images is not null && x.Images.Count > 0, () =>
            {
                RuleFor(x => x.Images!.Count)
                    .LessThanOrEqualTo(5)
                    .WithMessage("A maximum of 5 images is allowed.");

                RuleForEach(x => x.Images!)
                    .SetValidator(new ImageValidator());
            });
        }
    }
}