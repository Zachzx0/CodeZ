namespace CodeZ.System
{
    public abstract class GameSystemBase
    {
        public void Initialize()
        {
            OnInitialize();
        }

        protected abstract void OnInitialize();

        public void Enter(object param)
        {
            OnEnter(param);
        }

        protected abstract void OnEnter(object param);

        public void Tick(float deltaTime)
        {
            OnTick(deltaTime);
        }

        protected abstract void OnTick(float deltaTime);

        public void Destroy()
        {
            OnDestroy();
        }

        protected abstract void OnDestroy();

        public void DoFinalize()
        {
            OnFinalize();
        }

        protected abstract void OnFinalize();
    }

    public abstract class GameSystem<T> where T : GameSystemBase
    {

    }
}