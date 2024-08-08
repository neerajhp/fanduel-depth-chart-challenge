using Fanduel.DepthChart.Models;

namespace Fanduel.DepthChart.Services;

public interface IDepthChartService
{
    public void addPlayerToDepthChart(string position, PlayerModel playerModel, int? depth = null);
}