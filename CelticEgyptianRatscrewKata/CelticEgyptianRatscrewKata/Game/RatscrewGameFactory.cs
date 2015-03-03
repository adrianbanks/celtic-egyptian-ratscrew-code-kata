using CelticEgyptianRatscrewKata.GameSetup;
using CelticEgyptianRatscrewKata.SnapRules;

namespace CelticEgyptianRatscrewKata.Game
{
    public class RatscrewGameFactory : IGameFactory
    {
        public IGameController Create(ILog log)
        {
            ISnapRule[] rules =
            {
                new DarkQueenSnapRule(),
                new SandwichSnapRule(),
                new StandardSnapRule(),
            };

            var gameState = new GameState();
            var snapValidator = new SnapValidator(rules);
            var gameController = new GameController(gameState, new TurnController(snapValidator, gameState), new Dealer(), new Shuffler());
            return new LoggedGameController(gameController, log);
        }
    }
}