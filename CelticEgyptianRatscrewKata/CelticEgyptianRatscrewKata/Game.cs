using System.Collections.Generic;
using System.Linq;

namespace CelticEgyptianRatscrewKata
{
    public class Game
    {
        private readonly List<Player> m_Players;

        public Game(IEnumerable<Player> players)
        {
            m_Players = players.ToList();
        }

        public string Winner
        {
            get
            {
                var winner = m_Players.SingleOrDefault(p => p.Cards.Count() == 52);
                return winner != null ? winner.Name : null;
            }
        }

        public IEnumerable<Cards> PlayerHands
        {
            get
            {
                return m_Players.Select(p => p.Cards);
            }
        }
    }
}