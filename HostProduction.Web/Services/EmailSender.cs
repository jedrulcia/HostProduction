using SendGrid.Helpers.Mail;
using SendGrid;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace HostProduction.Web.Services
{
	public class EmailSender : IEmailSender
	{
		private readonly string sendGridConnectionString;
		private readonly string sendFromEmailAddress;
		private readonly string sendToEmailAddress;

		public EmailSender(string sendGridConnectionString, string sendFromEmailAddress, string sendToEmailAddress)
		{
			this.sendGridConnectionString = sendGridConnectionString;
			this.sendFromEmailAddress = sendFromEmailAddress;
			this.sendToEmailAddress = sendToEmailAddress;
		}
		public async Task SendEmailAsync(string? email, string subject, string htmlMessage)
		{
			var client = new SendGridClient(sendGridConnectionString);

			var sendFrom = new EmailAddress(sendFromEmailAddress);
			var sendTo = new EmailAddress(sendToEmailAddress);

			var message = MailHelper.CreateSingleEmail(sendFrom, sendTo, subject, "", htmlMessage);
			var response = await client.SendEmailAsync(message);
		}
	}
}
