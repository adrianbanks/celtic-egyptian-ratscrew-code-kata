using System.Collections.Generic;

namespace CelticEgyptianRatscrewKata.Game
{
    public class Penaliser : IPenaliser
    {
        private readonly List<string> penalisedPlayers = new List<string>();

        public bool IsPenalised(IPlayer player)
        {
            return penalisedPlayers.Contains(player.Name);
        }

        public void AddPenalty(IPlayer player)
        {
            penalisedPlayers.Add(player.Name);
        }

        public void ClearPenalties()
        {
            penalisedPlayers.Clear();
        }

        public void ClearPenaltiesIfAllPlayersPenalised(int totalNumberOfPlayers)
        {
            if (penalisedPlayers.Count == totalNumberOfPlayers)
            {
                ClearPenalties();
            }
        }
    }
}