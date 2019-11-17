using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace NotifySMSToLine
{
    public class Function
    {
        private static HttpClient client;

        public Function()
        {
            client = new HttpClient();
            // ŠÂ‹«•Ï”‚ÍuEnvironment.GetEnvironmentVariable("accessToken")v‚Åæ“¾‚Å‚«‚é
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Environment.GetEnvironmentVariable("accessToken")}");
        }

        /// <summary>
        /// SMS‚ª—ˆ‚½‚çLINE Notify‚É’Ê’m‚·‚é
        /// </summary>
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<object> FunctionHandler(SMSInfo input, ILambdaContext context)
        {
            // ƒŠ[ƒWƒ‡ƒ“‚ğ“ú–{‚Éİ’è
            var culture = System.Globalization.CultureInfo.GetCultureInfo("ja-JP");

            string sentDate = DateTimeOffset.FromUnixTimeSeconds(input.sentTimestamp).AddHours(9).ToString("yyyy/MM/dd(ddd) HH:mm:ss", culture);

            return await client.PostAsync($"https://notify-api.line.me/api/notify/?message=\ny“à—ez\n{input.messageContent}\n\nyóMz\n{sentDate}\n\ny‘—MŒ³z\n{input.senderPhoneNumber}", null);
        }
    }
}
