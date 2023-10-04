using API.DTOs.Rooms;
using FluentValidation;

namespace API.Utilities.Validations.Rooms
{
    public class UpdateRoomValidator : AbstractValidator<RoomDto>
    {
        public UpdateRoomValidator()
        {
            RuleFor(e => e.Guid)
                .NotEmpty(); 

            RuleFor(e => e.Name)
                .NotEmpty().MaximumLength(100);

            RuleFor(e => e.Floor)
                .NotEmpty(); 

            RuleFor(e => e.Capacity)
                .NotEmpty(); 
        }
    }
}
