using RentACar.Domain.Abstractions;
using RentACar.Domain.Rents.Events;
using RentACar.Domain.Vehicles;

namespace RentACar.Domain.Rents
{
    public sealed class Rent : Entity
    {
        public Rent(
            Guid id,
            Guid vehicleId,
            Guid userId,
            DateRange duration,
            Currency priceByPeriod,
            Currency maintenance,
            Currency accessories,
            Currency totalPrice,
            RentStatus status,
            DateTime dateCreate
            ) : base(id)
        {
            Id = id;
            VehicleId = vehicleId;
            UserId = userId;
            Duration = duration;
            PriceByPeriod = priceByPeriod;
            Maintenance = maintenance;
            Accessories = accessories;
            TotalPrice = totalPrice;
            Status = status;
            DateCreate = dateCreate;
        }

        #region /*props*/
        public Guid VehicleId { get; private set; }
        public Guid UserId { get; private set; }
        public Currency PriceByPeriod { get; private set; }
        public Currency Maintenance { get; private set; }
        public Currency Accessories { get; private set; }
        public Currency TotalPrice { get; private set; }
        public RentStatus Status { get; private set; }
        public DateRange Duration { get; private set; }
        public DateTime DateCreate { get; private set; }
        public DateTime DateConfirmation { get; private set; }
        public DateTime DateAnulation { get; private set; }
        public DateTime DateCompleted { get; private set; }
        public DateTime DateCancelation { get; private set; }
        #endregion

        public static Rent Book(
            Vehicle vehicle,
            Guid userId,
            DateRange duration,
            DateTime dateCreation,
            PriceService priceService
            )
        {
            var priceDetail = priceService.CalculatePrice(vehicle, duration);

            var rent = new Rent(
                Guid.NewGuid(),
                vehicle.Id,
                userId,
                duration,
                priceDetail.PricePeriod,
                priceDetail.Maintentance,
                priceDetail.Accessories,
                priceDetail.PriceTotal,
                RentStatus.Reserved,
                dateCreation
                );

            rent.RaiseDomainEvent(new RentReservedDoaminEvent(rent.Id));

            vehicle.DateLastRent = dateCreation;

            return rent;
        }

        public Result Confirm(DateTime utcNow)
        {
            if (Status != RentStatus.Reserved)
            {
                return Result.Failure(RentErrors.NotReserved);
            }

            Status = RentStatus.Confirmed;
            DateConfirmation = utcNow;

            RaiseDomainEvent(new RentConfirmedDomainEvent(Id));
            return Result.Success();
        }

        public Result Reject(DateTime utcNow)
        {
            if (Status != RentStatus.Reserved)
            {
                return Result.Failure(RentErrors.NotReserved);
            };

            var currentDate = DateOnly.FromDateTime(utcNow);

            if (currentDate > Duration.Start)
            {
                return Result.Failure(RentErrors.AlreadyStarted);
            }

            Status = RentStatus.Refused;
            DateCancelation = utcNow;

            RaiseDomainEvent(new RentRejectedDomainEvent(Id));
            return Result.Success();
        }

        public Result Complete(DateTime utcNow)
        {
            if (Status != RentStatus.Confirmed)
            {
                return Result.Failure(RentErrors.NotConfirmed);
            };

            Status = RentStatus.Completed;
            DateCompleted = utcNow;

            RaiseDomainEvent(new RentCompletedDomainEvent(Id));
            return Result.Success();
        }
    }
}
