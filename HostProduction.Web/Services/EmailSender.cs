using SendGrid.Helpers.Mail;
using SendGrid;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace HostProduction.Web.Services
{
	public class EmailSender : IEmailSender
	{
		private readonly string sendGridConnectionString;
		private readonly string sendFromEmailAddress;

		public EmailSender(string sendGridConnectionString, string sendFromEmailAddress)
		{
			this.sendGridConnectionString = sendGridConnectionString;
			this.sendFromEmailAddress = sendFromEmailAddress;
		}
		public async Task SendEmailAsync(string email, string subject, string htmlMessage)
		{
			var client = new SendGridClient(sendGridConnectionString);

			var sendFrom = new EmailAddress(sendFromEmailAddress);
			var sendTo = new EmailAddress(email);

			var message = MailHelper.CreateSingleEmail(sendFrom, sendTo, subject, "", htmlMessage);
			var response = await client.SendEmailAsync(message);
		}
	}
}
