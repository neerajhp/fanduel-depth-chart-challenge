
namespace Fanduel.DepthChart.Models;

public class DepthChartModel
{
    public Dictionary<string, List<PlayerModel>> playerPositions { get; set; }
    
    public static readonly Dictionary<string, string> Positions = new Dictionary<string, string>
    {
        { "LWR", "LWR" },
        { "RWR", "RWR" },
        { "SWR", "SWR" },
        { "LT", "LT" },
        { "LG", "LG" },
        { "C", "C" },
        { "RT", "RT" },
        { "RG", "RG" },
        { "TE", "TE" },
        { "QB", "QB" },
        { "RB", "RB" },
        { "DE", "DE" },
        { "NT", "NT" },
        { "DT", "DT" },
        { "LOLB", "LOLB" },
        { "LILB", "LILB" },
        { "ROLB", "ROLB" },
        { "RILB", "RILB" },
        { "LCB", "LCB" },
        { "SS", "SS" },
        { "FS", "FS" },
        { "RCB", "RCB" },
        { "NB", "NB" },
        { "PT", "PT" },
        { "PK", "PK" },
        { "LS", "LS" },
        { "H", "H" },
        { "KO", "KO" },
        { "PR", "PR" },
        { "KR", "KR" }
    };

    public DepthChartModel(string[] positionList)
    {
        playerPositions = new Dictionary<string, List<PlayerModel>>();
        
        foreach (var position in positionList)
        {
            playerPositions[position] = new List<PlayerModel>();
        }
        
    }
}   