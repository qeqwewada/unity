using UnityEngine;
public class AttackState : StateBase
{
    public AttackState(PlayerController playerController) : base(playerController)
    {
    }
/*     private int attackIndex = -1;

    public int AttackIndex { get => attackIndex; set {attackIndex = value;
        if(attackIndex>3){
            attackIndex = 0;
        }
        switch (attackIndex)
        {
            case 0:
                MusicManager.instance.PlayMusic("Attack1");
                MusicManager.instance.PlayMusic("Wave1");
                break;
            case 1:
                MusicManager.instance.PlayMusic("Attack2");
                MusicManager.instance.PlayMusic("Wave1");
                break;
            case 2:
                MusicManager.instance.PlayMusic("Attack3");
                MusicManager.instance.PlayMusic("Wave1");
                break;
            case 3:
                MusicManager.instance.PlayMusic("Attack4");
                MusicManager.instance.PlayMusic("Wave2");
                break;
        }
    } } */

    public override void OnEnter()
    {
        playerController.animator.applyRootMotion = true;
  /*       AttackIndex++; */
        playerController.animator.SetTrigger("Atk");
    }
    public override void OnUpdate()
    {
       if(Input.GetMouseButtonDown(0)){
           /*  AttackIndex++; */
          playerController.animator.SetTrigger("Atk");
       }
       else{

           playerController.animator.SetFloat("Speed",0);
          /*  AttackIndex = -1; */
       }
       
       if((Input.GetAxisRaw("Horizontal")!=0||Input.GetAxisRaw("Vertical")!=0 )&&CheckCurrentAnimName("Avatar_Mei_C1_Ani_Combat",out float normalizedTime)){
           playerController.ChangeState(StateType.Move);
       }
    }
    public override void OnExit()
    {
        Debug.Log("IdleState OnExit");
    }

    public bool CheckCurrentAnimName(string animName,out float normalizedTime)
    {
        AnimatorStateInfo stateInfo = playerController.animator.GetCurrentAnimatorStateInfo(0);
        normalizedTime = stateInfo.normalizedTime;
        return stateInfo.IsName(animName);
    }
}