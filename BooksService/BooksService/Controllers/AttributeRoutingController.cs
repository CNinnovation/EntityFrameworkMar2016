using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BooksService.Controllers
{
    [RoutePrefix("blabla")]
    public class AttributeRoutingController : ApiController
    {
        public AttributeRoutingController()
        {

        }

        [Route("Bar")]
        [HttpGet]
        public string Foo()
        {
            return "Foo";
        }

        [Route("Add/{x}/{y}")]
        [HttpGet]
        public int Add(int x, int y)
        {
            return x + y;
        }
    }
}
