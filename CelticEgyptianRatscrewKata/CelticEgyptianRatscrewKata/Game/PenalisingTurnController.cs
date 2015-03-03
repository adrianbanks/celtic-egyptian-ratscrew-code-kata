namespace CelticEgyptianRatscrewKata.Game
{
    public class PenalisingTurnController : ITurnController
    {
        private readonly ITurnController _turnController;

        public PenalisingTurnController(ITurnController turnController)
        {
            _turnController = turnController;
        }

        public Card PlayCard(IPlayer player)
        {
            return _turnController.PlayCard(player);
        }

        public bool AttemptSnap(IPlayer player)
        {
            return _turnController.AttemptSnap(player);
        }
    }
}