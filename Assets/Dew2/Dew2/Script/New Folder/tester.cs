using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tester : MonoBehaviour
{
    public StateAmmunition Gm;
    public GameObject Gms;
    private void Start()
    {

        Gm.Hit(10, Gms);
    }
}
    

    
