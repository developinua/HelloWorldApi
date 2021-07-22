using HelloWorldApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorldApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HelloWorldController : ControllerBase
    {
        [HttpGet]
        public HelloWorldResponse Get() =>
            new()
            {
                Text = "Hello World!"
            };

        [HttpPost]
        [Route("greet")]
        public HelloWorldResponse Post(HelloWorldRequest request) =>
            new()
            {
                Text = $"Hi, {request?.Name}!"
            };
    }
}