using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingTest : MonoBehaviour
{
    public float Rad; // в радиана
    public Vector3 velocity;
    public float Ang;
    private void Update()
    {
        velocity = gameObject.transform.position;
        Rad = Mathf.Atan2(velocity.x, velocity.z);
         Ang = Rad / Mathf.PI * 180f;
    }
}
