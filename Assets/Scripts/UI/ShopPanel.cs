using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : BasePanel
{
    public Button exitButton;
    public List<ShopRoleEntity> shopRoleList;
    public List<ShopPieceEntity> shopPieceList;
    private List<ShengHenEntity> shengHenList;

    public List<GameObject>dailyStoreList;
    public GameObject shopRoleItemPrefab;
    public GameObject shopPieceItemPrefab;
    public GameObject ShenHenItemPrefab;
    public GameObject RoleStore;
    public GameObject PieceStore;
    public GameObject ShenHenStore;
    public GameObject lastChoice;
    public Transform UIParent;
    public Button DailyStoreButton;
    public Button PieceStoreButton;
    public Button SwapSpaceButton;
    public Button CharacterStoreButton;
    private int currentStoreIndex = -1;

    public int CurrentStoreIndex { get => currentStoreIndex; set {currentStoreIndex = value;
        MusicManager.instance.PlaySFX(SFXConst.Button3);}
     }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        shopRoleList = ShopRoleDBModel.Instance.GetList();
        
    }
    
    void Start()
    {
        exitButton.onClick.AddListener(OnExitButtonClick);
        DailyStoreButton.onClick.AddListener(OnDailyStoreButtonClick);
        PieceStoreButton.onClick.AddListener(OnPieceStoreButtonClick);
        SwapSpaceButton.onClick.AddListener(OnSwapSpaceButtonClick);
        CharacterStoreButton.onClick.AddListener(OnCharacterStoreButtonClick);
        
        refreshShopRoleItem();
    }

    private void OnCharacterStoreButtonClick()
    {
        refreshShopRoleItem();
    }

    private void OnSwapSpaceButtonClick()
    {
        refreshShenHenStoreItems();
    }

    private void OnPieceStoreButtonClick()
    {
        refreshPieceStoreItems();
    }

    private void OnDailyStoreButtonClick()
    {
          for (int i = 0; i < dailyStoreList.Count; i++)
        {
            dailyStoreList[i].SetActive(!dailyStoreList[i].activeSelf);
        }
    }

    public void refreshPieceStoreItems()
    {
       
        if(CurrentStoreIndex==1){
        return;
        }
        lastChoice.SetActive(false);
        lastChoice = PieceStore;
        PieceStore.SetActive(true);
           foreach (Transform child in UIParent)
        {
            Destroy(child.gameObject);
        }

        if(shopPieceList==null){
            shopPieceList = ShopPieceDBModel.Instance.GetList();
        }
        for (int i = 0; i < shopPieceList.Count; i++)
        {
            GameObject go = Instantiate(shopPieceItemPrefab, UIParent);
            go.GetComponent<PieceItem>().SetData(shopPieceList[i]);
        }
        CurrentStoreIndex = 1;
      
    }

    public void refreshShenHenStoreItems()
    {
        if(CurrentStoreIndex==2){
        return;
        }
        lastChoice.SetActive(false);
        lastChoice = ShenHenStore;
        ShenHenStore.SetActive(true);
           foreach (Transform child in UIParent)
        {
            Destroy(child.gameObject);
        }

        if(shengHenList==null){
            shengHenList = ShengHenDBModel.Instance.GetList();
        }
        for (int i = 0; i < shengHenList.Count; i++)
        {
            GameObject go = Instantiate(ShenHenItemPrefab, UIParent);
            go.GetComponent<ShengHenItem>().SetData(shengHenList[i]);
        }
        CurrentStoreIndex = 2;
    }

    public void refreshShopRoleItem()
    {   if(CurrentStoreIndex==0){
        return;
        }
        if(lastChoice!=null){
            lastChoice.SetActive(false);
        }
        lastChoice = RoleStore;
        RoleStore.SetActive(true);
         foreach (Transform child in UIParent)
        {
            Destroy(child.gameObject);
        }
         if(shopRoleList==null){
            shopRoleList = ShopRoleDBModel.Instance.GetList();
        }
        for (int i = 0; i < shopRoleList.Count; i++)
        {
            GameObject go = Instantiate(shopRoleItemPrefab, UIParent);
            go.GetComponent<ShopRoleItem>().SetData(shopRoleList[i]);
        }
        CurrentStoreIndex = 0;
    }

    private void OnExitButtonClick()
    {
        MusicManager.instance.PlaySFX(SFXConst.Button2);
        UIManager.Instance.ClosePanel(UIConst.ShopPanel);
        MusicManager.instance.StopMusic(MusicConst.ShopClip);
        MusicManager.instance.PlayMusic(MusicConst.HomeClip,true);
    }
    
}
