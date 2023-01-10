using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bones : MonoBehaviour
{
    public Rigidbody [] allRigitbodys;
    
    private void Awake()
    {
        for (int i = 0; i < allRigitbodys.Length; i++)
        {
            allRigitbodys[i].isKinematic = true;
        }
    }
    public void MakePhisical()
    {
        for (int i = 0; i < allRigitbodys.Length; i++)
        {
            allRigitbodys[i].isKinematic = false;
        }
    }
}
