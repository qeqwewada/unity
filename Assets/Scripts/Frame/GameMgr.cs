using UnityEngine;

public class GameMgr
{
    public int sunNum = 0;
    public static GameMgr instance;
    public static GameMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameMgr();
            }
            return instance;
        }
    }
    
    public void AddSunNum(int num){
        sunNum += num;
        EventCenter.Instance.DispatchEvent("UpdateSunNum");
    }
}
