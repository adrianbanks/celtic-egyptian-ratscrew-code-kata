namespace CelticEgyptianRatscrewKata.Game
{
    public interface IPenaliser
    {
        bool IsPenalised(IPlayer player);
        void AddPenalty(IPlayer player);
        void ClearPenalties();
        void ClearPenaltiesIfAllPlayersPenalised(int totalNumberOfPlayers);
    }
}