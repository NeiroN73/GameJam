using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody.Sleep();
    }

    public void Shoot(float dropForce)
    {
        _rigidbody.WakeUp();
        _rigidbody.AddForce(transform.forward * dropForce);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
