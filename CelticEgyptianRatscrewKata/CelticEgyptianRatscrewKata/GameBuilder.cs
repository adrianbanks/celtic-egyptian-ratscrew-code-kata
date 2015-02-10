using System.Collections.Generic;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata
{
    public class GameBuilder
    {
        private List<string> m_Players = new List<string>();

        public void Add(string player)
        {
            m_Players.Add(player);
        }

        public Game Deal()
        {
            return new Game(m_Players);
        }
    }
}