using System.Diagnostics;
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
            case "add":
                callAddPlayerCommand(commandParts[1]);
                break;
            case "remove":
                callRemovePlayerCommand(commandParts);
                break;
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

    private void callAddPlayerCommand(string arguments) 
    {
        var argumentParts = arguments.Split(new[] { ' ' }, 3);
        if (argumentParts.Length >= 2)
        {
            var position = argumentParts[0];
            var playerNumber = argumentParts[1];
            var playerName = argumentParts.Length > 2 ? argumentParts[2] : "";

            var player = new PlayerModel(number: playerNumber, name: playerName);
            _depthChartService.addPlayerToDepthChart(position, player);
        }
    }    
    
    private void callRemovePlayerCommand(string[] arguments) 
    {
        if (arguments.Length >= 3)
        {
            var position = arguments[1];
            var playerNumber = arguments[2];
            var playerName = arguments.Length > 3 ? arguments[3] : "";

            var player = new PlayerModel(number: playerNumber, name: playerName);
            _depthChartService.removePlayerFromDepthChart(position, player);
        }
    }
}