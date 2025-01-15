namespace Artists_Reviews.Interface
{
    public interface IEmailService
    {
        Task SendEmailAsync(string Email, string subject, string message);
    }
}
