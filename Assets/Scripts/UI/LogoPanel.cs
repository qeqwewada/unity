using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
public class LogoPanel : BasePanel
{
    public CanvasGroup Logo;
    public GameObject LoadingPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        MusicManager.instance.PlayMusic("LogoClip");
        
        Logo.DOFade(0, 1f).SetDelay(1.5f).OnComplete(() =>
        {
            canvasGroup.DOFade(0, .5f).OnComplete(() =>
            {
             gameObject.SetActive(false);
            LoadingPanel.SetActive(true);
            
            
            MusicManager.instance.PlayMusic("LoadingStart");
            MusicManager.instance.PlayMusic("LoadingClip",true);
            
            });
        });
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
