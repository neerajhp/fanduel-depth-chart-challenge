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
        if (string.IsNullOrEmpty(input))
        {
            return true;
        }

        var commandParts = input.Split(new[] { ' ' }, 3);
        var command = commandParts[0].ToLower();

        switch (command)
        {
            case "exit":
                return false;
            case "fulldepthchart":
                callFullDepthChartCommand();
                break;
            default:
                break;
        }

        return true;
    }

    private void callFullDepthChartCommand()
    {
        _depthChartService.getFullDepthChart();
    }
}