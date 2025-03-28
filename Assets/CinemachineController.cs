using UnityEngine;

public class CinemachineController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public void OnBlendFinish()
    {
        MusicManager.instance.PlayMusic("HomeClip",true);
        UIManager.Instance.OpenPanel(UIConst.MainPanel);
        UIManager.Instance.OpenFrontPanel(UIConst.RightTop);
       /*  UIManager.Instance.OpenPanel(UIConst.RightTop); */
    }
}
