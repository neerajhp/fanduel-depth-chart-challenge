using Fanduel.DepthChart.Models;

namespace Fanduel.DepthChart.Services;

public interface IDepthChartService
{
    public void addPlayerToDepthChart(string position, PlayerModel playerModel, int? depth = null);
    public List<PlayerModel> removePlayerFromDepthChart(string position, PlayerModel playerModel);
    public void getBackups (string position, PlayerModel player);
    public void getFullDepthChart();
}