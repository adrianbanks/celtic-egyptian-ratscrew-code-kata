namespace CelticEgyptianRatscrewKata.Game
{
    public class RankIterator
    {
        private Rank currentRank = Rank.Ace;

        public RankIterator(Rank startingRank = Rank.Ace)
        {
            currentRank = startingRank;
        }

        public Rank Current
        {
            get { return currentRank; }
        }

        public void MoveNext()
        {
            var next = currentRank + 1;

            if (next > Rank.King)
            {
                next = Rank.Ace;
            }

            currentRank = next;
        }
    }
}
