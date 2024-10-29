using AutoDealer.Models;

namespace AutoDealer.Interfaces
{
    public interface IEmailService
    {
        Task SendEmail(EmailDto contact);
    }
}
