using System.Collections.Generic;
using System.Linq;

namespace CelticEgyptianRatscrewKata
{
    public class GameBuilder
    {
        private readonly List<string> m_Players = new List<string>();

        public void Add(string player)
        {
            m_Players.Add(player);
        }

        public Game Deal()
        {
            var standardDeck = new CardsFactory().StandardDeck();
            var shuffledDeck = new Shuffler().Shuffle(standardDeck);
            var hands = new Dealer().Deal(m_Players.Count, shuffledDeck);
            return new Game(m_Players.Zip(hands, (name, cards) => new Player(name, cards)));
        }
    }
}