using CodeZ.Core.Cmd;
using CodeZ.Core.Tools;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeZ.Core
{
    public struct PlayerCreateInfo
    {
        public ulong PlayerId;          //玩家账号id
        public ushort PlayerIndex;      //玩家在同步的情况下的索引
        public uint RoleId;             //玩家角色id
    }

    public class GameInitInfo
    {
        public List<PlayerCreateInfo> PlayerList;
    }

    public class LogicGame
    {
        internal OutputManager LogicOutputMgr;

        internal ActorManager ActorMgr;

        //游戏初始化，加载角色，加载地图数据，加载配置数据，加载玩家存档数据
        public void Init(GameInitInfo initInfo)
        {
            ActorMgr = new ActorManager();

            ActorMgr.CreatePlayer(initInfo.PlayerList.ToArray());
        }

        public void Start()
        {

        }

        public void Update(List<GameCmd> cmdList)
        {

        }

        public void GetOutput()
        {

        }

        public void Destroy()
        {

        }

    }
}
