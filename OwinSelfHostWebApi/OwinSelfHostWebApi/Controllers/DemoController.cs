using System.Collections.Generic;
using System.Net;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace OwinSelfHostWebApi.Controllers
{
    [RoutePrefix("api/demo")]
    public class DemoController : ApiController
    {
        // GET api/demo 
        public IEnumerable<string> Get()
        {
            return new string[] { "Hello", "World" };
        }

        // GET api/demo/5 
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return base.Content(HttpStatusCode.OK, new { name="hugin"}, new JsonMediaTypeFormatter(), "text/plain");
        }

        [HttpGet]
        [Route("order")]
        public IHttpActionResult Order()
        {
            return base.Content(HttpStatusCode.OK, new { name = "Product" }, new JsonMediaTypeFormatter(), "text/plain");
        }

     
    }
}
