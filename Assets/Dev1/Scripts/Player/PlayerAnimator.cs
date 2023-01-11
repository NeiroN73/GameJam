using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAnimator : MonoBehaviour
{
    public Animator _animator;

    public Crossbow _cakeCatapult;
    public Hammer _hammer;
    public InputSystem _inputSystem;

    public event Action OnEndAnimHammer;
    public event Action OnEndAnimCrossbow;

    private void Start()
    {
        //_cakeCatapult.OnThrowCake += OnAnimThrowCake;
        //_hammer.OnHammerAttack += OnAnimHammerAttack;

        _animator = GetComponent<Animator>();
    }

    public void OnAnimThrowCake()
    {
        _animator.Play("CrossbowShot");
        _inputSystem.isMoving = false;
    }

    public void OnAnimHammerAttack()
    {
        _animator.Play("HammerAttack");
        _inputSystem.isMoving = false;
    }

    public void EndAnimHammer() //animation event
    {
        OnEndAnimHammer?.Invoke();
        _inputSystem.isMoving = true;
    }

    public void EndAnimCrossbow() //anim event
    {
        OnEndAnimCrossbow?.Invoke();
        _inputSystem.isMoving = true;
    }

    private void Update()
    {
        AnimationMoving();
    }

    private void AnimationMoving()
    {
        Vector3 direction = _inputSystem.GetDirectionMove();
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
