
//===================================================
//备    注：此代码为工具生成 请勿手工修改
//===================================================
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// ShopPiece数据管理
/// </summary>
public partial class ShopPieceDBModel : AbstractDBModel<ShopPieceDBModel, ShopPieceEntity>
{
    /// <summary>
    /// 文件名称
    /// </summary>
    protected override string FileName { get { return "ShopPiece.data"; } }

    /// <summary>
    /// 创建实体
    /// </summary>
    /// <param name="parse"></param>
    /// <returns></returns>
    protected override ShopPieceEntity MakeEntity(GameDataTableParser parse)
    {
        ShopPieceEntity entity = new ShopPieceEntity();
        entity.Id = parse.GetFieldValue("Id").ToInt();
        entity.Name = parse.GetFieldValue("Name");
        entity.price = parse.GetFieldValue("price").ToInt();
        entity.Imageurl = parse.GetFieldValue("Imageurl");
        entity.Desc = parse.GetFieldValue("Desc");
        entity.MaxCount = parse.GetFieldValue("MaxCount").ToInt();
        return entity;
    }
}
