using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mop : Weapon
{
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
        Collider[] hits = Physics.OverlapSphere(transform.localPosition + transform.forward, 1);
        foreach (var hit in hits)
        {
            if (hit.TryGetComponent(out Enemy enemy))
            {
                Destroy(enemy.gameObject);
            }
        }
    }

}
