using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace RedcapService.Models
{
    public class EmailNotification
    {
        internal static System.Threading.Tasks.Task SnedEmail(RedcapPost redcapPost)
        {
            try
            {
                StringBuilder emailBuilder = new StringBuilder();
                emailBuilder.AppendLine("Please click on the link to go to the project");
                emailBuilder.AppendLine("<br/>");
                emailBuilder.AppendLine("<ul style=\"list-style-type: none;\">");
                emailBuilder.AppendFormat("<li>Project URL: {0}</li>", redcapPost.project_url);
                emailBuilder.AppendFormat("<li>Record: {0}</li>", redcapPost.record);
                emailBuilder.AppendFormat("<li>UserName: {0}</li>", redcapPost.username);
                emailBuilder.AppendFormat("<li>Instrument: {0}</li>", redcapPost.instrument);
                emailBuilder.AppendFormat("<li>EventName: {0}</li>", redcapPost.redcap_event_name);
                emailBuilder.AppendLine("</ul>");

                emailBuilder.AppendFormat("<div style=\"display: none;\">{0}</div>", Guid.NewGuid());

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["EmailFrom"]);

                string[] mailToList = ConfigurationManager.AppSettings["EmailTo"].Split(';');
                foreach (var mailTo in mailToList)
                {
                    mailMessage.To.Add(mailTo);
                }
                
                mailMessage.Subject = ConfigurationManager.AppSettings["EmailSubject"];
                mailMessage.Body = emailBuilder.ToString();

                mailMessage.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient(ConfigurationManager.AppSettings["EmailHost"]);
                smtp.Port = Int32.Parse(ConfigurationManager.AppSettings["EmailPort"]); ;
                smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["EmailFrom"], ConfigurationManager.AppSettings["EmailPass"]);
                smtp.EnableSsl = true;
                smtp.Send(mailMessage);
            }
            catch (Exception ex)
            {
                ApplicationDbContext context = new ApplicationDbContext();
                var redcapDET = new RedcapDET
                {
                    ProjectId = redcapPost.project_id,
                    UserName = redcapPost.username,
                    Instrument = redcapPost.instrument,
                    RecordName = redcapPost.record,
                    EventName = redcapPost.redcap_event_name,
                    ProjectUrl = redcapPost.project_url,
                    TriggerTime = DateTime.Now
                };

                context.RedcapDETs.Add(redcapDET);
                context.SaveChanges();
            }

            return null;
        }
    }
}