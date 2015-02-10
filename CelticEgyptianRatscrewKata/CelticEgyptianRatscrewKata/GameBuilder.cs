namespace CelticEgyptianRatscrewKata
{
    public class GameBuilder
    {
        private int players;

        public void Add(string player)
        {
            players++;
        }

        public Game Deal()
        {
            return new Game(players);
        }
    }
}