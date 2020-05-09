using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System;

namespace WebApp.Common.Helper
{
    static public class HttpClientHelper
    {
        public static async Task<JObject> GetJsonResponse(string requestUri)
        {
            try
            {
                using var client = new HttpClient();
                var response = await client.GetAsync(requestUri);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                JObject jObject = JObject.Parse(responseBody);
                return jObject;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
