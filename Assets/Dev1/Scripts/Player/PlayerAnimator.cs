using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAnimator : MonoBehaviour
{
    public Animator _animator;

    public InputSystem _inputSystem;

    public event Action OnEndAnimHammer;
    public event Action OnEndAnimCrossbow;
    public event Action OnEndAnimMop;

    public ItemType ItemType;

    private void Start()
    {
        //_cakeCatapult.OnThrowCake += OnAnimThrowCake;
        //_hammer.OnHammerAttack += OnAnimHammerAttack;

        _animator = GetComponent<Animator>();
    }

    public void OnAnimThrowCake()
    {
        _animator.Play("IdleCrossbow");
        _inputSystem.isMoving = false;
    }

    public void OnAnimHammerAttack()
    {
        _animator.Play("AttackHammer");
        _inputSystem.isMoving = false;
    }

    public void OnAnimMopAttack()
    {
        _animator.Play("MopAttack1");
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

    public void EndAnimMopAttack1()
    {
        OnEndAnimMop?.Invoke();
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
            switch (ItemType)
            {
                case ItemType.Crossbow:
                    _animator.Play("CrossbowRun");
                    break;
                case ItemType.Hammer:
                    _animator.Play("HammerRun");
                    break;
                case ItemType.Mop:
                    _animator.Play("MopIdle");
                    break;
                default:
                    _animator.Play("isMoving");
                    break;
            }
            
        }
        else
        {
            switch (ItemType)
            {
                case ItemType.Crossbow:
                    _animator.Play("CrossbowRun");
                    break;
                case ItemType.Hammer:
                    _animator.Play("HammerRun");
                    break;
                case ItemType.Mop:
                    _animator.Play("MopRun");
                    break;
                default:
                    _animator.Play("isMoving");
                    break;
            }
        }
    }
}
