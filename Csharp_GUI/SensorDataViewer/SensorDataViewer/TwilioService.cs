using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

public class TwilioService
{
    private string accountSid = "ACf92f1a70ed3bb375ab8d02f84c1aab2d";
    private string authToken = "efd78e063580d3c7076baf737a7d0eb8";
    private string fromPhoneNumber = "+12523812599";

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
