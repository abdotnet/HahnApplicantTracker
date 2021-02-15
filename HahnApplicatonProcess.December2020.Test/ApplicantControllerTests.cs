using Hahn.ApplicatonProcess.December2020.Domain.Contracts.V1.Requests;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HahnApplicatonProcess.December2020.Test
{
    public class ApplicantControllerTests : IDisposable
    {
      //  private readonly HttpClient _client;
        protected TestServer _testServer;
        // http://localhost:37797
        private const string BaseUrl = "/api/v1/applicant";
        public ApplicantControllerTests()
        {
            var webBuilder = new WebHostBuilder();
            webBuilder.UseStartup<Startup>();
            _testServer = new TestServer(webBuilder);
           // _client = new HttpClient();
        }

        public void Dispose()
        {
            _testServer.Dispose();
        }

        [Fact]
        public async Task Test_GetApplicant_Data()
        {
            int applicantId = 1;
            string url = $"{BaseUrl}/{applicantId}";
            var response = await _testServer.CreateRequest(url).SendAsync("GET");
            // var response = await _client.GetAsync(url);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

            applicantId = 2;
            url = $"{BaseUrl}/{applicantId}";
            response = await _testServer.CreateRequest(url).SendAsync("GET");
            // response = await _client.GetAsync(url);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Test_DeleteApplicant_Data()
        {
            var _client = _testServer.CreateClient();
            int applicantId = 1;
            string url = $"{BaseUrl}/{applicantId}";
           // var response = await _testServer.CreateRequest($"{BaseUrl}/{applicantId}").SendAsync("DELETE");
            var response = await _client.DeleteAsync(url);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

            applicantId = 2;
            url = $"{BaseUrl}/{applicantId}";
          //  response = await _testServer.CreateRequest(url).SendAsync("DELETE");
            response = await _client.DeleteAsync(url);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        /// <summary>
        /// Test_PostApplicant_Data
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Test_PostApplicant_Data()
        {
            var _client = _testServer.CreateClient();

            //Uri uri = new Uri();
            var request = new ApplicantRequest()
            {
                Address = "56,dairo street, ketu lagos state",
                Age = 36,
                CountryOfOrigin = "EU",
                EmailAddress = "wishmewell@hahnjobs.com",
                FamilyName = "James-Patric",
                Hired = true,
                Name = "Peter"
            };
            var payload = JsonConvert.SerializeObject(request);

            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(BaseUrl, content);
            Debug.WriteLine("status 1: " + response.StatusCode);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            request = new ApplicantRequest()
            {
                Address = "56,dairo street, ketu lagos state",
                Age = 16,
                CountryOfOrigin = "EU",
                EmailAddress = "wishmewell@hahnjobs.com",
                FamilyName = "James-Patric",
                Hired = false,
                Name = ""
            };
            payload = JsonConvert.SerializeObject(request);

            content = new StringContent(payload, Encoding.UTF8, "application/json");
            response = await _client.PostAsync(BaseUrl, content);
            Debug.WriteLine("status 2: " + response.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        /// <summary>
        /// Test_PostApplicant_Data
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Test_UpdateApplicant_Data()
        {
            var _client = _testServer.CreateClient();
           
            var request = new ApplicantUpdateRequest()
            {
                Address = "56,dairo street, ketu lagos state",
                Age = 42,
                CountryOfOrigin = "EU",
                EmailAddress = "wishmewell@hahnjobs.com",
                FamilyName = "James-Patric",
                Hired = false,
                Name = "Peter",
                ID = 1

            };
            var payload = JsonConvert.SerializeObject(request);

            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync(BaseUrl, content);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

            request = new ApplicantUpdateRequest()
            {
                Address = "56,dairo street, ketu lagos state",
                Age = 16,
                CountryOfOrigin = "EU",
                EmailAddress = "wishmewell@hahnjobs.com",
                FamilyName = "James-Patric",
                Hired = false,
                Name = "Peter",
                ID = 2
            };
            payload = JsonConvert.SerializeObject(request);

            content = new StringContent(payload, Encoding.UTF8, "application/json");
            response = await _client.PutAsync(BaseUrl, content);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

    }
}
