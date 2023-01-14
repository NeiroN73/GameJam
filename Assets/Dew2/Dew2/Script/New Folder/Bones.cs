using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bones : MonoBehaviour
{
    public Rigidbody [] allRigitbodys;
    
    private void Awake()
    {
        OffMakePhisical();
    }
    public void MakePhisical()
    {
        for (int i = 0; i < allRigitbodys.Length; i++)
        {
            allRigitbodys[i].isKinematic = false;
        }
    }
    public void OffMakePhisical()
    {
        for (int i = 0; i < allRigitbodys.Length; i++)
        {
            allRigitbodys[i].isKinematic = true;
        }
    }
}
