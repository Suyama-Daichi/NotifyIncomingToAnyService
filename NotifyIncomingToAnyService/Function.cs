using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace NotifyIncomingToAnyService
{
    public class Function
    {
        private static HttpClient client = new HttpClient();

        /// <summary>
        /// ���M������LINE Notify�ɒʒm����
        /// </summary>
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<object> FunctionHandler(TelInfo input, ILambdaContext context)
        {
            var json = @"{""foo"":""hoge"", ""bar"":123, ""baz"":[""��"", ""��"", ""��""]}";
            var content = new StringContent(json, Encoding.UTF8);
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Environment.GetEnvironmentVariable("accessToken")}");
            var result = await client.PostAsync($"https://notify-api.line.me/api/notify/?message={input.telNum ?? "��ʒm"}���璅�M������܂���", content);
            client = new HttpClient();
            return result;
        }
    }
}
