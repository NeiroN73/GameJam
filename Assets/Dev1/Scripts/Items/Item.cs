using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public DataItemSO DataItemSO;
    public Rigidbody _rigidbody;
    
    public void ThrowUp()
    {
        _rigidbody.AddForce(transform.forward * 500000);
        print("up");
    }
}
