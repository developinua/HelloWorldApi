using System;
using System.Collections.Generic;
using System.Linq;
using HelloWorldApi.Models;
using HelloWorldApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorldApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HelloWorldController : ControllerBase
    {
        private readonly IHelloWorldService _helloWorldService;

        public HelloWorldController(IHelloWorldService helloWorldService)
        {
            _helloWorldService = helloWorldService;
        }

        [HttpGet]
        public HelloWorldResponse Get()
        {
            List<string> helloWorlds = _helloWorldService.GetHelloWorlds().ToList();
            int randomPosition = new Random().Next(0, helloWorlds.Count);

            return new()
            {
                Text = helloWorlds[randomPosition]
            };
        }

        [HttpPost]
        [Route("greet")]
        public HelloWorldResponse Post(HelloWorldRequest request) =>
            new()
            {
                Text = $"Hi, {request?.Name}!"
            };
    }
}