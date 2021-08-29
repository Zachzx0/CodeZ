using UnityEngine;

namespace CodeZ.System
{
    public class Program
    {
        [SerializeField]
        [Header("游戏模式")]
        private EStateType _eStateType;

        public EStateType GameState { get { return _eStateType; } }

        void Start()
        {
            //GameRootCfg.
        }

    }
}