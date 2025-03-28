
//===================================================
//创建时间：2025-03-16 21:24:10
//备    注：此代码为工具生成 请勿手工修改
//===================================================
using System.Collections;

/// <summary>
/// ShopPiece实体
/// </summary>
public partial class ShopPieceEntity : AbstractEntity
{
    /// <summary>
    /// 人物姓名
    /// </summary>
    /// 

    public int Id { get; set; }

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
    /// 最大购买数
    /// </summary>
    public int MaxCount { get; set; }

}
