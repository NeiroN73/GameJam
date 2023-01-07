using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem
{
    public Vector3 GetDirectionMove()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        return direction;
    }
}

