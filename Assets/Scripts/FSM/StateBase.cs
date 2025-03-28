using UnityEngine;

public abstract class StateBase
{
    protected PlayerController playerController;
    public StateBase(PlayerController playerController)
    {
        this.playerController = playerController;
    }
    public abstract void OnEnter();
    public abstract void OnUpdate();
    public abstract void OnExit();
}
