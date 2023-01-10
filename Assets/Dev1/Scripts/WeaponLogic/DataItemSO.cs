using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Item")]
public class DataItemSO : ScriptableObject
{
    public ItemType ItemType;
    public GameObject ItemPrefab;
}

public enum ItemType { Hammer, Crossbow };
