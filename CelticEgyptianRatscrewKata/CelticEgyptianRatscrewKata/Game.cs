namespace CelticEgyptianRatscrewKata
{
    public class Game
    {
        private readonly int m_Players;

        public Game(int players)
        {
            m_Players = players;
        }

        public string Winner
        {
            get { return m_Players == 1 ? "Player 1" : null; }
        }
    }
}