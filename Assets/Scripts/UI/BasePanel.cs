using Unity.VisualScripting;
using UnityEngine;

public class BasePanel : MonoBehaviour
{
    protected bool isRemove = false;
    protected string panelName;
    public virtual void OpenPanel(string name)
    {
        this.panelName = name;
        gameObject.SetActive(true);
    }
    public virtual void ClosePanel()
    {
        
        isRemove = true;
        gameObject.SetActive(false);
        Destroy(gameObject);
        if(UIManager.instance.panelDict.ContainsKey(panelName))
        {
            UIManager.instance.panelDict.Remove(panelName);
        }
    }
}
