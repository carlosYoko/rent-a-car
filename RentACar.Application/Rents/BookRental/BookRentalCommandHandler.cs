using RentACar.Application.Abstractions.Clock;
using RentACar.Application.Abstractions.Messaging;
using RentACar.Domain.Abstractions;
using RentACar.Domain.Rents;
using RentACar.Domain.Users;
using RentACar.Domain.Vehicles;

namespace RentACar.Application.Rents.BookRental
{
    internal sealed class BookRentalCommandHandler : ICommandHandler<BookRentalCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IRentRepository _rentRepository;
        private readonly PriceService _priceService;
        private readonly IServiceProvider _serviceProvider;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider;

        public BookRentalCommandHandler(
            IUserRepository userRepository,
            IVehicleRepository vehicleRepository,
            IRentRepository rentRepository,
            PriceService priceService,
            IServiceProvider serviceProvider,
            IUnitOfWork unitOfWork,
            IDateTimeProvider dateTimeProvider)
        {
            _userRepository = userRepository;
            _vehicleRepository = vehicleRepository;
            _rentRepository = rentRepository;
            _priceService = priceService;
            _serviceProvider = serviceProvider;
            _unitOfWork = unitOfWork;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<Result<Guid>> Handle(BookRentalCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.userId, cancellationToken);

            if (user == null)
            {
                return Result.Failure<Guid>(UserErrors.NotFound);
            }

            var vehicle = await _vehicleRepository.GetByIdAsync(request.vehicleId, cancellationToken);

            if (vehicle == null)
            {
                return Result.Failure<Guid>(VehicleErrors.NotFound);
            }

            var duration = DateRange.Create(request.dateInit, request.dateFinish);

            if (await _rentRepository.IsOverLappingAsync(vehicle, duration, cancellationToken))
            {
                return Result.Failure<Guid>(RentErrors.Overlap);
            }

            var rent = Rent.Book(vehicle, user.Id, duration, _dateTimeProvider.currentTime, _priceService);

            _rentRepository.Add(rent);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return rent.Id;
        }
    }
}
