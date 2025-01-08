using RentACar.Domain.Abstractions;
using RentACar.Domain.Rents;
using RentACar.Domain.Review.Events;

namespace RentACar.Domain.Review
{
    public sealed class Review : Entity
    {
        private Review() { }
        private Review(
            Guid id,
            Guid vehicleId,
            Guid rentId,
            Guid userId,
            Rating rating,
            Comment comment,
            DateTime dateCreation
            ) : base(id)
        {
            VehicleId = vehicleId;
            RentId = rentId;
            UserId = userId;
            Rating = rating;
            Comment = comment;
            DateCreation = dateCreation;
        }

        public Guid VehicleId { get; private set; }
        public Guid RentId { get; private set; }
        public Guid UserId { get; private set; }
        public Rating Rating { get; private set; }
        public Comment? Comment { get; private set; }
        public DateTime DateCreation { get; private set; }

        public static Result<Review> Create(
            Rent rent,
            Rating rating,
            Comment comment,
            DateTime dateCreation
            )
        {
            if (rent.Status != RentStatus.Completed)
            {
                return Result.Failure<Review>(ReviewErrors.NotElegible);
            }

            var review = new Review(
                Guid.NewGuid(),
                rent.VehicleId,
                rent.Id,
                rent.UserId,
                rating,
                comment,
                dateCreation
                );

            review.RaiseDomainEvent(new ReviewCreateDomainEvent(review.Id));

            return review;
        }
    }
}
