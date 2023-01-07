using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Item")]
public class DataItem : ScriptableObject
{
    public ItemType ItemType;
}

public enum ItemType { Weapon1, Weapon2 };
