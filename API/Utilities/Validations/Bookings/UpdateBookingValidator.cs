using API.DTOs;
using FluentValidation;

namespace API.Utilities.Validations.Bookings
{
    public class UpdateBookingValidator : AbstractValidator<BookingDto>
    {
        public UpdateBookingValidator()
        {
            RuleFor(e => e.Guid)
                .NotEmpty();

            RuleFor(e => e.StartDate)
                .NotEmpty();

            RuleFor(b => b.EndDate)
                .NotEmpty()
                .GreaterThan(b => b.StartDate);

            RuleFor(e => e.Status)
                .NotEmpty().IsInEnum();

            RuleFor(e => e.Remarks)
                .NotEmpty();

            RuleFor(e => e.RoomGuid)
                .NotEmpty();

            RuleFor(e => e.EmployeeGuid)
                .NotEmpty();
        }
    }
}
