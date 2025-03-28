using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    public static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UIManager();
            }
            return instance;
        }
    }
    public Transform _uiRoot;
    public Transform _uiFrontRoot;
    public Dictionary<string,GameObject> prefabDict = new Dictionary<string, GameObject>();
    public Dictionary<string, BasePanel> panelDict = new Dictionary<string, BasePanel>();

    public Transform UIRoot{
        get{
            if(_uiRoot == null){
                _uiRoot = GameObject.Find("Canvas").transform;
            }
            return _uiRoot;
        }
    }
    public Transform UIFrontRoot{
        get{
            if(_uiFrontRoot == null){
                _uiFrontRoot = GameObject.Find("FrontCanvas").transform;
            }
            return _uiFrontRoot;
        }
    }
    public BasePanel OpenPanel(string panelName)
    {
        BasePanel panel = null;
        if(panelDict.TryGetValue(panelName,out panel)){
            Debug.Log("Panel is already opened");
            return null;
        }

        GameObject prefab = null;
        if(!prefabDict.TryGetValue(panelName,out prefab)){

            prefab = Resources.Load<GameObject>("Prefabs/" + panelName);
            if(prefab == null){
                Debug.Log("Panel is not existed");
                return null;
            }
            prefabDict.Add(panelName,prefab);
        }
        GameObject panelObj = GameObject.Instantiate(prefab,UIRoot);
        panel = panelObj.GetComponent<BasePanel>();
        panelDict.Add(panelName,panel);
        panel.OpenPanel(panelName);
        return panel;

    }
    public void ClosePanel(string panelName)
    {
        BasePanel panel = null;
        if(panelDict.TryGetValue(panelName, out panel)){
            panel.ClosePanel();
        } else {
            Debug.Log("Panel is not opened");
        }
    }

      public BasePanel OpenFrontPanel(string panelName)
    {
        BasePanel panel = null;
        if(panelDict.TryGetValue(panelName,out panel)){
            Debug.Log("Panel is already opened");
            return null;
        }

        GameObject prefab = null;
        if(!prefabDict.TryGetValue(panelName,out prefab)){

            prefab = Resources.Load<GameObject>("Prefabs/" + panelName);
            if(prefab == null){
                Debug.Log("Panel is not existed");
                return null;
            }
            prefabDict.Add(panelName,prefab);
        }
        GameObject panelObj = GameObject.Instantiate(prefab,UIFrontRoot);
        panel = panelObj.GetComponent<BasePanel>();
        panelDict.Add(panelName,panel);
        panel.OpenPanel(panelName);
        return panel;

    }

    internal void CloseAllPanel()
    {
        var panels = new List<BasePanel>(panelDict.Values);
        foreach(var panel in panels){
            panel.ClosePanel();
        }
    }
}
public class UIConst
{
    public const string MainPanel = "MainPanel";
    public const string GamePanel = "GamePanel";
    public const string SettingPanel = "SettingPanel";
    public const string GameOverPanel = "GameOverPanel";

    public const string LoginPanel = "LoginPanel";
    public const string LogoPanel = "LogoPanel";

    public const string LoadingPanel = "LoadingPanel";

    public const string ShopPanel = "ShopPanel";
    public const string BagPanel = "BagPanel";

    public const string DescriptionPanel = "DescriptionPanel";
    public const string RightTop = "RightTop";
    public const string ShengHenDesc = "ShengHenDesc";
    public const string ModePanel = "ModePanel";
    public const string LevelsPanel = "LevelsPanel";
    public const string SelectPanel = "SelectPanel";
    public const string ReadyPanel = "ReadyPanel";
    public const string NovelsPanel = "NovelsPanel";
}
