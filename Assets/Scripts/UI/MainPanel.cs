using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
public class MainPanel : BasePanel
{
  
    public CanvasGroup Left;
    public CanvasGroup Right;
    public CanvasGroup TopLeft;
/*     public CanvasGroup TopRight; */
    public CanvasGroup BottomLeft;
    public CanvasGroup BottomRight;

    public Button SupplyButton;
    public Button ModeButton;
    public void Start()
    {
        Left.DOFade(1, 1.5f);
        Right.DOFade(1, 1.5f);
        TopLeft.gameObject.transform.DOMoveY(TopLeft.transform.position.y+300f, 1).From();
      /*   TopRight.gameObject.transform.DOMoveY(TopRight.transform.position.y+300f, 1).From(); */
        BottomLeft.gameObject.transform.DOMoveX(BottomLeft.transform.position.x-1500, 1).From();
        BottomRight.gameObject.transform.DOMoveX(BottomRight.transform.position.x+700f, 1).From();
        ModeButton.onClick.AddListener(() => {
            MusicManager.instance.PlaySFX("Button1");
            UIManager.Instance.OpenPanel(UIConst.ModePanel);
        });
        SupplyButton.onClick.AddListener(() => {
            MusicManager.instance.PlaySFX("Button1");
            UIManager.Instance.OpenPanel(UIConst.ShopPanel);
            MusicManager.instance.StopMusic(MusicConst.HomeClip);
            MusicManager.instance.PlayMusic(MusicConst.ShopClip,true);

        });
        
        
    }
    public override void OpenPanel(string name)
    {
        base.OpenPanel(name);
    }
    public override void ClosePanel()
    {
        base.ClosePanel();
    }
}