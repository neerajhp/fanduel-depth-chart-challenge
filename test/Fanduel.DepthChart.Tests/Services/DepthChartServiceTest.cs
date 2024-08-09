using System;
using System.Collections.Generic;
using System.IO;
using Fanduel.DepthChart.Constants;
using Fanduel.DepthChart.Models;
using Xunit;
using Fanduel.DepthChart.Services;

namespace Fanduel.DepthChart.Tests.Services
{
    public class DepthChartServiceTest
    {
        private readonly IDepthChartService _depthChartService;
        private readonly DepthChartModel _depthChartModel;
        private StringWriter _stringWriter;
        private StreamWriter _standardOutput;

        public DepthChartServiceTest()
        {
            _depthChartModel = new DepthChartModel(positionList: new string[] { "QB" });
            _depthChartService = new DepthChartService(chart: _depthChartModel );
            
            _stringWriter = new StringWriter();
            Console.SetOut(_stringWriter);

            _standardOutput = new StreamWriter(Console.OpenStandardOutput());
            _standardOutput.AutoFlush = true;
        }
        
        [Fact]
        public void TestAddPlayerToChartWithoutDefinedDepth()
        {
            var mockPlayer1 = new PlayerModel(number: "11", name: "MockPlayer1");
            var mockPlayer2 = new PlayerModel(number: "22", name: "MockPlayer2");

            _depthChartService.addPlayerToDepthChart(DepthChartModel.Positions["QB"], mockPlayer1, 1);
            _depthChartService.addPlayerToDepthChart(position: DepthChartModel.Positions["QB"], playerModel: mockPlayer2);

            Assert.Equal(new List<PlayerModel> { mockPlayer1, mockPlayer2 }, _depthChartModel.playerPositions["QB"]);
        } 
        
        
        [Fact]
        public void TestAddPlayerToChartAtDefinedDepth()
        {
            var mockPlayer1 = new PlayerModel(number: "11", name: "MockPlayer1");
            var mockPlayer2 = new PlayerModel(number: "22", name: "MockPlayer2");

            _depthChartService.addPlayerToDepthChart(DepthChartModel.Positions["QB"], mockPlayer1, 1);
            _depthChartService.addPlayerToDepthChart(DepthChartModel.Positions["QB"], mockPlayer2, 1);
            
            Assert.Equal(new List<PlayerModel> { mockPlayer2, mockPlayer1 }, _depthChartModel.playerPositions["QB"]);
        }         
        
        [Fact]
        public void TestRemovePlayerFromChartPlayerExists()
        {
            var mockPlayer1 = new PlayerModel(number: "11", name: "MockPlayer1");
            var mockPlayer2 = new PlayerModel(number: "22", name: "MockPlayer2");
            _depthChartModel.playerPositions["QB"] = new List<PlayerModel> { mockPlayer2, mockPlayer1 };
            
            var actualPlayers = _depthChartService.removePlayerFromDepthChart(DepthChartModel.Positions["QB"], mockPlayer1);
            
            Assert.Equal(new List<PlayerModel> { mockPlayer2}, actualPlayers);
        } 
        
        [Fact]
        public void TestRemovePlayerFromChartPlayerDoesNotExist()
        {
            var mockPlayer1 = new PlayerModel(number: "11", name: "MockPlayer1");
            var mockPlayer2 = new PlayerModel(number: "22", name: "MockPlayer2");
            _depthChartModel.playerPositions["QB"] = new List<PlayerModel> { mockPlayer2};
            
            var actualPlayers = _depthChartService.removePlayerFromDepthChart(DepthChartModel.Positions["QB"], mockPlayer1);
            
            Assert.Equal(new List<PlayerModel> {}, actualPlayers);
        }
        
        [Fact]
        public void TestGetPlayerBackupPlayerExists()
        {
            var mockPlayer1 = new PlayerModel(number: "11", name: "MockPlayer1");
            var mockPlayer2 = new PlayerModel(number: "22", name: "MockPlayer2");
            _depthChartModel.playerPositions["QB"] = new List<PlayerModel> { mockPlayer1, mockPlayer2};
            
            _depthChartService.getBackups(DepthChartModel.Positions["QB"], mockPlayer1);
            
            var actualDepthChartLines = _stringWriter.ToString().Split("\n");

            Assert.Equal("#22 - MockPlayer2", actualDepthChartLines[0]);
        }        
        
        [Fact]
        public void TestGetPlayerBackupPlayerDoesNotExist()
        {
            var mockPlayer1 = new PlayerModel(number: "11", name: "MockPlayer1");
            var mockPlayer2 = new PlayerModel(number: "22", name: "MockPlayer2");
            _depthChartModel.playerPositions["QB"] = new List<PlayerModel> { mockPlayer2};
            
            _depthChartService.getBackups(DepthChartModel.Positions["QB"], mockPlayer1);
            

            var actualDepthChartLines = _stringWriter.ToString().Split("\n");

            Assert.Equal("<NO LIST>", actualDepthChartLines[0]);
        }        
        
        [Fact]
        public void TestGetPlayerBackupPlayerHasNoBackup()
        {
            var mockPlayer1 = new PlayerModel(number: "11", name: "MockPlayer1");
            _depthChartModel.playerPositions["QB"] = new List<PlayerModel> { mockPlayer1};

            _depthChartService.getBackups(DepthChartModel.Positions["QB"], mockPlayer1);

            var actualDepthChartLines = _stringWriter.ToString().Split("\n");

            Assert.Equal("<NO LIST>", actualDepthChartLines[0]);
        } 
        
    }
}