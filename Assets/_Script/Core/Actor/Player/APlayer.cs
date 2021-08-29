using System.Collections;
namespace CodeZ.Core
{
    internal class APlayer
    {
        private PlayerInfo _playerInfo;

        public PlayerData PlayerData;

        public APlayer(PlayerInfo info)
        {
            _playerInfo = info;
            PlayerData = new PlayerData(info);
        }
    }
}