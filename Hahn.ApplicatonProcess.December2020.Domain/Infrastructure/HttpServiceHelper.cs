using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Infrastructure
{
    public class HttpServiceHelper
    {
        /// <summary>
        ///  Http get
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<String> GetHttpClient(String url)
        {

            String responseStr = string.Empty;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    responseStr = await response.Content.ReadAsStringAsync();
                }
                return responseStr;
            }

        }
        /// <summary>
        /// Http post
        /// </summary>
        /// <param name="url"></param>
        /// <param name="jsonObject"></param>
        /// <returns></returns>
        public static async Task<String> PostHttpClient(String url, String jsonObject)
        {

            String responseStr = string.Empty;

            using (HttpClient client = new HttpClient())
            {
                //var json = JsonConvert.SerializeObject(data);
                //client.BaseAddress = new Uri(baseUri);
                //client.DefaultRequestHeaders.Add("token", token);

                var stringContent = new StringContent(jsonObject, UnicodeEncoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    responseStr = await response.Content.ReadAsStringAsync();
                }
                return responseStr;
            }
        }


    }
}
