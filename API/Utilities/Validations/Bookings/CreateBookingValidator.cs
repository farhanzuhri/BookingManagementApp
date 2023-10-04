using API.DTOs.Bookings;
using FluentValidation;

namespace API.Utilities.Validations.Bookings
{
    public class CreateBookingValidator : AbstractValidator<CreateBookingDto>
    {
        public CreateBookingValidator()
        {
            RuleFor(b => b.StartDate)
                .NotEmpty();

            //tidak boleh kosong dan lebih besar dari startdate
            RuleFor(b => b.EndDate)
                .NotEmpty()
                .GreaterThan(b => b.StartDate);

            RuleFor(b => b.Status)
                .NotEmpty();

            RuleFor(b => b.Remarks)
                .NotEmpty();

            RuleFor(b => b.RoomGuid)
                .NotEmpty();

            RuleFor(b => b.EmployeeGuid)
                .NotEmpty();
        }
    }
}
