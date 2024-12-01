using MediatR;
using RentACar.Application.Abstractions.Email;
using RentACar.Domain.Rents;
using RentACar.Domain.Rents.Events;
using RentACar.Domain.Users;

namespace RentACar.Application.Rents.BookRental
{
    internal sealed class BookRentalDomainEventHandler : INotificationHandler<RentBookedDoaminEvent>
    {
        private readonly IRentRepository _rentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;

        public BookRentalDomainEventHandler(IRentRepository rentRepository, IUserRepository userRepository, IEmailService emailService)
        {
            _rentRepository = rentRepository;
            _userRepository = userRepository;
            _emailService = emailService;
        }

        public async Task Handle(RentBookedDoaminEvent notification, CancellationToken cancellationToken)
        {
            var rent = await _rentRepository.GetByIdAsync(notification.RentId, cancellationToken);
            if (rent == null)
            {
                return;
            }

            var user = await _userRepository.GetByIdAsync(rent.UserId, cancellationToken);
            if (user == null)
            {
                return;
            }

            await _emailService.SendAsync(
                user.Email,
                "Reserva de tu vehiculo",
                "Confirma la reserva para continuar con el proceso de alquiler.");
        }
    }
}
