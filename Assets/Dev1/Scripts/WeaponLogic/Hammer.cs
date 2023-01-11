using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Hammer : Weapon
{
    public List<Enemy> _listEnemys = new();

    //public event Action OnHammerAttack;
    private void Start()
    {
        playerAnimator.OnEndAnimHammer += Attack;
        CurrentWeaponModel.SetActive(false);
    }
    public override void PlayAnimation()
    {
        playerAnimator.OnAnimHammerAttack();
    }

    public void Attack()
    {
        Collider[] hits = Physics.OverlapSphere(transform.localPosition + transform.forward, 1);
        foreach (var hit in hits)
        {
            if(hit.TryGetComponent(out Enemy enemy))
            {
                Destroy(enemy.gameObject);
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.localPosition + transform.forward, 1);
    }
}