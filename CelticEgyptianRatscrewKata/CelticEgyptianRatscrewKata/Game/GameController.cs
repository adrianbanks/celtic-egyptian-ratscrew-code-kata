using System.Collections.Generic;
using System.Linq;
using CelticEgyptianRatscrewKata.GameSetup;

namespace CelticEgyptianRatscrewKata.Game
{
    /// <summary>
    /// Controls a game of Celtic Egyptian Ratscrew.
    /// </summary>
    public class GameController : IGameController
    {
        private readonly IDealer _dealer;
        private readonly IShuffler _shuffler;
        private readonly IList<IPlayer> _players;
        private readonly IGameState _gameState;
        private readonly ITurnController _turnController;

        public GameController(IGameState gameState, ITurnController turnController, IDealer dealer, IShuffler shuffler)
        {
            _players = new List<IPlayer>();
            _gameState = gameState;
            _dealer = dealer;
            _shuffler = shuffler;
            _turnController = turnController;
        }

        public IEnumerable<IPlayer> Players
        {
            get { return _players; }
        }

        public int StackSize
        {
            get { return _gameState.Stack.Count(); }
        }

        public Card TopOfStack
        {
            get { return _gameState.Stack.FirstOrDefault(); }
        }

        public int NumberOfCards(IPlayer player)
        {
            return _gameState.NumberOfCards(player.Name);
        }

        public bool AddPlayer(IPlayer player)
        {
            if (Players.Any(x => x.Name == player.Name)) return false;

            _players.Add(player);
            _gameState.AddPlayer(player.Name, Cards.Empty());
            return true;
        }

        public Card PlayCard(IPlayer player)
        {
            return _turnController.PlayCard(player);
        }

        public bool AttemptSnap(IPlayer player)
        {
            AddPlayer(player);
            return _turnController.AttemptSnap(player);
        }

        /// <summary>
        /// Starts a game with the currently added players
        /// </summary>
        public void StartGame(Cards deck)
        {
            _gameState.Clear();

            var shuffledDeck = _shuffler.Shuffle(deck);
            var decks = _dealer.Deal(_players.Count, shuffledDeck);
            for (var i = 0; i < decks.Count; i++)
            {
                _gameState.AddPlayer(_players[i].Name, decks[i]);
            }
        }

        public bool TryGetWinner(out IPlayer winner)
        {
            var playersWithCards = _players.Where(p => _gameState.HasCards(p.Name)).ToList();

            if (!_gameState.Stack.Any() && playersWithCards.Count() == 1)
            {
                winner = playersWithCards.Single();
                return true;
            }

            winner = null;
            return false;
        }
    }
}
