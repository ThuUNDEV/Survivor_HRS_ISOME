using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ScripableObject/ItemData", order = 1)]
public class ItemScriptable : ScriptableObject
{
    public int Id;
    public Sprite IconSprite;
    public string Description;
}
