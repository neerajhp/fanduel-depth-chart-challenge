using Fanduel.DepthChart.Models;
using Fanduel.DepthChart.Services;

namespace Fanduel.DepthChart.Controller;

public class CommandLineController : ICommandLineController
{
    private IDepthChartService _depthChartService;

    public CommandLineController(IDepthChartService depthChartService)
    {
        _depthChartService = depthChartService;
    }

    public bool ProcessCommand(string input)
    {
        var commandParts = input.Split(new[] { ' ' }, 3);

        if (commandParts[0] == "fulldepthchart")
        {
            _depthChartService.getFullDepthChart();
        }

        return true;
    }
}