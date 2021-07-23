using System.Collections.Generic;

namespace HelloWorldApi.Services
{
    public interface IHelloWorldService
    {
        public IEnumerable<string> GetHelloWorlds();
    }
}