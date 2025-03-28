using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractDBModel<T, P>
    where T : class, new()
    where P : AbstractEntity
{
    protected List<P> lst;
    protected Dictionary<int, P> dic;

    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new T();
            }
            return _instance;
        }
    }
    protected abstract string FileName { get; }
    protected abstract P MakeEntity(GameDataTableParser parser);
    public AbstractDBModel()
    {
        lst = new List<P>();
        dic = new Dictionary<int, P>();
        LoadData();

    }
    private void LoadData()
    {
        using (GameDataTableParser parser = new GameDataTableParser(string.Format("Assets/WWW/{0}", FileName)))
        {
            Debug.Log(parser);
            while (!parser.Eof)
            {
                P entity = MakeEntity(parser);
                lst.Add(entity);
                dic[entity.id] = entity;
                parser.Next();
            }
        }
    }

    public List<P> GetList()
    {
        return lst;
    }
    public P Get(int id)
    {
        if (dic.ContainsKey(id))
        {
            return dic[id];
        }
        return null;
    }

}




/// <summary>
/// 根据编号获取角色
/// </summary>
/// <param name="id"></param>
/// <returns></returns>

