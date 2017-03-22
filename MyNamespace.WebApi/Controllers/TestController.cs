using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using MyNamespace.DataAccess.Contracts.Repositories;
using MyNamespace.DataAccess.Model;
using MyNamespace.WebApi.Models;

namespace MyNamespace.WebApi.Controllers
{
    public class TestController : ApiController
    {
        private readonly IUserRepository _repo;

        public TestController(IUserRepository repo)
        {
            _repo = repo;
        }
        public AspNetUsers Get()
        {
            var x = _repo.GetAll();
            var u = x.FirstOrDefault();
            return u;
            //return new User {Name = u.UserName, Email = u.Email};
        }

    }
}
