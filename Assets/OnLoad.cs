using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class OnLoad : MonoBehaviour
{
    public Animator animator;
    public Animator player;
    public List<GameObject>gameObjects;
    public GameObject Warship;

    public CinemachineCamera virtualCamera;
    public void LoadSpaceShip()
    {
        MusicManager.instance.StopMusic(MusicConst.LoadingClip);
        MusicManager.instance.PlayMusic(MusicConst.LoadClip);
        foreach(GameObject gameObject in gameObjects)
        {
            gameObject.SetActive(false);
        }
        Warship.SetActive(true);
        player.speed=0f;
    }
    public void OpenDoor()
    {
        MusicManager.instance.PlayMusic(MusicConst.OpenDoorClip);
        animator.SetTrigger("OpenDoor");
       
    }
    public void OnDoorOpenFinish(){
        MusicManager.instance.PlayMusic(MusicConst.LoadSuccess);
        virtualCamera.Priority = 100;
        player.speed=1f;
        
    }
}
