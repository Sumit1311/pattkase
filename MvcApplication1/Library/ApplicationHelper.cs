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
        private static async System.Threading.Tasks.Task<HttpResponseMessage> sendEmail(string to, string from, string subject, string body, bool isHtml)
        {
            using (var client = new HttpClient
                    {
                        BaseAddress =
                            new Uri("https://api.mailgun.net")
                    })
                    {
                        client.DefaultRequestHeaders.Authorization =
                          new AuthenticationHeaderValue("Basic",
                        Convert.ToBase64String(Encoding.ASCII.GetBytes("api:2ac1ec8f94c812c6337a9b60f3f602b3-a4502f89-47161d09")));
                var con = new MultipartFormDataContent();
                //con.Add(new StringContent(""), "from");
                con.Add(new StringContent(from != null ? from : "postmaster@sandbox4af0182d1b6646ca92b44845751c8a17.mailgun.org"), "from");
                //con.Add(new StringContent(userName), "to");
                con.Add(new StringContent(to), "to");
                //con.Add(new StringContent("Pattkase Credentials"), "subject");
                con.Add(new StringContent(subject), "subject");
                //con.Add(new StringContent("User Name : " + userName + "  Password : " + password), "text");
                if (isHtml)
                {
                    con.Add(new StringContent(body), "html");
                } else
                {
                    con.Add(new StringContent(body), "text");
                }
                
      
                       var res = await client.PostAsync("/v3/sandbox4af0182d1b6646ca92b44845751c8a17.mailgun.org/messages",
                                               con);
                       return res;
                    }
        }

        public static async System.Threading.Tasks.Task sendRegistrationEmail(string userName, string password)
        {
            var response = await sendEmail(userName, null, "Pattkase Credentials", "Hi " + userName + ", <br>You have been granted access to <b>Pattkase</b> data. <br> Please use below credentails for accessing : <br> <b> User Name : </b>  " + userName + "<br><b>Password : </b> " + password + "<br> <br> <b> Note : Please do not share your password with anyone else</b>", true);
            if (response.IsSuccessStatusCode)
            {
                return;
            }else
            {
                throw (new Exception("The email sending failed with following error : "+response.ReasonPhrase + "("+response.Content.ReadAsStringAsync()+")"));
            }
        }

        public static async System.Threading.Tasks.Task sendResetPasswordEmail(string userName, string password)
        {
            var response = await sendEmail(userName, null, "Pattkase Credentials", "Hi " + userName + ", <br>Your credentials had been reset by <b>Pattkase Admin</b> <br> Please use below credentails for accessing from now : <br> <b> User Name : </b>  " + userName + "<br><b>Password : </b> " + password + "<br> <br> <b> Note : Please do not share your password with anyone else</b>", true);
            if (response.IsSuccessStatusCode)
            {
                return;
            }
            else
            {
                throw (new Exception("The email sending failed with following error : " + response.ReasonPhrase + "(" + response.Content.ReadAsStringAsync() + ")"));
            }
        }
    }

    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message)
        {
            
        }
    }
}