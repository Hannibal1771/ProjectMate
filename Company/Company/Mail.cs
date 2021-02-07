using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;


namespace Company
{
    class Mail
    {
        private readonly MailAddress From = new MailAddress("makiavelliv@mail.ru", "Администрация Shadow Company");
        private MailAddress To = null;
        internal int AccessCode = 0;

        public Mail(string to)
        {
            To = new MailAddress(to);
        }

       internal void Send(string name, string lastname)
       {
            using (MailMessage message = new MailMessage(From, To))
            using (SmtpClient client = new SmtpClient("smtp.mail.ru", 2525))
            {
                Random rand = new Random();
                AccessCode = rand.Next(1000000, 9999999);
                message.Subject = "Завершение регистрации в программе Shadow Company!";
                message.Body = $"Уважаемый {name} {lastname}! Благодарим вас за регистрацию! Ваш новый код доступа: {AccessCode}!";
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(From.Address, "99100256v11");
                client.Send(message);
            }
       }



    }
}
