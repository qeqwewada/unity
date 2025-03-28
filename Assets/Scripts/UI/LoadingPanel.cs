using UnityEngine;
using UnityEngine.UI;


public class LoadingPanel : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Image LoadingBar;
    public Text text;
    public LoginPanel loginPanel;
    void Start()
    {
        LoadingBar.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        LoadingBar.fillAmount += 0.0020f;
        text.text = "更新配置中   "+(LoadingBar.fillAmount * 100).ToString("0") + "%";
        if(LoadingBar.fillAmount >= 1)
        {
            LoadingBar.fillAmount = 1;
            gameObject.SetActive(false);
            loginPanel.gameObject.SetActive(true);


        }
    }
}
