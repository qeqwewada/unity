
//===================================================
//创建时间：2025-03-18 13:09:57
//备    注：此代码为工具生成 请勿手工修改
//===================================================
using System.Collections;

/// <summary>
/// ShengHen实体
/// </summary>
public partial class ShengHenEntity : AbstractEntity
{   
    public int Id{get;set;}
    /// <summary>
    /// 人物姓名
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 价格
    /// </summary>
    public int price { get; set; }

    /// <summary>
    /// 图片路径
    /// </summary>
    public string Imageurl { get; set; }

    /// <summary>
    /// 人物描述
    /// </summary>
    public string Desc { get; set; }

    /// <summary>
    /// 圣痕类型，1上，2中，3下
    /// </summary>
    public string type { get; set; }

    /// <summary>
    /// 套装名字
    /// </summary>
    public string suit { get; set; }

    /// <summary>
    /// 圣痕效果
    /// </summary>
    public string buff { get; set; }

}
