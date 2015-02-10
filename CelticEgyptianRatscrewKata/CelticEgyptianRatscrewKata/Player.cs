namespace CelticEgyptianRatscrewKata
{
    public class Player
    {
        public readonly string Name;
        public readonly Cards Cards;

        public Player(string name, Cards cards)
        {
            Name = name;
            Cards = cards;
        }
    }
}