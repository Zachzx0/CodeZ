namespace CodeZ.Core
{
    internal class PlayerData: ActorDataBase
    {
        PlayerInfo _info;

        public PlayerData(PlayerInfo info)
        {
            Reset(info);
        }

        public void Reset(PlayerInfo info)
        {
            _info = info;
        }
    }
}