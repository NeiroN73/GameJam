using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tester : MonoBehaviour
{
    public StateAmmunition Gm;
    public Transform Gms;
    private void Awake()
    {

        Gm.Hit(10, Gms);
    }
}
    

    
