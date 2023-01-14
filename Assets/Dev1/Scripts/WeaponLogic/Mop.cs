using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mop : Weapon
{
    public int Damage;

    private void Start()
    {
        playerAnimator.OnEndAnimMop += Attack;
        CurrentWeaponModel.SetActive(false);
    }
    public override void PlayAnimation()
    {
        playerAnimator.OnAnimMopAttack();
    }

    public void Attack()
    {
        Collider[] hits = Physics.OverlapSphere(transform.localPosition + transform.forward, 2);
        foreach (var hit in hits)
        {
            if (hit.TryGetComponent(out Enemy enemy))
            {
                //здесь вызывать метод прин€ти€ урона врагом с полем Damage
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.localPosition + transform.forward, 2);
    }

}
