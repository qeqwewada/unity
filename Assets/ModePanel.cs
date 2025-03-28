using UnityEngine;
using UnityEngine.UI;

public class ModePanel : BasePanel
{
    public Button BackButton;
    public Button Mode1Button;
    public Button HomeButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BackButton.onClick.AddListener(() => {
            MusicManager.instance.PlaySFX("Button1");
            UIManager.Instance.ClosePanel(UIConst.ModePanel);
        });
        HomeButton.onClick.AddListener(() => {
            MusicManager.instance.PlaySFX("Button1");
            UIManager.Instance.ClosePanel(UIConst.ModePanel);
            /* UIManager.Instance.OpenPanel(UIConst.MainPanel); */
        });
        Mode1Button.onClick.AddListener(() => {
            MusicManager.instance.PlaySFX("Button1");
            UIManager.Instance.OpenPanel(UIConst.NovelsPanel);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
