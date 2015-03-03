using CelticEgyptianRatscrewKata.SnapRules;

namespace CelticEgyptianRatscrewKata.Game
{
    public class TurnController : ITurnController
    {
        private readonly IGameState _gameState;
        private readonly ISnapValidator _snapValidator;
        private readonly IPenaliser _penaliser;

        public TurnController(ISnapValidator snapValidator, IGameState gameState, IPenaliser penaliser)
        {
            _snapValidator = snapValidator;
            _gameState = gameState;
            _penaliser = penaliser;
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
            if (_penaliser.IsPenalised(player))
            {
                return false;
            }

            if (SnapWins(player))
            {
                _penaliser.ClearPenalties();
                return true;
            }

            _penaliser.AddPenalty(player);
            return false;
        }

        public void ResolveADeadlock(int totalPlayerCount)
        {
            _penaliser.ClearPenaltiesIfAllPlayersPenalised(totalPlayerCount);
        }

        private bool SnapWins(IPlayer player)
        {
            if (_snapValidator.CanSnap(_gameState.Stack))
            {
                _gameState.WinStack(player.Name);
                return true;
            }
            return false;
        }
    }
}