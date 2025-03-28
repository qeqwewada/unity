using UnityEngine;
using UnityEngine.UI;

public class LevelsPanel : BasePanel
{
    public Button BackButton;
    public Button startButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BackButton.onClick.AddListener(() => {
            MusicManager.instance.PlaySFX("Button1");
            UIManager.Instance.ClosePanel(UIConst.LevelsPanel);
            MusicManager.instance.StopMusic(MusicConst.LevelsClip);
            MusicManager.instance.PlayMusic(MusicConst.HomeClip,true);
        });
        startButton.onClick.AddListener(() => {
            MusicManager.instance.PlaySFX("Button1");
            UIManager.Instance.OpenPanel(UIConst.ReadyPanel);
            
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
