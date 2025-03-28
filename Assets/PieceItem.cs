using UnityEngine;
using UnityEngine.UI;

public class PieceItem : MonoBehaviour
{
    public Image image;
    public Text nameText;
    public Text priceText;
    public Text maxCountText;
    public string imageUrl;
    public string description;
    public Button buyButton;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void SetData(ShopPieceEntity data)
    {
        image.sprite = Resources.Load<Sprite>(data.Imageurl);
        nameText.text = data.Name;
        priceText.text = data.price.ToString();
        description = data.Desc;
        maxCountText.text = "限购:0/"+data.MaxCount.ToString();
    }
}
