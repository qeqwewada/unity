using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShengHenDesc : BasePanel
{
    public Button cancelButton;
    public Button buyButton;
    public Text descriptionText;
    public Text titleText;
    public Image icon;
    public Text priceText;
    public GameObject BuySuccessPanelPrefab; // 预制体
    private GameObject BuySuccessPanelInstance; // 实例
    private bool hasInit = false;

    private void Start()
    {
        cancelButton.onClick.AddListener(OnCancelButtonClick);
        buyButton.onClick.AddListener(OnBuyButtonClick);
    }

    private void OnCancelButtonClick()
    {
        MusicManager.instance.PlaySFX(SFXConst.Button3);
        UIManager.instance.ClosePanel(UIConst.ShengHenDesc);
    }

    private void OnBuyButtonClick()
    {

        MusicManager.instance.PlaySFX(SFXConst.Button2);
        UIManager.instance.ClosePanel(UIConst.ShengHenDesc);

        // 在 Canvas 下生成 BuySuccessPanel
        if (BuySuccessPanelInstance == null&&hasInit==false)
        {
            GameObject canvas = GameObject.Find("Canvas");
            BuySuccessPanelInstance = Instantiate(BuySuccessPanelPrefab, canvas.transform);
            hasInit = true;
        }

        BuySuccessPanelInstance.transform.localScale = new Vector3(1, 0, 1);
        BuySuccessPanelInstance.SetActive(true);
        BuySuccessPanelInstance.transform.DOScaleY(1, 0.5f).SetEase(Ease.OutBounce).OnComplete(() =>
        {
          
            BuySuccessPanelInstance.GetComponent<CanvasGroup>().DOFade(0, 1f).SetDelay(1f).OnComplete(() =>
            {
                Destroy(BuySuccessPanelInstance);
                hasInit = false;
            });
        });
    }
}
