internal abstract class ActorBase
{
    public long InstanceId { get; private set; }

    #region Tick
    public void Tick()
    {
        OnTick();
    }

    protected abstract void OnTick();
    #endregion

    #region Destroy
    public void Destroy()
    {
        OnDestroy();
    }
    protected abstract void OnDestroy();
    #endregion
}
