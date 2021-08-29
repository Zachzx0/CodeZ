using System.IO;
namespace CodeZ.Core.Cmd
{
    public enum ECmdType
    {
        Move,
        ThroughDoor,

        Count,
    }

    public abstract class GameCmd : ISerializable
    {
        public ECmdType CmdType;

        public ulong PlayerId;

        public abstract void ReadFrom(MemoryStream stream);

        public abstract void WriteTo(MemoryStream stream);
    }

    public static class GameCmdFactory
    {
        public static GameCmd CreateCmd(ECmdType type)
        {
            GameCmd cmd = null;
            switch (type)
            {
                case ECmdType.Move:
                    cmd = new MoveCmd();
                    break;
                default:
                    //Log输出错误
                    break;
            }
            return cmd;
        }
    }
}