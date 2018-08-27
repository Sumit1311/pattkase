using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace MvcApplication1.Library
{
    public class DateHelper
    {
        private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public static readonly string dateFormat = "dd/MM/yyyy";
        public static Int64 getMillisecondsFromEpoch()
        {
            return (Int64)DateTime.Now.Subtract(epoch).TotalMilliseconds;
        }
        public static DateTime convertToDateTime(Int64 time)
        {
            return epoch.AddMilliseconds(time);
        }
        public static Int64 getMillisecondsFromEpoch(string date)
        {
            DateTime t;
            DateTime.TryParseExact(date, dateFormat, null, DateTimeStyles.None, out t);
            return (Int64)t.Subtract(epoch).TotalMilliseconds;
        }
        
    }

    public class PasswordHelper
    {
        public static string generatePassword()
        {
            return Membership.GeneratePassword(10, 2);
        }
    }

    public class EmailHelpser
    {
        public static async System.Threading.Tasks.Task<HttpResponseMessage> sendEmail(string userName, string password)
        {
            using (var client = new HttpClient
                    {
                        BaseAddress =
                            new Uri("https://api.mailgun.net/v3/sandbox4af0182d1b6646ca92b44845751c8a17.mailgun.org")
                    })
                    {
                        client.DefaultRequestHeaders.Authorization =
                          new AuthenticationHeaderValue("Basic",
                        Convert.ToBase64String(Encoding.ASCII.GetBytes("api:2ac1ec8f94c812c6337a9b60f3f602b3-a4502f89-47161d09")));

                        var content = new FormUrlEncodedContent(new[]
    {
        new KeyValuePair<string, string>("from", "postmaster@sandbox4af0182d1b6646ca92b44845751c8a17.mailgun.org"),
        new KeyValuePair<string, string>("to", "sumittoshniwal92@gmail.com"),
        new KeyValuePair<string, string>("subject", "Pattkase User Credentials"),
        new KeyValuePair<string, string>("text", "User Name : " + userName+ "  Password : " + password)
    });

                       var res = await client.PostAsync("/messages",
                                               content);
                       return res;
                    }
        }
    }
}