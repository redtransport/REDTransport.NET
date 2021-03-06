using System;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace REDTransport.NET.Tests.Server
{
    public class TestServerFixture : IDisposable
    {
        private readonly TestServer _testServer;
        public HttpClient Client { get; }

        public TestServerFixture()
        {
            var builder = new WebHostBuilder()
                .UseEnvironment("Development")
                .UseKestrel(options => options.Listen(IPAddress.Any, 8080))
                .UseStartup<DefaultStartup>();

            _testServer = new TestServer(builder)
            {
            };
            
            Client = _testServer.CreateClient();
        }

        public void Dispose()
        {
            Client.Dispose();
            _testServer.Dispose();
        }
    }
}