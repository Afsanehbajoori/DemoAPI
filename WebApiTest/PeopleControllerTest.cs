using DemoAPI.Controllers;
using DemoAPI.Models;
using System;
using Xunit;
using System.Web.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebApiTest
{
    public class PeopleControllerTest
    {
        private readonly PeopleController _controller ;
        private readonly DatabaseContext _dbContext ;

        public PeopleControllerTest()
        {
            _controller = new PeopleController();
            _dbContext = new DatabaseContext();
        }
        
        [Fact]
        public void TestGetMethod()
        {
            var result = _controller.Get();
            //Assert.IsType<List<Person>>(result);
            Assert.NotNull(result);

        }
    }
}
