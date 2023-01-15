using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tester : MonoBehaviour
{
    public StateAmmunition Gm;
    public GameObject Gms;
    private void Start()
    {

        StartCoroutine(SpawnSkeleton());
    }
    public IEnumerator SpawnSkeleton()
    {
        Gm.Hit(10);
        yield return new WaitForSeconds(3f);
        
    }
}
    

    
