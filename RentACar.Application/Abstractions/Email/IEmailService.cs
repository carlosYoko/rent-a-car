namespace RentACar.Application.Abstractions.Email
{
    public interface IEmailService
    {
        Task SendAsync(RentACar.Domain.Users.Email recipient, string subject, string body);
    }
}