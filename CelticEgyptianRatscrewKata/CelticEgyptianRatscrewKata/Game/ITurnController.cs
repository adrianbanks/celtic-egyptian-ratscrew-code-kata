namespace CelticEgyptianRatscrewKata.Game
{
    public interface ITurnController
    {
        Card PlayCard(IPlayer player);
        bool AttemptSnap(IPlayer player);
        void ResolveADeadlock(int totalPlayerCount);
    }
}