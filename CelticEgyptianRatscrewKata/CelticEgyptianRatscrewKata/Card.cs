namespace CelticEgyptianRatscrewKata
{
    public class Card
    {
        private readonly Suit m_Suit;
        private readonly Rank m_rank;

        public Card(Suit suit, Rank rank)
        {
            m_Suit = suit;
            this.m_rank = rank;
        }

        public Rank Rank
        {
            get { return m_rank; }
        }
        public Suit Suit
        {
            get { return m_Suit; }
        }

        public override string ToString()
        {
            return string.Format("Card {0} of {1}", m_rank, m_Suit);
        }

        #region EqualityMembers
        protected bool Equals(Card other)
        {
            return m_Suit == other.m_Suit && m_rank == other.m_rank;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Card) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int) m_Suit*397) ^ (int) m_rank;
            }
        }
#endregion
    }
}