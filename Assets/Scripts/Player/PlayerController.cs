using System;
using Unity.Cinemachine;
using UnityEngine;

[Serializable]
public class Parameter
{
    public string name="yayi";
    public int hp;
    public float gravity=-15f;
    public float speed=1f;
    
}

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Parameter playerParameter;
    public Animator animator;
    public CharacterController characterController;

     FSM fsm = new FSM();
    void Start()
    {
        MusicManager.instance.PlayMusic("FateClip",true);
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        fsm.AddState(StateType.Move, new MoveState(this));
        fsm.AddState(StateType.Idle, new IdleState(this));
        fsm.AddState(StateType.Attack, new AttackState(this));
        fsm.ChangeState(StateType.Idle);
    }
    public void ChangeState(StateType stateType)
    {
        fsm.ChangeState(stateType);
    }

    // Update is called once per frame
    void Update()
    {
        fsm.Update();
    }
    public void OnFootstep()
    {
        Debug.Log("OnFootstep");
    }
    public void Velocity()
    {
        characterController.Move(Vector3.up * playerParameter.gravity * Time.deltaTime);
    }

    public void AttackClip1()
    {
        MusicManager.instance.PlayMusic("Attack1");
        MusicManager.instance.PlayMusic("Wave1");
    }
    public void AttackClip2()
    {
        MusicManager.instance.PlayMusic("Attack2");
        MusicManager.instance.PlayMusic("Wave1");
    }
    public void AttackClip3()
    {
        MusicManager.instance.PlayMusic("Attack3");
        MusicManager.instance.PlayMusic("Wave1");
    }
    public void AttackClip4()
    {
        MusicManager.instance.PlayMusic("Attack4");
        MusicManager.instance.PlayMusic("Wave2");
    }
}

