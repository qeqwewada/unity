
//===================================================
//备    注：此代码为工具生成 请勿手工修改
//===================================================
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// ShopRole数据管理
/// </summary>
public partial class ShopRoleDBModel : AbstractDBModel<ShopRoleDBModel, ShopRoleEntity>
{
    /// <summary>
    /// 文件名称
    /// </summary>
    protected override string FileName { get { return "ShopRole.data"; } }

    /// <summary>
    /// 创建实体
    /// </summary>
    /// <param name="parse"></param>
    /// <returns></returns>
    protected override ShopRoleEntity MakeEntity(GameDataTableParser parse)
    {
        ShopRoleEntity entity = new ShopRoleEntity();
        entity.Id = parse.GetFieldValue("Id").ToInt();
        entity.Name = parse.GetFieldValue("Name");
        entity.price = parse.GetFieldValue("price").ToInt();
        entity.avatarUrl = parse.GetFieldValue("avatarUrl");
        entity.Desc = parse.GetFieldValue("Desc");
        entity.MaxCount = parse.GetFieldValue("MaxCount").ToInt();
        entity.level = parse.GetFieldValue("level").ToInt();
        entity.CharacterUrl = parse.GetFieldValue("CharacterUrl");
        return entity;
    }
}
