using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputSystem : MonoBehaviour
{
    public event Action<Vector3> OnLeftMouseClick;
    public event Action OnSpacePressed;

    public bool isMoving { get; set; } = true;

    public Vector3 GetDirectionMove()
    {
        if (isMoving == false)
            return Vector3.zero;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        return direction;
    }

    private void Update()
    {
        if (isMoving == false)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            OnLeftMouseClick?.Invoke(Input.mousePosition);
        }

        if(Input.GetButtonDown("Jump"))
        {
            OnSpacePressed?.Invoke();
        }
    }
}

