using UnityEngine;
using System.Collections.Generic;
public enum StateType
{
    None,
    Idle,
    Move,
    Attack,
    Die
}
public class FSM
{
    public StateBase currentState;
    public Dictionary<StateType, StateBase> stateDict = new Dictionary<StateType, StateBase>();
    public void AddState(StateType stateType, StateBase state)
    {
        if (stateDict.ContainsKey(stateType))
        {
            Debug.LogError("State is already existed");
            return;
        }
        stateDict.Add(stateType, state);
        
    }
    public void ChangeState(StateType stateType)
    {
        if (currentState != null)
        {
            currentState.OnExit();
        }
        currentState = stateDict[stateType];
        currentState.OnEnter();
    }
    public void Update()
    {
        if (currentState != null)
        {
            currentState.OnUpdate();
        }
    }


}
