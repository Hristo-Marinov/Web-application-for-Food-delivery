namespace FoodEx.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(EmailMessageViewModel emailMessage);
    }
}
