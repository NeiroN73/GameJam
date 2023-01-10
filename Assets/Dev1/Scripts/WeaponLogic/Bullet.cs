using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody _rigidbody;

    public void Initialize(Vector3 direction, float dropForce)
    {
        _rigidbody = GetComponent<Rigidbody>();

        Shoot(direction, dropForce);
    }

    private void Shoot(Vector3 direction, float dropForce)
    {
        _rigidbody.AddForce(direction * dropForce * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
