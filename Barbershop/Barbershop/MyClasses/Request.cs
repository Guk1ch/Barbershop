using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Barbershop.MyClasses
{
    static internal class ServerRequest
    {
        static private string linq = "http://93.157.248.51:65000" /*https://localhost:44355*/, keyApi = "SecretKeyBarberShop";

        public static async Task<string> Request(string additionalLink, HttpMethod httpMethod, object obj = null)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = httpMethod,
                RequestUri = new Uri(linq + additionalLink),
            };
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("KeyBarberShop", keyApi);

            if (obj != null)
                request.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

            try
            {
                var response = await client.SendAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var answer = response.Content;
                    return await answer.ReadAsStringAsync();
                }
            }
            catch (Exception)
            {
            }
            return null;
        }
    }
}
