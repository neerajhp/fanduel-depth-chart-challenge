using System;
using Fanduel.DepthChart.Constants;
using Fanduel.DepthChart.Models;
using Fanduel.DepthChart.Services;

class Program
{
    static void Main()
    {
        var depthChartModel = new DepthChartModel(positionList: NflPlayerPositions.Positions);
        var depthChartService = new DepthChartService(chart: depthChartModel);

        var player1 = new PlayerModel(number: "11", name: "Player1");
        var player2 = new PlayerModel(number: "22", name: "Player2");

        depthChartService.addPlayerToDepthChart("QB", player1);
        depthChartService.addPlayerToDepthChart("RB", player2);

        depthChartService.getFullDepthChart();
    }
}