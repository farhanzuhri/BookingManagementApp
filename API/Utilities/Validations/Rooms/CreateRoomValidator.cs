using API.DTOs.Rooms;
using FluentValidation;

namespace API.Utilities.Validations.Rooms
{
    public class CreateRoomValidator : AbstractValidator<CreateRoomDto>
    {
        public CreateRoomValidator()
        {
            // Validation rule for Name
            RuleFor(e => e.Name)
                .NotEmpty();

            // Validation rule for Floor
            RuleFor(e => e.Floor)
                .NotEmpty();

            // Validation rule for Capacity
            RuleFor(e => e.Capacity)
                .NotEmpty();
        }
    }
}
