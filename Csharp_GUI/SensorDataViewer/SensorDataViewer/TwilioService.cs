using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

public class TwilioService
{
    private string accountSid = "xxxx";
    private string authToken = "yyyy";
    private string fromPhoneNumber = "zzzz";

    public TwilioService()
    {
        TwilioClient.Init(accountSid, authToken);
    }

    public void SendSms(string toPhoneNumber, string message)
    {
        var messageOptions = new CreateMessageOptions(new Twilio.Types.PhoneNumber(toPhoneNumber))
        {
            From = new Twilio.Types.PhoneNumber(fromPhoneNumber),
            Body = message
        };

        var msg = MessageResource.Create(messageOptions);
        Console.WriteLine($"SMS sent: {msg.Sid}");
    }
}
