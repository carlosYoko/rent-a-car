using RentACar.Domain.Abstractions;

namespace RentACar.Domain.Rents
{
    public static class RentErrors
    {
        public static Error NotFound = new Error(
            "Rent.Found",
            "El alquiler con el Id {} no ha sido encontrado");

        public static Error Overlap = new Error(
            "Rent.Overlap",
            "El alquiler en estas fechas no es posible");

        public static Error NotReserved = new Error(
            "Rent.NotReserved",
            "El alquiler no esta reservado");

        public static Error NotConfirmed = new Error(
            "Rent.NotConfirmed",
            "El alquiler no esta confirmado");

        public static Error AlreadyStarted = new Error(
            "Rent.AlreadyStarted",
            "El alquiler ya ha comenzado");
    }
}