using CelticEgyptianRatscrewKata.SnapRules;

namespace CelticEgyptianRatscrewKata.Game
{
    public class TurnController : ITurnController
    {
        private readonly IGameState _gameState;
        private readonly ISnapValidator _snapValidator;

        public TurnController(ISnapValidator snapValidator, IGameState gameState)
        {
            _snapValidator = snapValidator;
            _gameState = gameState;
        }

        public Card PlayCard(IPlayer player)
        {
            if (_gameState.HasCards(player.Name))
            {
                return _gameState.PlayCard(player.Name);
            }
            return null;
        }

        public bool AttemptSnap(IPlayer player)
        {
            if (_snapValidator.CanSnap(_gameState.Stack))
            {
                _gameState.WinStack(player.Name);
                return true;
            }

            return false;
        }

        public void ResolveADeadlock(int totalPlayerCount)
        {
        }
    }
}