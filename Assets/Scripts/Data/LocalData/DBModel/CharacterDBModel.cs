using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDBModel : AbstractDBModel<CharacterDBModel, CharacterEntity>
{
    protected override string FileName { get { return "Character.data"; } }

    protected override CharacterEntity MakeEntity(GameDataTableParser parser)
    {
        CharacterEntity entity = new CharacterEntity();
        entity.id = parser.GetFieldValue("Id").ToInt();
        entity.name = parser.GetFieldValue("Name");
        entity.level = parser.GetFieldValue("level").ToInt();
        entity.Desc = parser.GetFieldValue("Desc");
        return entity;
    }
}

public static class StringUtil{
    public static int ToInt(this string str)
    {
        int temp = 0;
        int.TryParse(str, out temp);
        return temp;
    }
    public static float ToFloat(this string str)
    {
        float temp = 0;
        float.TryParse(str, out temp);
        return temp;
    }
}