using System;
using System.Collections.Generic;
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

        public DepthChartServiceTest()
        {
            _depthChartModel = new DepthChartModel(positionList: new string[] { "QB" });
            _depthChartService = new DepthChartService(chart: _depthChartModel );
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
        
    }
}