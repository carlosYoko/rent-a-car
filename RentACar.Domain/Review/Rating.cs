using RentACar.Domain.Abstractions;

namespace RentACar.Domain.Review
{
    public sealed record Rating
    {
        public static readonly Error Invalid = new Error(
            "Rating.Invalid", "La puntuacion tiene que ser entre 1 y 5");

        public int Value { get; init; }

        private Rating(int value) => Value = value;

        public static Result<Rating> Create(int value)
        {
            if (value < 1 || value > 5)
            {
                return Result.Failure<Rating>(Invalid);
            }

            return new Rating(value);
        }
    }
}
