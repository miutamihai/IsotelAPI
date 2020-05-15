using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace IsotelRepository.Helpers
{
    public class EmailSender
    {
        public static void SendEmail(string destinationEmail, string username, string rentAddress, string userPhoneNumber)
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("isotelservice@gmail.com",
               "onbrbfdiugqllivv");
            smtp.Send("isotelservice@gmail.com", destinationEmail,
               "Isotel - Rent Occupied", "Hi there, this is Isotel! The user " + username + ", having the phone number " + userPhoneNumber + " has just rented your property of " + rentAddress);
        }
    }
}   
