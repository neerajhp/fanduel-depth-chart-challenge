namespace Fanduel.DepthChart.Models
{
    public class PlayerModel
    {
        public string Number { get; set; }
        public string Name { get; set; }

        public PlayerModel(string number, string name)
        {
            Number = number;
            Name = name;
        }
    }
}