using BoogieApp.BoogieFuelme.Model;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Xamarin.Forms;

namespace BoogieApp.VerificationConfigs
{
    public static class Configs
    {
        /// <summary>
        /// These are all my Application.Current.Properties[]
        /// </summary>
        /// <param name="code"> Application.Current.Properties["VerificationCode"] </param>
        /// <returns></returns>


        public static async Task<StatusResponse> VerifyPhonenumberorEmail(string phonenumber, string email)
        {
            StatusResponse status = new StatusResponse();

            Random random = new Random();
            var code = random.Next(1000, 9999);
            const string accountSid = "AC1f815e6c6da5912897ef072beb251811";
            const string authToken = "6b4b643a8683eec2bd69917fa4250c5c";

            Application.Current.Properties["VerificationCode"] = code;
            await Application.Current.SavePropertiesAsync();

            await Task.Run(() =>
            {

                TwilioClient.Init(accountSid, authToken);

                var message = MessageResource.Create(
                    body: $"Your Verification Code is {code}",
                    from: new Twilio.Types.PhoneNumber("+12029521263"),
                    to: new Twilio.Types.PhoneNumber($"+234{phonenumber}"));


                if (message.Status.ToString() == "queued")
                {

                    status.code = 200;

                    status.message = "success";

                }
                else
                {

                    status.code = 402;

                    status.message = "failed";

                }

            });

            if (status.code == 200)
            {
                await ExecuteEmail(email, code);
            }

          //  status.code = 200;
            return status;

            
        }

        public static StatusResponse VerifyCode(string writtenCode)
        {
            StatusResponse status = new StatusResponse();
            var code = Application.Current.Properties["VerificationCode"].ToString();

            if (code == writtenCode)
            {

                status.code = 200;

                status.message = "success";

            }
            else
            {

                status.code = 402;

                status.message = "failed";

            }

            return status;

        }

        static async Task ExecuteEmail(string email, int code)
        {
            Environment.SetEnvironmentVariable("SENDGRID_API_KEY", "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");
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");     
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("Hello@boogie.ng");
            var subject = "Your Verification Code";
            var to = new EmailAddress($"{email}");
            var plainTextContent = $"Your Verification Code is {code}";
            var htmlContent = $"<strong>{plainTextContent}</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
        }
    }
}
