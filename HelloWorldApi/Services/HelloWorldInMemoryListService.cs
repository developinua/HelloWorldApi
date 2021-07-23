using System.Collections.Generic;

namespace HelloWorldApi.Services
{
    public class HelloWorldInMemoryListService : IHelloWorldService
    {
        public IEnumerable<string> GetHelloWorlds() =>
            new List<string>
            {
                "Hello World!",
                "Hello world!",
                "hello World!",
                "hello world!",
                "Hi World!",
                "Hi world!",
                "hi World!",
                "hi world!",
                "Not today"
            };
    }
}