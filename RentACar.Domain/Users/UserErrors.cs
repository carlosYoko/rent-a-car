using RentACar.Domain.Abstractions;

namespace RentACar.Domain.Users
{
    public static class UserErrors
    {
        public static Error NotFound = new Error("User.Found", "El ID de usuario no existe");
        public static Error InvalidCredentials = new Error("User.InvalidCredentials", "La credencial es incorrecta");
    }
}
