using UnityEngine;
using UnityEngine.UI;

public class NovelsPanel : BasePanel
{
    public Button BackButton;
    public Button startButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BackButton.onClick.AddListener(() => {
            MusicManager.instance.PlaySFX("Button1");
            UIManager.Instance.ClosePanel(UIConst.NovelsPanel);
        });
        startButton.onClick.AddListener(() => {
            MusicManager.instance.PlaySFX("Button1");
            UIManager.Instance.OpenPanel(UIConst.LevelsPanel);
            MusicManager.instance.StopMusic(MusicConst.HomeClip);
            MusicManager.instance.PlayMusic(MusicConst.LevelsClip,true);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
