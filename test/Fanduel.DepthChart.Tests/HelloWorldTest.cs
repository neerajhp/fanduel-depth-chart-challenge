using Xunit;

namespace Fanduel.DepthChart.Tests
{
    public class HelloWorldTest
    {
        private HelloWorld _helloWorld;

        public HelloWorldTest()
        {
            _helloWorld = new HelloWorld();
        }

        [Fact]
        public void SayHello_ReturnsHelloWorld()
        {
            var result = _helloWorld.SayHello();
            Assert.Equal("Hello, World!", result);
        }
    }
}