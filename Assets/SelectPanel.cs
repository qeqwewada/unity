using UnityEngine;
using UnityEngine.UI;

public class SelectPanel : BasePanel
{
    public Button BackButton;
    public Button startButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BackButton.onClick.AddListener(() => {
            MusicManager.instance.PlaySFX("Button1");
            UIManager.Instance.ClosePanel(UIConst.SelectPanel);
            MusicManager.instance.StopMusic(MusicConst.StartOver);
            MusicManager.instance.PlayMusic(MusicConst.LevelsClip, true);
        });
        startButton.onClick.AddListener(() => {
            MusicManager.instance.PlaySFX("Button1");
            SceneManager.instance.LoadScene("FateScene");
            /* UIManager.Instance.OpenPanel(UIConst.LevelPanel); */
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
