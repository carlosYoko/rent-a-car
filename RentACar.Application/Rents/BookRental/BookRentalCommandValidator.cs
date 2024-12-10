using FluentValidation;

namespace RentACar.Application.Rents.BookRental
{
    public class BookRentalCommandValidator : AbstractValidator<BookRentalCommand>
    {
        public BookRentalCommandValidator()
        {
            RuleFor(c => c.userId).NotEmpty();
            RuleFor(c => c.vehicleId).NotEmpty();
            RuleFor(c => c.dateInit).LessThan(c => c.dateFinish);
        }
    }
}
