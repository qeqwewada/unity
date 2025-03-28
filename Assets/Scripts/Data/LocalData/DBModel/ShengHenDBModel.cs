
//===================================================
//备    注：此代码为工具生成 请勿手工修改
//===================================================
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// ShengHen数据管理
/// </summary>
public partial class ShengHenDBModel : AbstractDBModel<ShengHenDBModel, ShengHenEntity>
{
    /// <summary>
    /// 文件名称
    /// </summary>
    protected override string FileName { get { return "ShengHen.data"; } }

    /// <summary>
    /// 创建实体
    /// </summary>
    /// <param name="parse"></param>
    /// <returns></returns>
    protected override ShengHenEntity MakeEntity(GameDataTableParser parse)
    {
        ShengHenEntity entity = new ShengHenEntity();
        entity.Id = parse.GetFieldValue("Id").ToInt();
        entity.Name = parse.GetFieldValue("Name");
        entity.price = parse.GetFieldValue("price").ToInt();
        entity.Imageurl = parse.GetFieldValue("Imageurl");
        entity.Desc = parse.GetFieldValue("Desc");
        entity.type = parse.GetFieldValue("type");
        entity.suit = parse.GetFieldValue("suit");
        entity.buff = parse.GetFieldValue("buff");
        return entity;
    }
}
