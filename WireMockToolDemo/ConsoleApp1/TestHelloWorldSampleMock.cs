using Microsoft.AspNetCore.Routing;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WireMockDemo
{
    internal class TestHelloWorldSampleMock
    {
        private RestClient client;

        public async Task TestHelloWorldMock()
        {
            // This creates the mock API response we defined earlier
            new WireMock().CreateHelloWorldStub();

            // Define the HTTP request to be sent
            client = new RestClient("http://localhost:9876");

            RestRequest request = new RestRequest("/hello-world", Method.Get);

            // Send the HTTP request to the mock server
            RestResponse response = await client.ExecuteAsync(request);

            // Check that the response returned by the mock server contains the expected properties
            if (response.StatusCode == HttpStatusCode.OK && response.ContentType.Equals("text/plain"))
            {
                Console.WriteLine("Verified");
            }
            else
            {
                Console.WriteLine("Failed");
            }
        }
    }
}
