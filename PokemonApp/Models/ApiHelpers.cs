using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text.Json;

namespace APIHelpers
{
    public static class ApiHelper
    {
        // create HTTP client
        private static HttpClient GetHttpClient(string url)
        {
            var client = new HttpClient { BaseAddress = new Uri(url) };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        public static async Task<T> RunAsync<T>(string url, string urlParams)
        {
            try
            {
                using (var client = GetHttpClient(url))
                {
                    // send GET request
                    HttpResponseMessage response = await client.GetAsync(urlParams);
                    response.Headers.Add("api_key", "738f9c16-f4b3-489a-ba0a-2fb811bbfd32");

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var json = await response.Content.ReadAsStringAsync();

                        // JSON to an object
                        var result = JsonSerializer.Deserialize<T>(json);
                        return result;
                    }

                    return default(T);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return default(T);
            }
        }
    }
}