using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyNamespace.DataAccess.Contracts.Repositories;

namespace MyNamespace.WebApi.Controllers
{
    public class TestController : ApiController
    {
        public TestController(IUserRepository repo)
        {
            var x = repo.GetAll();
            var u = x.FirstOrDefault();
        }
    }
}
