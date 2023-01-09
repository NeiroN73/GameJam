using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator _animator;

    public CakeCatapult _cakeCatapult;
    public InputSystem _inputSystem;

    private void Start()
    {
        _cakeCatapult.OnThrowCake += OnAnimThrowCake;

        _animator = GetComponent<Animator>();
    }

    private void OnAnimThrowCake()
    {
        _animator.SetTrigger("isHammerAttack");
    }

    private void Update()
    {
        Vector3 direction = _inputSystem.GetDirectionMove();
        print(direction);
        if (direction.x == 0 && direction.z == 0)
        {
            _animator.SetBool("isMoving", false);
        }
        else
        {
            _animator.SetBool("isMoving", true);
        }
    }
}
