
//===================================================
//创建时间：2025-03-16 21:21:18
//备    注：此代码为工具生成 请勿手工修改
//===================================================
using System.Collections;

/// <summary>
/// ShopRole实体
/// </summary>
public partial class ShopRoleEntity : AbstractEntity
{

    public int Id { get; set; }
    /// <summary>
    /// 人物姓名
    /// </summary>
    /// 
    public string Name { get; set; }

    /// <summary>
    /// 价格
    /// </summary>
    public int price { get; set; }

    /// <summary>
    /// 头像路径
    /// </summary>
    public string avatarUrl { get; set; }

    /// <summary>
    /// 人物描述
    /// </summary>
    public string Desc { get; set; }

    /// <summary>
    /// 最大购买数
    /// </summary>
    public int MaxCount { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int level { get; set; }

    /// <summary>
    /// 立绘路径
    /// </summary>
    public string CharacterUrl { get; set; }

}
