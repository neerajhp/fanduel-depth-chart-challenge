using Xunit;
using Moq;
using Fanduel.DepthChart.Services;
using Fanduel.DepthChart.Controller;
using Fanduel.DepthChart.Models;

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
        
        [Fact]
        public void TestExitCommand()
        {
            var result = _commandLineController.ProcessCommand("exit");

            Assert.False(result);
        }
        
        [Fact]
        public void TestAddPlayerCommand()
        {
            var player = new PlayerModel(number: "11", name: "Mock Player1");
            _depthChartServiceMock.Setup(x => x.addPlayerToDepthChart("QB", player, null)).Verifiable();

            _commandLineController.ProcessCommand("add QB 11 Mock Player1");

            _depthChartServiceMock.Verify(x => x.addPlayerToDepthChart("QB", It.Is<PlayerModel>(p => p.Number == "11" && p.Name == "Mock Player1"), null), Times.Once);
        }
        
        [Fact]
        public void TestRemovePlayerCommand()
        {
            var player = new PlayerModel(number: "11", name: "MockPlayer1");
            _depthChartServiceMock.Setup(x => x.removePlayerFromDepthChart("QB", player)).Verifiable();

            _commandLineController.ProcessCommand("remove QB 11 MockPlayer1");

            _depthChartServiceMock.Verify(x => x.removePlayerFromDepthChart("QB", It.Is<PlayerModel>(p => p.Number == "11" && p.Name == "MockPlayer1")), Times.Once);
        }        
        
        [Fact]
        public void TestGetBackupsCommand()
        {
            var player = new PlayerModel(number: "11", name: "MockPlayer1");
            _depthChartServiceMock.Setup(x => x.removePlayerFromDepthChart("QB", player)).Verifiable();

            _commandLineController.ProcessCommand("getbackups QB 11 MockPlayer1");

            _depthChartServiceMock.Verify(x => x.getBackups("QB", It.Is<PlayerModel>(p => p.Number == "11" && p.Name == "MockPlayer1")), Times.Once);
        }
    }
}