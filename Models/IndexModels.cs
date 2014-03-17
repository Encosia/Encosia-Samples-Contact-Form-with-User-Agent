using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace WebApplication4.Models {
  public class IndexViewModel {
    public string Name { get; set; }
    public string Email { get; set; }
    public string Message { get; set; }
    public string UserAgent { get; set; }

    public void SendEmail() {
      // If you don't set the user agent in the controller action (see IndexController.cs), you
      //  could also use HttpContext.Current to set it somewhere without access to the convenience
      //  properties on the Controller object, like here:
      UserAgent = HttpContext.Current.Request.UserAgent;

      var message = new MailMessage();

      message.From = new MailAddress(Email, Name);

      message.To.Add("dave@encosia.com");

      message.Subject = "Contact form from test site.";

      message.Body = String.Format("Message: {0}\n\nUser-agent: {1}", Message, UserAgent);

      var smtpClient = new SmtpClient();

      // For testing, put emails in a local directory instead of trying to send them via SMTP.
      smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
      smtpClient.PickupDirectoryLocation = HttpContext.Current.Server.MapPath("~/SentMessages");

      smtpClient.Send(message);
    }
  }
}