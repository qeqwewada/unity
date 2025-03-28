using UnityEngine;
using UnityEngine.UI;

public class LoadingUI : BasePanel
{
    public static LoadingUI instance;
    public Image image;
    public Text progressText;
    float targetProgress = 0;
    public bool CanLoad = false;
    
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        MusicManager.instance.StopMusic(MusicConst.StartOver);
        image.fillAmount = 0;
    }
    private void Update()
    {
      /*   if (targetProgress - 1 < 0.01f)
        {
            targetProgress = 1;
        } */
        if (image.fillAmount < targetProgress)
        {
            image.fillAmount += 0.01f;
            progressText.text = ((int)(image.fillAmount * 100)).ToString() + "%";
        }

        if (image.fillAmount >= 1)
        {
            CanLoad = true;
        }
    }
    public void UpdateProgress(float progress)
    {
         targetProgress = (progress / 0.9f) ;
        
    }
}
