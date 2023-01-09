using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HpText : MonoBehaviour
{
    public UnityEvent Present;
    
    private void OnTriggerEnter(Collider other) {
        Present.Invoke();
    }
    private void OnTriggerExit(Collider other) {
        Present.Invoke();
    }
}
