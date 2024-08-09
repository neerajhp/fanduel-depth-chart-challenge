using Xunit;
using Moq;
using Fanduel.DepthChart.Services;
using Fanduel.DepthChart.Controller;

namespace Fanduel.DepthChart.Tests.Controller
{
    public class CommandLineControllerTest
    {
        private Mock<IDepthChartService> _depthChartServiceMock;
        private CommandLineController _commandLineController;

        public CommandLineControllerTest()
        {
            _depthChartServiceMock = new Mock<IDepthChartService>();
            _commandLineController = new CommandLineController(_depthChartServiceMock.Object);
        }

        [Fact]
        public void TestFullDepthChartCommand()
        {
            bool methodCalled = false;
            _depthChartServiceMock.Setup(x => x.getFullDepthChart()).Callback(() => methodCalled = true);
            _commandLineController.ProcessCommand("fulldepthchart");

            Assert.True(methodCalled);
        }
    }
}