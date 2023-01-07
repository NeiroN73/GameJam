using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public DataItem Weapon;
    public void Initialize(DataItem weapon)
    {
        Weapon = weapon;
    }
}
