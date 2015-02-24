using System.Collections.Generic;
using CelticEgyptianRatscrewKata.Game;

namespace ConsoleBasedGame
{
    class PlayerMap
    {
        private readonly List<PlayerInfo> m_PlayerInfos;

        public PlayerMap()
        {
            m_PlayerInfos = new List<PlayerInfo>();
        }

        public void AddPlayer(string playerName, char playKey, char snapKey)
        {
            PlayerInfo info = new PlayerInfo(playerName, playKey, snapKey);
            if (!m_PlayerInfos.Contains(info))
            {
                m_PlayerInfos.Add(info);
            }
        }

        public IMove ResolveMove(char userInput)
        {
            foreach (var playerInfo in m_PlayerInfos)
            {
                if (playerInfo.PlayCardKey == userInput)
                {
                    return new PlayCardMove(playerInfo.PlayerName);
                }
                else if (playerInfo.SnapKey == userInput)
                {
                    return new SnapMove(playerInfo.PlayerName);
                }
            }
            return null;
        }
    }
}