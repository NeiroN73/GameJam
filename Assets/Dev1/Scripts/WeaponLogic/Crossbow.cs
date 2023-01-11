using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Crossbow : Weapon
{
    [SerializeField] private Bullet _cakePrefab;
    [SerializeField] private Transform _spawnPointCake;
    [SerializeField] private float _dropForce;
    [SerializeField] private float _heightDrop;

    private void Start()
    {
        playerAnimator.OnEndAnimCrossbow += Attack;
        //CurrentWeaponModel.SetActive(false);   // fix conflict git, later return it string
    }

    public override void PlayAnimation()
    {
        playerAnimator.OnAnimThrowCake();
    }

    public void Attack()
    {
        Vector3 direction = transform.forward;
        Bullet bullet = Instantiate(_cakePrefab, _spawnPointCake.position, transform.rotation);
        bullet.Initialize(new Vector3(direction.x, _heightDrop, direction.z), _dropForce);
    }
}