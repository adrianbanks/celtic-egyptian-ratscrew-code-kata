using System.Collections.Generic;
using System.Linq;

namespace CelticEgyptianRatscrewKata
{
    public class Game
    {
        private readonly List<string> m_Players;

        public Game(List<string> players)
        {
            m_Players = players;
        }

        public string Winner
        {
            get { return m_Players.Count == 1 ? m_Players.Single() : null; }
        }
    }
}