using UnityEngine;

public class Card0:MonoBehaviour
{
    public int sunCost;
    public GameObject darkBg;
    private void Start()
    {
        EventCenter.Instance.AddEventListener("UpdateSunNum", UpdateSunNum);
    }
    private void UpdateSunNum()
    {
        if (GameMgr.Instance.sunNum >= sunCost)
        {
            darkBg.SetActive(false);
        }
        else
        {
            darkBg.SetActive(true);
        }
    }
}
