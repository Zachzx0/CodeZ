using CodeZ.Core;
using System.Collections.Generic;

public enum EActorType
{
    Player,
    Monster,
    Door,
}

internal class ActorManager
{
    List<ActorBase> _actors = new List<ActorBase>();
    Dictionary<EActorType, List<ActorBase>> _actorType2Actor = new Dictionary<EActorType, List<ActorBase>>();    //todo:写个compare

    public void CreatePlayer(params PlayerCreateInfo[] playerInfos)
    {
        foreach(var player in playerInfos)
        {

        }
    }
}
