using UnityEditor;
using UnityEngine;

public class GMCommand
{
    [MenuItem("GM/CloseAllPanel")]
    public static void CloseAllPanel()
    {
        UIManager.Instance.CloseAllPanel();
    }

    [MenuItem("GM/OpenMainPanel")]  
    public static void OpenMainPanel()
    {
        UIManager.Instance.OpenPanel(UIConst.MainPanel);
    }
    [MenuItem("GM/CloseMainPanel")]
    public static void CloseMainPanel()
    {
        UIManager.Instance.ClosePanel(UIConst.MainPanel);
    }
}
