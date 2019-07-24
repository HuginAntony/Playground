using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Microsoft.Owin.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OwinSelfHostWebApi;
using OwinSelfHostWebApi.Controllers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace Owin.Tests
{
    [TestClass]
    public class ApiTests
    {
        private async Task<T> CallServer<T>(Func<HttpClient, Task<T>> callback)
        {
            using (var server = TestServer.Create<Startup>())
            {
                return await callback(server.HttpClient);
            }
        }

        [TestMethod]
        public async Task TestMethod1()
        {
            var response = await CallServer(async x => {
                var thisResponse = await x.GetAsync("/api/demo/5");
                return thisResponse;
            });

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task Can_Get_Content()
        {
            var body = await CallServer(async x => {
                var response = await x.GetAsync("/api/demo/5");
                return await response.Content.ReadAsStringAsync();
            });

            Assert.AreEqual("Hugin", body);
        }

        [TestMethod]
        public async Task Can()
        {
            using (var server = TestServer.Create<Startup>())
            {
                var contextMock = new Mock<DemoController>();

                var httpRequestMessage = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("http://localhost/api/dem")
                };

                contextMock.Setup(m => m.Get(It.IsAny<int>())).Returns(new NotFoundResult(httpRequestMessage));


                //var _articlesController = new DemoController()
                //{
                //    Configuration = new HttpConfiguration(),
                //    Request = httpRequestMessage
                //};
                var wireServer = FluentMockServer.Start();

                // Assign
                wireServer
                    .Given(Request.Create().WithPath("http://localhost/api/demo/5").UsingGet())
                    .RespondWith(
                        Response.Create()
                                .WithStatusCode(200)
                                .WithBody(@"{ ""msg"": ""Hello world!"" }")
                    );
                var a = await server.HttpClient.GetAsync("/api/demo/5");

                var d = await a.Content.ReadAsStringAsync();




                // Act


                //var result = contextMock.Object.Get(10);

                //var result = _articlesController.Get(10);

                //var request = mockHttp.When("http://localhost/api/demo/5")
                //                      .Respond(HttpStatusCode.OK);


                //var client = mockHttp.ToHttpClient();
                //var client = new HttpClient(mockHttp) { BaseAddress = new Uri("http://localhost/api/") };


                //var data = await server.HttpClient.GetAsync("/api/demo/5");
                //var d = await data.Content.ReadAsStringAsync();
            }
        }
    }
}
