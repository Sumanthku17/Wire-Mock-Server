using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace WireMockDemo
{
    public class WireMock
    {
        private WireMockServer server;
        public void StartServer()
        {
            // This starts a new mock server instance listening at port 9876
            server = WireMockServer.Start(9876);
        }

        public void CreateHelloWorldStub()
        {
            // This defines a mock API response that responds to an incoming HTTP GET
            // to the `/hello-world` endpoint with a response with HTTP status code 200,
            // a Content-Type header with value `text/plain` and a response body
            // containing the text `Hello, world!`
            server.Given(
                Request.Create().WithPath("/hello-world").UsingGet()
            )
            .RespondWith(
                Response.Create()
                    .WithStatusCode(200)
                    .WithHeader("Content-Type", "text/plain")
                    .WithBody("Hello, world!")
            );
        }

        public void StopServer()
        {
            // This stops the mock server to clean up after ourselves
            server.Stop();
        }
    }
}
