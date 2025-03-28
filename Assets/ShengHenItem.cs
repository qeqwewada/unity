using UnityEngine;
using UnityEngine.UI;

public class ShengHenItem : MonoBehaviour
{
    public Image image;
    public Image iconImage;
    public Text nameText;
    public Text priceText;
    public Text maxCountText;
    public string imageUrl;
    public string description;
    public Button buyButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buyButton.onClick.AddListener(OnBuyButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetData(ShengHenEntity entity)
    {
        nameText.text = entity.Name;
        priceText.text = entity.price.ToString();
        description = entity.Desc;
        image.sprite = Resources.Load<Sprite>(entity.Imageurl);
        switch (entity.type)
        {
            case "攻击型":
                iconImage.sprite = Resources.Load<Sprite>("UI/Icon/Icon1");
                break;
            case "防御型":
                iconImage.sprite = Resources.Load<Sprite>("UI/Icon/Icon2");
                break;
            case "综合型":
                iconImage.sprite = Resources.Load<Sprite>("UI/Icon/Icon3");
                break;
        }
        maxCountText.text = "限购:0/1";
    }
    public void OnBuyButtonClick()
    {
        MusicManager.instance.PlaySFX(SFXConst.Button1);
        ShengHenDesc shengHenDesc=( ShengHenDesc) UIManager.Instance.OpenPanel(UIConst.ShengHenDesc);
        shengHenDesc.icon.sprite = image.sprite;
        shengHenDesc.icon.SetNativeSize(); 
        shengHenDesc.titleText.text = nameText.text;
        shengHenDesc.descriptionText.text = description;
        shengHenDesc.priceText.text = priceText.text+"购买";
    }
}
