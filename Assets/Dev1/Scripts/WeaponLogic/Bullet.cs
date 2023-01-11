using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    public void Initialize(Vector3 direction, float dropForce)
    {
        Shoot(dropForce);
    }

    public void Shoot(float dropForce)
    {
        _rigidbody.AddForce(transform.forward * dropForce);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
