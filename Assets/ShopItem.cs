using UnityEngine;
using UnityEngine.UI;

public class ShopRoleItem : MonoBehaviour
{
    public Image role;
    public Text name;
    public Text price;
    public Text maxCount;
    public string roleUrl;
    public string description;
    public Button buyButton;
    
    private void Start()
    {
        buyButton.onClick.AddListener(Buy);
    }

    private void Buy()
    {
        MusicManager.instance.PlaySFX(SFXConst.Button1);
        DescriptionPanel descriptionPanel= (DescriptionPanel)UIManager.Instance.OpenPanel(UIConst.DescriptionPanel);
          Sprite roleSprite = Resources.Load<Sprite>(roleUrl);
        descriptionPanel.icon.sprite = roleSprite;
        descriptionPanel.icon.SetNativeSize(); 
        descriptionPanel.titleText.text = name.text;
        descriptionPanel.descriptionText.text = description;
        descriptionPanel.priceText.text = price.text+"购买";

    }

    public void SetData(ShopRoleEntity data)
    {
        role.sprite = Resources.Load<Sprite>(data.avatarUrl);
        name.text = data.Name;
        price.text = data.price.ToString();
        roleUrl = data.CharacterUrl;
        description = data.Desc;
        maxCount.text = "限购:0/"+data.MaxCount.ToString();
    }
}
