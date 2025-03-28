using UnityEngine;

public class MoveState : StateBase
{
    public MoveState(PlayerController playerController) : base(playerController)
    {
    }
    public override void OnEnter()
    {
        playerController.animator.applyRootMotion = false;
       playerController.animator.SetFloat("Speed", 1);
      playerController.animator.applyRootMotion = false;
        Debug.Log("MoveState OnEnter");
    }
    public override void OnUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 input=new Vector3(horizontal,0,vertical);
         float y = Camera.main.transform.rotation.eulerAngles.y;
          Vector3 targetDir = Quaternion.Euler(0, y, 0) * input.normalized;
        if (horizontal != 0 || vertical != 0)
        {
           
            Vector3 currentDirection = Vector3.Slerp(playerController.transform.forward, targetDir, 0.1f);
            playerController.transform.LookAt(playerController.transform.position + currentDirection);

            playerController.characterController.Move(targetDir * playerController.playerParameter.speed * Time.deltaTime);
            
        }
        else
        {
            playerController.ChangeState(StateType.Idle);
        }

        playerController.Velocity();
        
        Debug.Log("MoveState OnUpdate");
    }
    public override void OnExit()
    {
        Debug.Log("MoveState OnExit");
    }
}