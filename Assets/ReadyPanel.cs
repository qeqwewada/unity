using UnityEngine;
using UnityEngine.UI;

public class ReadyPanel : BasePanel
{
    public Button BackButton;
    public Button startButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BackButton.onClick.AddListener(() => {
            MusicManager.instance.PlaySFX("Button1");
            UIManager.Instance.ClosePanel(UIConst.ReadyPanel);
        });
        startButton.onClick.AddListener(() => {
            MusicManager.instance.PlaySFX(SFXConst.Button1);
            UIManager.Instance.OpenPanel(UIConst.SelectPanel);
            MusicManager.instance.StopMusic(MusicConst.LevelsClip);
            MusicManager.instance.PlayMusic(MusicConst.StartOver, true);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
