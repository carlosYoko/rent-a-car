using RentACar.Domain.Abstractions;

namespace RentACar.Domain.Review.Events
{
    public static class ReviewErrors
    {
        public static readonly Error NotElegible = new Error(
            "Review.NotElegible", "El alquiler todavia no se ha completado y no se puede comentar");
    }
}
