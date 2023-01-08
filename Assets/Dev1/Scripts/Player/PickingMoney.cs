using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PickingMoney : MonoBehaviour
{
    public event Action OnPickingCoin;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Money money))
        {
            //_tmpro.text;
            OnPickingCoin?.Invoke();
            Destroy(money.gameObject);
        }
    }
}
