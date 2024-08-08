using System.Text;
using Fanduel.DepthChart.Models;

namespace Fanduel.DepthChart.Services;

public class DepthChartService : IDepthChartService
{

    private DepthChartModel depthChart;

    public DepthChartService(DepthChartModel chart)
    {
        depthChart = chart;
    }
        
    public void addPlayerToDepthChart(string position, PlayerModel playerModel, int? depth = null) {

        if (depth.HasValue && depth.Value <= depthChart.playerPositions[position].Count) {
            depthChart.playerPositions[position].Insert(depth.Value - 1, playerModel);
        } else {
            depthChart.playerPositions[position].Add(playerModel);
        }
    }
    
}