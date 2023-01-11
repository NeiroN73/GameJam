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
    private Bullet _bullet;

    private void Start()
    {
        playerAnimator.OnEndAnimCrossbow += Attack;
        CurrentWeaponModel.SetActive(false);   
    }

    public override void PlayAnimation()
    {
        _bullet = Instantiate(_cakePrefab, _spawnPointCake.position, transform.rotation);
        playerAnimator.OnAnimThrowCake();
    }

    public void Attack()
    {
        Vector3 direction = transform.forward;
        //bullet.Initialize(new Vector3(direction.x, _heightDrop, direction.z), _dropForce);
        _bullet.Shoot(_dropForce);
    }
}
