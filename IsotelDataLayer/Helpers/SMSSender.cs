using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace IsotelDataLayer.Helpers
{
    public class SMSSender
    {
        public static void SendSMS(string destination, string username, string userPhoneNumber, string address)
        {
            Console.WriteLine(destination);
            const string accountSid = "ACcf3a20608a72adc52b4f6a4d8c503520";
            const string authToken = "ad9c1e2a6caa2380db76a390607ababc";
            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "This is the Isotel Service. The newly arrived Romanian citizen " + username + " having the phone number " + userPhoneNumber + " has just rented the property of " + address,
                from: new Twilio.Types.PhoneNumber("+17174006012"),
                to: new Twilio.Types.PhoneNumber(destination)
            );

        }
    }
}
