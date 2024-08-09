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
        
        public override bool Equals(object obj)
        {
            if (obj is PlayerModel otherPlayer)
            {
                return Number == otherPlayer.Number && Name == otherPlayer.Name;
            }

            return false;
        }
    }
}