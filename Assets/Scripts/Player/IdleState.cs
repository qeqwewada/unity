using UnityEngine;
public class IdleState : StateBase
{
    public IdleState(PlayerController playerController) : base(playerController)
    {
    }
    public override void OnEnter()
    {
        playerController.animator.SetFloat("Speed", 0);
        Debug.Log("IdleState OnEnter");
    }
    public override void OnUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            playerController.ChangeState(StateType.Move);
        }
        if(Input.GetMouseButtonDown(0)){
            playerController.ChangeState(StateType.Attack);
        }
       playerController.Velocity();
    }
    public override void OnExit()
    {
        Debug.Log("IdleState OnExit");
    }
}